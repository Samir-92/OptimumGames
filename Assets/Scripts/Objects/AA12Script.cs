using UnityEngine;
using System.Collections;

public class AA12Script : MonoBehaviour {
	
    public RaycastHit hit;
    public Ray ray;
	
    public float currentTimeToShoot = 0.0f;
    public float timeToShoot = 0.15f;
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		 if (GameObject.FindWithTag("Z") != null)
		{
			shoot();
		}
	}
	void shoot()
	{
		currentTimeToShoot += Time.deltaTime;
		
		if (currentTimeToShoot > timeToShoot)
            {
			GameObject[] dir = new GameObject[3];
			
			dir[0] = GameObject.Find("Direction1");
			dir[1] = GameObject.Find("Direction2");
			dir[2] = GameObject.Find("Direction3");
			
			Vector3[] fwd = new Vector3[3];
			
			fwd[0] = dir[0].transform.forward;
			fwd[1] = dir[1].transform.forward;
			fwd[2] = dir[2].transform.forward;
			
				if (Physics.Raycast (dir[0].transform.position, fwd[0], out hit)) 
				{
		 			Debug.DrawRay(dir[0].transform.position,fwd[0],Color.red);
							
					if (hit.collider.gameObject.tag == "Z")
		            {
		              	 Destroy(hit.transform.gameObject);
		            }
				}
				if (Physics.Raycast (dir[1].transform.position, fwd[1], out hit)) 
				{
		 			Debug.DrawRay(dir[1].transform.position,fwd[1],Color.red);
							
					if (hit.collider.gameObject.tag == "Z")
		            {
		              	 Destroy(hit.transform.gameObject);
		            }
				}
				if (Physics.Raycast (dir[2].transform.position, fwd[2], out hit)) 
				{
		 			Debug.DrawRay(dir[2].transform.position,fwd[2],Color.red);
							
					if (hit.collider.gameObject.tag == "Z")
		            {
		              	 Destroy(hit.transform.gameObject);
		            }
				}
        	 currentTimeToShoot = 0.0f;
		}
	}
}
