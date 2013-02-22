using UnityEngine;
using System.Collections;

public class PipeScript : MonoBehaviour {
	
	 Ray ray; 
	
     RaycastHit hit;
	
	 GameObject sp;
	 GameObject ep;
	 public GameObject[] map = new GameObject[3];	
	
	 WinScript wn;
	 WinScript en;
	
     bool won;
	 public int comp=0;
	
	 public PipeConnectorScript[] pcs;
	
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
	}
	
	// Update is called once per frame
	void Update () {
		
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
			comp++;
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
}
