using UnityEngine;
using System.Collections;

public class MathsScript : MonoBehaviour {

	public int number1;
	public int number2;
	public int answer;
	
	public int number3;
	public int number4;
	public int answer2;
	
	public int number5;
	public int number6;
	public int answer3;
	
	public int number7;
	public int number8;
	public int answer4;
	
	public int number9;
	public int number10;
	public int answer5;
	
	public int step=0;
	
	public string input = "";
	public string display;
	
	public int countQ=5;
	
	public Transform pos;
	public Transform pos2;
	public Transform pos3;
	public Transform pos4;
	public Transform pos5;
	
	public GameObject win;
	
	public GameObject q1Danger;
	public GameObject q2Danger;
	public GameObject q3Danger;
	public GameObject q4Danger;
	public GameObject q5Danger;
		
	public Vector3 Screenpos;
	public Vector3 Screenpos2;
	public Vector3 Screenpos3;
	public Vector3 Screenpos4;
	public Vector3 Screenpos5;
	
	public string trueAnswer;
	public string trueAnswer2;
	public string trueAnswer3;
	public string trueAnswer4;
	public string trueAnswer5;
	
	public GUIStyle chalk;
	public GUIStyle digital;
	public GUIStyle totalScore;
	public GUIStyle warning;
	
	public bool q1 = false;
	public bool q2 = false;
	public bool q3 = false;
	public bool q4 = false;
	public bool q5 = false;
	
	public float startTime=0;
	public float endTime=60;
	public float qEndTime=2;
	public float qDangerTime=4;
	public float qFailedTime=3;
	public float timer=0;
	
	public float q1eTime = 0;
	public float q1sTime = 0;
	public float q1fTime = 0;
	
	public float q2eTime = 0;
	public float q2sTime = 0;
	public float q2fTime = 0;
	
	public float q3eTime = 0;
	public float q3sTime = 0;
	public float q3fTime = 0;
	
	public float q4eTime = 0;
	public float q4sTime = 0;
	public float q4fTime = 0;
	
	public float q5eTime = 0;
	public float q5sTime = 0;
	public float q5fTime = 0;
	
	public int score = 0;
	public int correct = 10;
	
	public GameObject aScore;
	public GameObject bScore;
	public GameObject cScore;
	public GameObject fScore;
	
	public GameObject[] clock = new GameObject[14];
	
	void Start () 
	{
		CreateQ1();
		CreateQ2();
		CreateQ3();
		CreateQ4();
		CreateQ5();
	}
	
	void CheckAnswer()
	{
		/*if (answer2==answer)
		{
			CreateQ2();	
			countQ++;
		}
		if (answer3==answer || answer3 ==answer2)
		{
			CreateQ3();	
			countQ++;
		}
		if (answer4==answer || answer4 ==answer2 || answer4==answer3)
		{
			CreateQ4();	
			countQ++;
		}
		if (answer5==answer || answer5 ==answer2 || answer5==answer3 || answer5==answer4)
		{
			CreateQ5();	
			countQ++;
		}*/

	}
	////
	void Update () 
	{
		startTime+=Time.deltaTime;
		
		if(startTime>=endTime)
		{
			win.active=true;
			startTime=0;
			
		}
		
		if (win.active==true)
		{
			if(startTime>4)
			{
				Application.LoadLevel(0);	
			}	
		}
		
		CheckAnswer();
		if(Input.inputString!=null)
		{
			int a;
			if(int.TryParse(Input.inputString,out a))
			{
				input += Input.inputString;
			}
		}
		
		if (input!="")
		{
			display = input;
		}

		
		if(input==answer.ToString())
		{
			pos.active=false;
			input="";	
			countQ++;	
			answer=-1000;
			q1=false;
			score+=correct;
		}	
		if (input==answer2.ToString())
		{
			pos2.active=false;
			input="";		
			countQ++;	
			answer2=-1000;
			q2=false;
			score+=correct;
		}	
		if(input==answer3.ToString())
		{
			pos3.active=false;
			input="";
			countQ++;	
			answer3=-1000;	
			q3=false;
			score+=correct;
		}	
		if (input==answer4.ToString())
		{
			pos4.active=false;
			input="";	
			countQ++;	
			answer4=-1000;	
			q4=false;
			score+=correct;
		}	
		if (input==answer5.ToString())
		{
			pos5.active=false;
			input="";	
			countQ++;
			answer5=-1000;		
			q5=false;
			score+=correct;
		}	
		
		if (countQ > 3)
		{
			if(q1==false)
			{
				CreateQ1();	
			}
			else if(q2==false)
			{
				CreateQ2();	
			}
			else if(q3==false)
			{
				CreateQ3();	
			}
			else if(q4==false)
			{
				CreateQ4();	
			}
			else if(q5==false)
			{
				CreateQ5();	
			}
		}
		
		if(q1==true)
		{
			q1sTime+=Time.deltaTime;
			if (q1sTime>=qDangerTime)
			{
				//set text red
				//q1Danger.active=true;		
						
				q1fTime+=Time.deltaTime;
				if (q1fTime>=qFailedTime)
				{
					pos.active=false;
					input="";	
					countQ++;	
					answer=-1000;
					q1=false;
					q1sTime=0.0f;
					q1fTime=0.0f;
				}
			}	
		}
		if(q2==true)
		{
			q2sTime+=Time.deltaTime;
			if (q2sTime>=qDangerTime)
			{
				//set text red
				//q2Danger.active=true;
				q2fTime+=Time.deltaTime;
				if (q2fTime>=qFailedTime)
				{
					pos2.active=false;
					input="";	
					countQ++;	
					answer2=-1000;
					q2=false;
					q2sTime=0.0f;
					q2fTime=0.0f;
				}
			}	
		}
		if(q3==true)
		{
			q3sTime+=Time.deltaTime;
			if (q3sTime>=qDangerTime)
			{
				//set text red
				//q3Danger.active=true;
				q3fTime+=Time.deltaTime;
				if (q3fTime>=qFailedTime)
				{

					pos3.active=false;
					input="";	
					countQ++;	
					answer3=-1000;
					q3=false;
					q3sTime=0.0f;
					q3fTime=0.0f;
				}
			}	
		}
		if(q4==true)
		{
			q4sTime+=Time.deltaTime;
			if (q4sTime>=qDangerTime)
			{
				//set text red
				//q4Danger.active=true;
				q4fTime+=Time.deltaTime;
				if (q4fTime>=qFailedTime)
				{
					pos4.active=false;
					input="";	
					countQ++;	
					answer4=-1000;
					q4=false;
					q4sTime=0.0f;
					q4fTime=0.0f;
				}
			}	
		}
		if(q5==true)
		{
			q5sTime+=Time.deltaTime;
			if (q5sTime>=qDangerTime)
			{
				//set text red
				//q5Danger.active=true;
				q5fTime+=Time.deltaTime;
				if (q5fTime>=qFailedTime)
				{
					pos5.active=false;
					input="";	
					countQ++;	
					answer5=-1000;
					q5=false;
					q5sTime=0.0f;
					q5fTime=0.0f;
				}
			}	
		}
		
		float timeStep = endTime/14;
		float timeElapsed = startTime;
		
		timer += Time.deltaTime;
		if (timer > timeStep)
		{
			timer=0;
			clock[step].active=false;
			clock[step+1].active=true;
			step++;	
		}

		
		if(q1==false)
		{
			//q1Danger.active=false;
			q1eTime+=Time.deltaTime;
			if (q1eTime>=qEndTime)
			{
				CreateQ1();	
				q1eTime=0.0f;
			}	
		}
		if(q2==false)
		{
			//q2Danger.active=false;
			q2eTime+=Time.deltaTime;
			if (q2eTime>=qEndTime)
			{
				CreateQ2();	
				q2eTime=0.0f;
			}	
		}
		if(q3==false)
		{
			//q3Danger.active=false;
			q3eTime+=Time.deltaTime;
			if (q3eTime>=qEndTime)
			{
				CreateQ3();	
				q3eTime=0.0f;
			}	
		}
		if(q4==false)
		{
			//q4Danger.active=false;
			q4eTime+=Time.deltaTime;
			if (q4eTime>=qEndTime)
			{
				CreateQ4();	
				q4eTime=0.0f;
			}	
		}
		if(q5==false)
		{
			//q5Danger.active=false;
			q5eTime+=Time.deltaTime;
			if (q5eTime>=qEndTime)
			{
				CreateQ5();	
				q5eTime=0.0f;
			}	
		}
		
		if(Input.GetMouseButtonDown(0)||Input.GetKeyDown("space"))
		{
			input="";
			display="";
		}
		
		
		Screenpos= camera.WorldToScreenPoint(pos.position);
		Screenpos2= camera.WorldToScreenPoint(pos2.position);
		Screenpos3= camera.WorldToScreenPoint(pos3.position);
		Screenpos4= camera.WorldToScreenPoint(pos4.position);
		Screenpos5= camera.WorldToScreenPoint(pos5.position);

		 
		trueAnswer= number1.ToString()+" + "+number2.ToString();
		trueAnswer2= number3.ToString()+" + "+number4.ToString();
		trueAnswer3= number5.ToString()+" + "+number6.ToString();
		trueAnswer4= number7.ToString()+" + "+number8.ToString();
		trueAnswer5= number9.ToString()+" + "+number10.ToString();
		
		
	}
	
	void OnGUI ()
	{
		if (win.active==false)
		{
			if (pos.active==true)
			GUI.Label(new Rect(Screenpos.x,Screen.height-Screenpos.y,400,400),trueAnswer,chalk);
			if (pos2.active==true)
			GUI.Label(new Rect(Screenpos2.x,Screen.height-Screenpos2.y,400,400),trueAnswer2,chalk);
			if (pos3.active==true)
			GUI.Label(new Rect(Screenpos3.x,Screen.height-Screenpos3.y,400,400),trueAnswer3,chalk);
			if (pos4.active==true)
			GUI.Label(new Rect(Screenpos4.x,Screen.height-Screenpos4.y,400,400),trueAnswer4,chalk);
			if (pos5.active==true)
			GUI.Label(new Rect(Screenpos5.x,Screen.height-Screenpos5.y,400,400),trueAnswer5,chalk);
		
			GUI.Label(new Rect(Screen.width-200,Screen.height-130,100,50),display.ToString(),digital);
			
			GUI.Label(new Rect(Screen.width-200,Screen.height/2,300,150),"Score",totalScore);
			GUI.Label(new Rect(Screen.width-150,Screen.height/2+50,300,150),score.ToString(),totalScore);

			GUI.Label(new Rect(Screen.width-250,Screen.height-270,250,50),"Press space to clear the calculator!",warning);
		}
		if (win.active==true)
		{
			if (score < 50)
			fScore.active=true;
			if (score >= 50 && score <120)
			cScore.active=true;
			if (score >= 120 && score < 200)	
			bScore.active=true;
			if  (score > 200)
			aScore.active=true;	
		}
		
		
	}
	
	void CreateQ1()
	{
		number1=Random.Range(1,9);
		number2=Random.Range(0,9);
		
		answer=number1+number2;
		q1=true;
		countQ--;
		pos.active=true;
	}
	
	void CreateQ2()
	{
		number3=Random.Range(1,9);
		number4=Random.Range(0,9);
		
		answer2=number3+number4;
		q2=true;
		countQ--;
		pos2.active=true;
	}
	
	void CreateQ3()
	{
		number5=Random.Range(1,9);
		number6=Random.Range(0,9);
		
		answer3=number5+number6;
		q3=true;
		countQ--;
		pos3.active=true;
	}
	
	void CreateQ4()
	{
		number7=Random.Range(1,9);
		number8=Random.Range(0,9);
		
		answer4=number7+number8;
		q4=true;
		countQ--;
		pos4.active=true;
	}
	
	void CreateQ5()
	{
		number9=Random.Range(1,9);
		number10=Random.Range(0,9);
		
		answer5=number9+number10;
		q5=true;
		countQ--;
		pos5.active=true;
	}
}
