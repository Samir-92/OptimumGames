using UnityEngine;
using System.Collections;

public class PacmanScript : MonoBehaviour 
{
	
	public float playerSpeed=4.0f;
	private float endTime=0.0f;
	public float gameStartTime=120;
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
				
	public int lives=3;
	public int score=0;

	public int dataScore= 10;
	public int deathScore= -25;
	public int killScore= 50;
	
	public GameObject[] data;
	int done;
	void Start () 
	{
		data = GameObject.FindGameObjectsWithTag("Data");
		done = data.Length;
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
	
	void Spawn ()
	{
		AddScore(deathScore);
		if(lives > 0)
		{
			north=false;
			south=false;
			east=false;
			west=false;
			transform.localPosition = new Vector3(0,0,0);
		}
		else if(lives <= 0)
		{
			lives = 0;
			//end game code
			Application.LoadLevel(0);
		}
		lives--;
		
		powerBoost=false;
		
		if(speedBoost==true)
		{
			speedBoost=false;	
			playerSpeed/=speedBoostMultiplier;
		}
	}
	
	void Update ()
	{		
		gameStartTime-=Time.deltaTime;
		
		if(gameStartTime<=gameEndTime)
		{
			Application.Quit();	
		}
		
		
			if(done == 0)
			{
				Application.LoadLevel(0);
			}
		Keys();
		
		if(north==true)
		{
			transform.Translate(new Vector3(0,0,1.0f)*playerSpeed*Time.deltaTime);
		}
		if(south==true)
		{
			transform.Translate(new Vector3(0,0,-1.0f)*playerSpeed*Time.deltaTime);
		}
		if(east==true)
		{
			transform.Translate(new Vector3(1.0f,0,0)*playerSpeed*Time.deltaTime);
		}
		if(west==true)
		{
			transform.Translate(new Vector3(-1.0f,0,0)*playerSpeed*Time.deltaTime);
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
	}
	
	void OnCollisionEnter(Collision hit)
	{
		if(hit.gameObject.tag =="Wall")
		{
			north=false;
			south=false;
			east=false;
			west=false;
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
		GUI.Label(new Rect(Screen.width-100,20,100,50),"Time left: "+gameStartTime.ToString("f0"));
		
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
