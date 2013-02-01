using UnityEngine;
using System.Collections;

public class PlayerScript : MonoBehaviour {
	
	public int m;
	
	float num = 30.0f;
	float y = 2.5f;
	Vector3 curVec;
	
	void Start () {
		this.renderer.material.color = Color.cyan;
	}
	
	// Update is called once per frame
	void Update () {
		
		movePlayer();
	}
	void movePlayer()
	{
		if(m == 1)
		{
			transform.localPosition = new Vector3(0.0f,y, -num); 
		}
		
		if(m == 2)
		{
			transform.localPosition = new Vector3(num,y,0.0f); 
		}
		
		if(m == 3)
		{
			transform.localPosition = new Vector3(-num,y,0.0f); 
		}
		
		if(m == 4)
		{
			transform.localPosition = new Vector3(0.0f,y,num); 
		}
		
		if(m==5)
		{
			transform.localPosition = new Vector3(0.0f,y,0.0f);
		}
	}
	
	void resetPosition()
	{
			transform.localPosition = curVec;
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
		if(hit.collider.gameObject.tag == "Catch")
		{
			curVec = new Vector3(transform.localPosition.x, 2.0f, transform.localPosition.z);
			resetPosition();			
		}
	}
}