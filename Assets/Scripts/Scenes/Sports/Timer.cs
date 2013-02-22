using UnityEngine;
using System.Collections;

public class Timer : MonoBehaviour {
	
    public float timer;
    float minutes;
    float seconds ;
    
    // Use this for initialization
    void Start () {
		
    }
     
    // Update is called once per frame
    void Update () 
	{
	  timer += Time.deltaTime;
    }
     
    void OnGUI() 
	{
  	 int minutes = Mathf.FloorToInt(timer / 60F);
   	 int seconds = Mathf.FloorToInt(timer - minutes * 60);
     
   	 string niceTime = string.Format("{0:00}:{1:00}", minutes, seconds);
    
		
    	 GUI.Label(new Rect(10,10,250,100), niceTime);
	}
}
