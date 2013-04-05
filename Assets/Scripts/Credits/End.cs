using UnityEngine;
using System.Collections;

public class End : MonoBehaviour {
public Credits c;
public Texture2D op;
bool pic;
public bool sound;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	if(c.time <9)
	{
		pic = true;
	}
	
	if(c.time <= 4.0f)
	{
	
		Application.Quit();
	}
	}
	void OnGUI()
	{
		if(pic==true)
		{
		GUI.DrawTexture(new Rect(0,0,Screen.width+2.0f,Screen.height),op);
		}
		}
}
