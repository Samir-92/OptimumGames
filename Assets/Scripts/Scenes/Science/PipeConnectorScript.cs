using UnityEngine;
using System.Collections;

public class PipeConnectorScript : MonoBehaviour {
	
	public bool connected;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnTriggerStay(Collider other)
	{
		if(other.gameObject.transform.name == "Block" || other.gameObject.transform.name == "StartBlock" || other.gameObject.transform.name == "EndBlock")
		{
			connected = true;
		}
	}
	
	void OnTriggerExit(Collider other)
	{
		connected = false;
	}
}
