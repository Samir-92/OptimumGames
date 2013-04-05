using UnityEngine;
using System.Collections;

public class SplashScript : MonoBehaviour {

public Texture2D op;
public Texture2D pres;
public Texture2D uni;


public int plus = 0;
//public Audio s;
	// Use this for initialization
	//IEnumerator Start () {
	//yield return new WaitForSeconds(5.0f);
	
	//}
	
	// Update is called once per frame
	void Update () {
	
	if(!audio.isPlaying)
	{
		plus ++;
		audio.Play();
		}
	if(plus > 2)
	{Application.LoadLevel(1);
	}
	}
	
	void OnGUI()
	{
		if(plus == 0)
		{
		GUI.DrawTexture(new Rect(0,0,Screen.width+2.0f,Screen.height),op);
		}
		else if(plus == 1)
		{
			GUI.DrawTexture(new Rect(0,0,Screen.width+2.0f,Screen.height),pres);
			}
			else if(plus == 2)
		{
			GUI.DrawTexture(new Rect(0,0,Screen.width+2.0f,Screen.height),uni);
			}
	}
}
