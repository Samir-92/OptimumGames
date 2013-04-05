using UnityEngine;
using System.Collections;

public class PlayerMovementScript : MonoBehaviour {

    public float speed = 2.0F;
    public float sprintSpeed = 2.5f;
    public float jumpSpeed = 4.0F;
    public float gravity = 10.0F;
    
    public GameObject winCamera;
    public GameObject playCamera;
    public GameObject win;
	
	Vector3 dir;
	
    public bool grounded = false;

    private CharacterController controller = null;
    private Vector3 moveDirection = Vector3.zero;
    public bool walking = false;
    public bool run = false;
    
    public float startTime=0;

    // Use this for initialization
    void Start()
    {
	    controller = GetComponent<CharacterController>();
        if (!controller)
        {
            controller = gameObject.AddComponent<CharacterController>();
        }
		
		 if (!animation)
        {
            Debug.Log("None");
        }
    }

    void FixedUpdate()
    {
        if (grounded)
        {
            // We are grounded, so recalculate movedirection directly from axes
            moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
            moveDirection *= speed;
	
			dir = Vector3.zero;	

        	dir.x = Input.GetAxis("Horizontal");
        	dir.z = Input.GetAxis("Vertical");
			
			if (dir != Vector3.zero) 
			{
			    transform.rotation = Quaternion.Slerp(transform.rotation,
			   						 Quaternion.LookRotation(dir), Time.deltaTime * 8.0f);
			}
			
            if (Input.GetButton("Jump"))
            {
                moveDirection.y = jumpSpeed;
            }
        }
      
        // Apply gravity
        moveDirection.y -= gravity * Time.deltaTime;
		
        // Move the controller
        var flags = controller.Move(moveDirection * Time.deltaTime);
        grounded = (flags & CollisionFlags.CollidedBelow) != 0;
    }

  
    // Update is called once per frame
    void Update()
    {
        if (controller.isGrounded)
        {
			Transform child = transform.Find("Brian Walk"); 
			
            moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
            moveDirection *= speed;
			
			 if (Input.GetKey(KeyCode.LeftShift))
            {
				run=true;
			}
			else
			{
				run=false;
			}
			
            if (run)
            {
                moveDirection *= sprintSpeed;
            }
			
            if (Input.GetKey("space"))
            {
                moveDirection.y = jumpSpeed;
            }
			
			if(Input.GetAxis("Horizontal") > 0 || Input.GetAxis("Horizontal") < 0
			   || Input.GetAxis("Vertical") > 0 || Input.GetAxis("Vertical") < 0)
			{
			child.animation.Play( "Take 001" );
			}
			else{
				child.animation.Stop();
			}
			
			
			
        }
		
			dir = Vector3.zero;	

        	dir.x = Input.GetAxis("Horizontal");
        	dir.z = Input.GetAxis("Vertical");
			
			if (dir != Vector3.zero) 
			{
			    transform.rotation = Quaternion.Slerp(transform.rotation,
			   						 Quaternion.LookRotation(dir), Time.deltaTime * 10.0f);
			}

        moveDirection.y -= gravity * Time.deltaTime;
		
        controller.Move(moveDirection * Time.deltaTime);
        //add this into FixedUpdate()
       
        if ((Mathf.Abs(moveDirection.x) > 0) || (Mathf.Abs(moveDirection.z) > 0))
        {
            //if the player is moving, walking is true
            if (!walking)
            {
                walking = true;
            }
        }
        else if (walking)
        {
            walking = false;
        }
    }
 }
