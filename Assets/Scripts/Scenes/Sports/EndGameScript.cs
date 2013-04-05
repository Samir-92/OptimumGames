using UnityEngine;
using System.Collections;

public class EndGameScript : MonoBehaviour {

	
    public float timer;
    public float minutes;
    public float seconds ;
    public GUIStyle myStyle;
    
    public float gameStartTime=0.0f;
    
    public GameObject win;
    public GameObject ab;
    public GameObject bc;
    public GameObject c;
    public GameObject f;
    
    public bool end = false;
    
    // Use this for initialization
    void Start () {
		
    }
     
    // Update is called once per frame
    void Update () 
	{
		
		if(end == false)
		{	 
			 timer += Time.deltaTime;
		}
		else{gameStartTime-=Time.deltaTime;}
		
		if(gameStartTime<=-4.0f)
			{
				Application.LoadLevel(1);	
			}	

    }
    
     void EndGame()
	{
		GameObject nd = GameObject.Find("NeverDie");
		DontDie d = nd.GetComponent<DontDie>();
		
		win.active=true;
		if (timer > 25)
			f.active=true;
			if (timer <= 25 && timer > 21)
			{
			c.active=true;
			d.dscore++;
			}
			if (timer <=21 && timer > 18)	
			{
			bc.active=true;
			d.dscore++;

			}
			if  (timer <18)
			{
			ab.active=true;	
			d.dscore++;

			}
	}

    void OnGUI() 
	{
  	 int minutes = Mathf.FloorToInt(timer / 60F);
   	 int seconds = Mathf.FloorToInt(timer - minutes * 60);
     
   	 string niceTime = string.Format("{0:00}:{1:00}", minutes, seconds);
    
		
    	 GUI.Label(new Rect(10,10,250,100), niceTime, myStyle);
	}

	
	void OnTriggerEnter(Collider other)
	{
		if(other.gameObject.transform.tag == "Player")
		{
			end = true;
			EndGame();
					}
					
	if(other.gameObject.transform.tag == "Enemy")
					{
						Destroy(other.gameObject);
					}

	}
}
