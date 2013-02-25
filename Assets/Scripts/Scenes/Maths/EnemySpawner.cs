using UnityEngine;
using System.Collections;

public class EnemySpawner : MonoBehaviour {
	
	public GameObject enemy;
	public float curTimeToSpawn = 0.0f;
    public float timeToSpawn = 2.0f;
	
	// Use this for initialization
	void Start () {
			
	}
	
	// Update is called once per frame
	void Update () {
		curTimeToSpawn += Time.deltaTime;
		GameObject[] enem = GameObject.FindGameObjectsWithTag("Z");
	if(enem.Length < 10)
		{
		if(curTimeToSpawn > timeToSpawn)
		{
			Instantiate(enemy, transform.position, Quaternion.identity);
			curTimeToSpawn = 0.0f;
		}
	}
}
}
