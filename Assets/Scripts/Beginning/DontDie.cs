using UnityEngine;
using System.Collections;

public class DontDie : MonoBehaviour {
public int ascore = 0;
public int bscore = 0;
public int cscore = 0;
public int dscore = 0;

public GameObject die;
int level;

void Awake() {
	
    DontDestroyOnLoad(this.gameObject);
   }

// Use this for initialization
	void Start () {
		level = Application.loadedLevel;
	}
	
	// Update is called once per frame
	void Update () {
	if(ascore>=1 && cscore >=1 && bscore >=1 && dscore >=1)
	{
		if(Application.loadedLevelName == "Campus")
		{
		Application.LoadLevel(6);
		}
	}
	}
}
