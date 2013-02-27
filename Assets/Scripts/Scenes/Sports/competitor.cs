using UnityEngine;
using System.Collections;

public class competitor :  MonoBehaviour {
	
	private int minutes = 0;
	public float speed = 0.25F;
	
	public bool grounded = false;
	private CharacterController controller = null;
	
    private Vector3 moveDirection = Vector3.zero;
   
    public float jumpSpeed = 4.0F;
    public float gravity = 10.0F;
	
	Vector3 dir;
  
	public float range = 2.0f;
	public GameObject[] other;
	// Use this for initialization
	void Start () {
	
	  controller = GetComponent<CharacterController>();
        if (!controller)
        {
            controller = gameObject.AddComponent<CharacterController>();
        }
		
		 other = GameObject.FindGameObjectsWithTag("Hurdle");
	
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		
			if( minutes == 0){
				
		   if (grounded)
        {
			
			moveDirection =  new Vector3(-6.0f,0,0);
            moveDirection *= speed;
	
				 foreach(GameObject g in other)
				{
					dir=g.transform.position-transform.position;
		    		dir.Normalize();
					float dbt;
		      	    dbt = Vector3.Distance(g.transform.position, transform.position);
			
		        
     		    if (dbt < range)
				{
						moveDirection = new Vector3(-3.5f,jumpSpeed,0.0f);
				}
			}
		}
		}
      
        // Apply gravity
        moveDirection.y -= gravity * Time.deltaTime;
		
        // Move the controller
        var flags = controller.Move(moveDirection * Time.deltaTime);
        grounded = (flags & CollisionFlags.CollidedBelow) != 0;
	}
	
	void Update()
	{
		  if (controller.isGrounded)
        {
			moveDirection =  new Vector3(-6.0f,0,0);
            moveDirection *= speed;
		}
		
		   moveDirection.y -= gravity * Time.deltaTime;
		
        controller.Move(moveDirection * Time.deltaTime);
        //add this into FixedUpdate()
       	
		foreach(GameObject g in other)
		{
			dir=g.transform.position-transform.position;
    		dir.Normalize();	
		float d;
      	    d = Vector3.Distance(g.transform.position, transform.position);
	
        if (d < range)
        {
			moveDirection = new Vector3(-3.5f,jumpSpeed,0.0f);
		}
		}
    }
}
