using UnityEngine;
using System.Collections;

public class PipeScript : MonoBehaviour {
	
	 Ray ray; 
	
     RaycastHit hit;
	
	 GameObject sp;
	 GameObject ep;
	 public GameObject[] map = new GameObject[3];	
	 public GameObject burn;
	 WinScript wn;
	 WinScript en;
	 
	 public GameObject win;
	 public GameObject fScore;
	 public GameObject aScore;
	 public GameObject bScore;
	 public GameObject cScore;
	 
	 public float score;
	
     bool won;
	 public int comp=0;
	
	 public PipeConnectorScript[] pcs;
	 public float gameStartTime=30.0f;
	public float endtime = 4.0f;
	float ptime = 5.0f;
	public bool start;
	ParticleSystem[] p;
	
	
	public GameObject[] clock = new GameObject[14];
	float timer = 0.0f;
	public int step=0;
	 // Ue this for initialization
	 void Start () {	
		
		GameObject[] pipe;
		pipe = GameObject.FindGameObjectsWithTag("Pipe");
		
		foreach(GameObject go in pipe)
		{	
			if(go.collider != collider)
			{
				Physics.IgnoreCollision(go.collider, collider);
			}
		}
		
		sp = GameObject.Find("StartBlock");
		ep = GameObject.Find("EndBlock");
		
		wn = sp.GetComponent<WinScript>();
		en = ep.GetComponent<WinScript>();
			
		if(pcs != null)
		{
		pcs = FindObjectsOfType(typeof(PipeConnectorScript)) as PipeConnectorScript[];
		}
		
		burn = GameObject.Find("Boiling");
		
		p = burn.GetComponentsInChildren<ParticleSystem>();
		
		foreach(ParticleSystem ps in p)
		{
			ps.enableEmission = false;
		}
		resetClock();
	}
	
	// Update is called once per frame
	void Update () {
		
		if(start == false){
			resetClock();
		gameStartTime-=Time.deltaTime;
			}
		
		if(gameStartTime <= 0.0f)
		{
			win.active=true;
			fScore.active=true;
			if(gameStartTime<=-4)
			Application.LoadLevel(1);	
		}
		
		if(map[0].active == true || map[1].active == true || map[2].active == true)
		{
		foreach(PipeConnectorScript sc in pcs)
		{
			if(sc.connected == true)
			{
				won = true;
			}
			else
			{
				won = false;
				break;
			}
		}
		}
		if(wn.dm == true && en.dm == true && won == true)
		{
			Debug.Log("WON!!!!!!!");
			if(start==false)	{
			score+=gameStartTime;}
			particle();
			
			if(ptime <= 0)
			{ 
				foreach(ParticleSystem ps in p)
		{
			ps.enableEmission = false;
		}
				comp++;
	 			gameStartTime = 30.0f;
				ptime = 5.0f;
				start = false;
			clock[step].active = false;
			step = 0;
			clock[0].active=true;	
			timer = 0.0f;
			}
		}
		
		mapSelect();
		clickRot();
		
		if(comp >= 3)
		{
			endtime-=Time.deltaTime;
			win.active=true;
			if(score>50)
			{
			aScore.active=true;}
			else if(score<=50 && score > 25){
			bScore.active=true;}
			else{
			cScore.active = true;}
			gameStartTime = 4.0f;

			GameObject nd = GameObject.Find("NeverDie");
			DontDie d = nd.GetComponent<DontDie>();

			d.bscore++;
			
			
			if(endtime < 0.0f)
			{
			Application.LoadLevel(1);
		}
		}
		
	}
	public void resetClock(){
	
		
		float timeStep = 30.0f/14.0f;
		
		timer += Time.deltaTime;
		if (timer > timeStep)
		{
			timer=0.0f;
			clock[step].active=false;
			clock[step+1].active=true;
			step++;	
		}

	}
	
	void clickRot()
	{
		if(start != true)
		{
		if(Input.GetMouseButtonDown(0))
		{
			ray = Camera.main.ScreenPointToRay (Input.mousePosition);
			if (Physics.Raycast(ray, out hit)) 
			{ 
				if(hit.transform.tag == "Pipe")
				{
					hit.transform.gameObject.transform.Rotate(new Vector3(0,90,0));
				}
			}
		}
		}
	}	
	
	void mapSelect()
	{
		if(comp==1 && map[0].active == true)
		{
				map[0].SetActiveRecursively(false);
				map[1].SetActiveRecursively(true);

				pcs = FindObjectsOfType(typeof(PipeConnectorScript)) as PipeConnectorScript[];
				won = false;
				comp = 1;
		}
		
		if(comp==2 && map[1].active == true)
		{
				map[1].SetActiveRecursively(false);
				map[2].SetActiveRecursively(true);
				pcs = FindObjectsOfType(typeof(PipeConnectorScript)) as PipeConnectorScript[];
			
				won = false;
				comp = 2;
			}
		
			if(comp==3 && map[2].active == true)
			{
				map[2].SetActiveRecursively(false);
			}
		
		if(map[0].active == false || map[1].active == false || map[2].active == false)
		{
			won = false;
			wn.dm = false;
		    en.dm = false;
		}
	}
	
	void particle()
	{
		start = true;
		ptime -= Time.deltaTime;
		foreach(ParticleSystem ps in p)
		{
			ps.enableEmission = true;
		}
	}
	
	void OnGUI()
	{
	}
}
