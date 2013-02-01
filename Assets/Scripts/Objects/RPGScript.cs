using UnityEngine;
using System.Collections;

public class RPGScript : MonoBehaviour {
	
	public GameObject bl;
	
	public float timeToSpawn = 1.0f;
    public float currTime = 0.0f;
	public GameObject[] ig;
	
	// Use this for initialization
	void Start () {
	     
			 ig = GameObject.FindGameObjectsWithTag("Z");
	}
	
	// Update is called once per frame
	void Update () {
		
		currTime += Time.deltaTime;
		
		 if (GameObject.FindWithTag("Z") != null)
		{
			if (currTime > timeToSpawn)
	        {
	            Instantiate(bl,transform.position, transform.rotation);
				currTime = 0.0f;
			}
		}
		else{
  
		foreach(GameObject go in ig)
		{
   		 if(go.gameObject.active == false)
				{
					go.gameObject.active = true;
				}
		}
		}
	}
}