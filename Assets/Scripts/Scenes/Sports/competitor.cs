using UnityEngine;
using System.Collections;

public class competitor :  MonoBehaviour {
	
	private int minutes = 0;
	public float speed = 0.25F;
	
	public bool grounded = false;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if( minutes == 0){
			transform.position += Vector3.right * speed;
		}
		
        if (grounded)
        {
		}
	}
	
	void Update()
	{
		
	}
}
