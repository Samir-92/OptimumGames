using UnityEngine;
using System.Collections;

public class EnemyMovement : MonoBehaviour {
	
	public GameObject pl;
	public GameObject[] ig;
	public float rotationDamping = 8.0f;
    public float gravity = 1.0f;
	
	public Vector3 moveDirection;
    public Vector3 velocity;
  
    public float speed = 5.0f;
	
	public Vector3 startP;
	// Use this for initialization
	void Start () {
	
		this.gameObject.renderer.material.color = Color.red;
		pl = GameObject.FindWithTag("Player");
		
		ig = GameObject.FindGameObjectsWithTag("Block");
  
		foreach(GameObject go in ig)
		{
   		 Physics.IgnoreCollision(go.gameObject.collider, collider);
		}
		
		foreach(GameObject go in ig)
		{
			startP = go.transform.localPosition;
		}
	}
	// Update is called once per frame
	void Update () {
		
       Vector3 delta = pl.transform.localPosition - transform.rigidbody.position;
       delta.Normalize();

       transform.rigidbody.position = transform.rigidbody.position + (delta * (speed*Time.deltaTime));
		
		    // transform.LookAt(waypoint[currentWayPoint]);   
        transform.rotation = Quaternion.Slerp(transform.rotation, 
                            (Quaternion.LookRotation(pl.transform.localPosition - transform.rigidbody.position)),
                             Time.deltaTime * rotationDamping);
	
	}
}
