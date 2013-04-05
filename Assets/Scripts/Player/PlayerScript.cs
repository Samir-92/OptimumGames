using UnityEngine;
using System.Collections;

public class PlayerScript : MonoBehaviour {
	
	public int m;
	
	Vector3 curVec;
	
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	void OnTriggerEnter(Collider hit)
	{
		if(hit.collider.gameObject.tag == "Maths")
		{
			m = 1;			
		}
		if(hit.collider.gameObject.tag == "Computing")
		{
			m = 2;			
		}
		if(hit.collider.gameObject.tag == "Science")
		{
			m = 3;			
		}
		if(hit.collider.gameObject.tag == "Sports")
		{
			m = 4;			
		}	
		
		if(hit.collider.gameObject.tag == "Home")
		{
			m = 5;			
		}
	}
}