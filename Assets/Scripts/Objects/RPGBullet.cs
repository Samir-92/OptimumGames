using UnityEngine;
using System.Collections;

public class RPGBullet : MonoBehaviour {
	
    float speed = 25.0f;
    float lifetime = 2.5f;
	// Use this for initialization
	void Start () {
	this.gameObject.renderer.material.color = Color.blue;
	}
	
	// Update is called once per frame
	void Update () {
		
	 transform.Translate(Vector3.forward * speed * Time.deltaTime);

     Destroy(this.gameObject, lifetime);

	}
	
	 public void OnCollisionEnter(Collision hit)
    {
		Debug.Log("Hiitt");
        if (hit.gameObject.tag == "Z")
        {
            hit.gameObject.active = false;		
//			hit.gameObject.transform.localPosition = em.startP;
        }
		 Destroy(this.gameObject);
	}
}
