using UnityEngine;
using System.Collections;

public class ZScript : MonoBehaviour {

	public Vector3 startP;
	public GameObject[] zs;
	// Use this for initialization
	void Start () {
		
		zs = GameObject.FindGameObjectsWithTag("Z");
		
		foreach(GameObject ig in zs)
		{
				startP = ig.gameObject.transform.position;
		
		}
	}
	
	// Update is called once per frame
	void Update () {
	
		if(zs == null)
				{
			foreach(GameObject ig in zs)
			{
						ig.transform.position = startP;
			}
				}	
		
		foreach(GameObject ig in zs)
		{
			if(ig == null)
			{
				ig.active = true;
			}
		}
		}
}
