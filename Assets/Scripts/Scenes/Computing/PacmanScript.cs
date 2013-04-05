using UnityEngine;
using System.Collections;

public class PacmanScript : MonoBehaviour 
{
	
	public float playerSpeed=4.0f;
	private float endTime=0.0f;
	public float gameStartTime=70;
	private float gameEndTime=0;
	
	public float powerTime=4.0f;
	public float speedTime=4.0f;

	public int speedBoostMultiplier=2;
	
	private bool north=false,
				south=false,
				east=false,
				west=false;
				
	private bool	speedBoost=false,
				powerBoost=false;
				
	public bool showTime=true;
				
	public int lives=3;
	public int score=0;

	public int dataScore= 10;
	public int deathScore= -25;
	public int killScore= 50;
	
	public GameObject aScore;
	public GameObject bScore;
	public GameObject cScore;
	public GameObject fScore;
	public GameObject win;
	
	public bool oneTime=true;
	
	public GameObject[] data;
	int done;
	
	Vector3 startPos;
	void Start () 
	{
		data = GameObject.FindGameObjectsWithTag("Data");
		done = data.Length;
		 
		if (!animation)
        {
            Debug.Log("None");
        }
		
		startPos = transform.localPosition;
	}
	
	
	void Spawn ()
	{
		AddScore(deathScore);
		if(lives > 0)
		{
			north=false;
			south=false;
			east=false;
			west=false;
			transform.localPosition = startPos;
		    transform.Translate(new Vector3(0,0,0));
		}
		else if(lives <= 0)
		{
			lives = 0;
			gameStartTime=0;
			showTime=false;
			//end game code
			//Application.LoadLevel(0);
			EndGame();
		}
		lives--;
		
		powerBoost=false;
		
		if(speedBoost==true)
		{
			speedBoost=false;	
			playerSpeed/=speedBoostMultiplier;
		}
	}
	
	void EndGame()
	{
		GameObject nd = GameObject.Find("NeverDie");
		DontDie d = nd.GetComponent<DontDie>();
		
		win.active=true;
		
		if (score < 200)
		{
			fScore.active=true;
		}
		if (score >= 200 && score <500)
		{
			if(oneTime==true)
			{
			cScore.active=true;
			d.ascore++;
			oneTime=false;

			}
		}
			if (score >= 500 && score < 1000)	
			{
			if(oneTime==true)
			{
				bScore.active=true;
				d.ascore++;
				oneTime=false;
			}
			}
			if  (score > 1000)
			{
			aScore.active=true;
			if(oneTime==true)
			{
			d.ascore++;
			oneTime=false;
			}
				}
			
		
		if(gameStartTime<-4)
			{
				
				
				
				Application.LoadLevel(1);	
			}	
			
	
	}
	
	void Update ()
	{		
		gameStartTime-=Time.deltaTime;
		
		if(gameStartTime<=gameEndTime)
		{
			EndGame();
			//Application.Quit();	
			showTime=false;
		}
		
		if(done == 0)
		{
			EndGame();
			//Application.LoadLevel(0);
		}
		
		Keys();
		
		if(north==true)
		{
			transform.rotation = Quaternion.Euler(0,0,0);
			transform.Translate(new Vector3(0,0,1)*playerSpeed*Time.deltaTime);
		}
		else if(south==true)
		{	
			transform.rotation = Quaternion.Euler(0,180,0);
			transform.Translate(new Vector3(0,0,1)*playerSpeed*Time.deltaTime);
		}
		else if(east==true)
		{
			transform.rotation = Quaternion.Euler(0,90,0);
			transform.Translate(new Vector3(0,0,1)*playerSpeed*Time.deltaTime);
		}
		else if(west==true)
		{	
			transform.rotation = Quaternion.Euler(0,270,0);
			transform.Translate(new Vector3(0,0,1)*playerSpeed*Time.deltaTime);
		}	
		else
		{
			
		transform.rigidbody.angularVelocity = Vector3.zero;
		transform.rigidbody.velocity = Vector3.zero;
		}
		if(speedBoost==true)
		{
			speedTime-=Time.deltaTime;
			if(speedTime<=endTime)
			{
				speedTime=4.0f;
				speedBoost=false;	
			}
			if(speedBoost==false)
			{
				playerSpeed/=speedBoostMultiplier;
			}
		}
		
		if(powerBoost==true)
		{
			powerTime-=Time.deltaTime;
			if(powerTime<=endTime)
			{
				powerTime=4.0f;
				powerBoost=false;	
			}	
		}
		
		Transform child = transform.Find("Brian Walk"); 
			
		if(north == true || west == true || south == true || east == true)
		{
			child.animation.Play( "Take 001" );
		}
		else
		{
			child.animation.Stop();
		}
		
		if(north == false || south == false || east == false || west == false)
		{
			transform.Translate(new Vector3(0,0,0));
		}
	}
	
	
	void Keys()
	{
		if(Input.GetKeyDown(KeyCode.UpArrow)||Input.GetKeyDown(KeyCode.W))
		{
			north=true;
			south=false;
			east=false;
			west=false;
		}
		if(Input.GetKeyDown(KeyCode.DownArrow)||Input.GetKeyDown(KeyCode.S))
		{
			north=false;
			south=true;
			east=false;
			west=false;
		}
		if(Input.GetKeyDown(KeyCode.RightArrow)||Input.GetKeyDown(KeyCode.D))
		{
			north=false;
			south=false;
			east=true;
			west=false;
		}
		if(Input.GetKeyDown(KeyCode.LeftArrow)||Input.GetKeyDown(KeyCode.A))
		{
			north=false;
			south=false;
			east=false;
			west=true;
		}
	}
	void OnCollisionEnter(Collision hit)
	{
		if(hit.gameObject.tag =="Wall")
		{
			north=false;
			south=false;
			east=false;
			west=false;
		
			transform.Translate(new Vector3(0,0,0));
		}
	}
	void OnCollisionStay(Collision hit)
	{
		if(hit.gameObject.tag =="Wall")
		{
			north=false;
			south=false;
			east=false;
			west=false;
		
			transform.Translate(new Vector3(0,0,0));
		}
	}
	
	void OnTriggerEnter(Collider hut)
	{
		if(hut.gameObject.tag =="Speed")
		{
			Destroy(hut.gameObject);
			SpeedBoost();
		}
		
		if(hut.gameObject.tag =="Enemy")
		{
			if(powerBoost==true)
			{
				Destroy(hut.gameObject);
				AddScore(killScore);
			}
			else
			{
				Spawn();
			}
		}
		
		if(hut.gameObject.tag =="Power")
		{
			Destroy(hut.gameObject);
			PowerBoost();
		}
		
		if(hut.gameObject.tag =="Data")
		{
			done--;
			Destroy(hut.gameObject);
			AddScore(dataScore);
		}
	}
	
	void SpeedBoost()
	{
		playerSpeed*=speedBoostMultiplier;
		speedBoost=true;
	}
	
	void PowerBoost()
	{
		powerBoost=true;	
	}
	
	void AddScore(int scored)
	{
		score+=scored;	
	}
	
	void OnGUI()
	{
		GUI.Label(new Rect(Screen.width-100,0,100,50),"Score: " +score);
		GUI.Label(new Rect(Screen.width-100,50,100,50),"Lives: " +lives);
		
		if(showTime==true)
		{
			GUI.Label(new Rect(Screen.width-100,20,100,50),"Time left: "+gameStartTime.ToString("f0"));
		}
		
		if(speedBoost==true)
		{
			GUI.Label(new Rect(Screen.width/2-25,Screen.height/2-25,50,50), speedTime.ToString("f0"));	
		}
		
		if(powerBoost==true)
		{
			GUI.Label(new Rect(Screen.width/2-25,Screen.height/2-25,50,50), powerTime.ToString("f0"));	
		}
	}
}
