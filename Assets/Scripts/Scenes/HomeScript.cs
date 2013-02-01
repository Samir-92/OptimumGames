using UnityEngine;
using System.Collections;

public class HomeScript : MonoBehaviour {
	
	public GameObject[] levels;
	public PlayerScript ps;
	public CameraScript cs;
	
	// Use this for initialization
	void Start () {
	}
	// Update is called once per frame
	void Update () {
		
		levels[0].gameObject.transform.renderer.material.color = Color.green;
		levels[1].gameObject.transform.renderer.material.color = Color.blue;
		levels[2].gameObject.transform.renderer.material.color = Color.yellow;
		levels[3].gameObject.transform.renderer.material.color = Color.red;
		
		if(ps.m == 1 || cs.s == 1)
		{
			levels[5].gameObject.SetActiveRecursively(true);
			levels[5].gameObject.transform.renderer.material.color = Color.blue;
		}
		else
		{
			levels[5].gameObject.SetActiveRecursively(false);
		}
		
		if(ps.m == 2 || cs.s ==2)
		{
			levels[4].gameObject.SetActiveRecursively(true);
			levels[4].gameObject.transform.renderer.material.color = Color.green;
		}
		else
		{
			levels[4].gameObject.SetActiveRecursively(false);
		}
		
		if(ps.m == 3 || cs.s ==3)
		{
			levels[6].gameObject.SetActiveRecursively(true);
			levels[6].gameObject.transform.renderer.material.color = Color.yellow;
		}
		else
		{
			levels[6].gameObject.SetActiveRecursively(false);
		}
		
		if(ps.m == 4 || cs.s ==4)
		{
			levels[7].gameObject.SetActiveRecursively(true);
			levels[7].gameObject.transform.renderer.material.color = Color.red;
		}
		else
		{
			levels[7].gameObject.SetActiveRecursively(false);
		}
	}
}
