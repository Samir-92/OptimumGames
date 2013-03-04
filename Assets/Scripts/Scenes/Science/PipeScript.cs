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
	
     bool won;
	 public int comp=0;
	
	 public PipeConnectorScript[] pcs;
	 public float gameStartTime=120.0f;
	float ptime = 5.0f;
	bool start;
	ParticleSystem[] p;
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
	}
	
	// Update is called once per frame
	void Update () {
		
		gameStartTime-=Time.deltaTime;
		
		if(gameStartTime <= 0.0f)
		{
			Application.LoadLevel(0);	
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
			}
		}
		
		mapSelect();
		clickRot();
		
		if(comp >= 3)
		{
			Application.LoadLevel(0);
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
		GUI.Label(new Rect(Screen.width-100,20,100,50),"Time left: "+ gameStartTime.ToString("f0"));
		
	}
}
