using UnityEngine;
using System.Collections;

public class Credits : MonoBehaviour {
public float time = 30.0f;

	// Use this for initialization
	void Start () {
	audio.Play();
	}
	
	// Update is called once per frame
	void Update () {
		if(time>4.0f)
		{
		time-=Time.deltaTime;
		}	
		if(time>10.3)
		{
	transform.Translate(new Vector3(0.0f,0.0f,-2.0f*Time.deltaTime));
		}
	if(time<=4.0f)
	{audio.Stop();
	}
	}
	
}
