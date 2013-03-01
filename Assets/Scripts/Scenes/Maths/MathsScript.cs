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
	
	public string input = "";
	
	public Transform pos;
	public Transform pos2;
	public Transform pos3;
	public Transform pos4;
	public Transform pos5;
	
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
	
	void Start () 
	{
		number1=Random.Range(1,9);
		number2=Random.Range(0,9);
		
		answer=number1+number2;
		
		number3=Random.Range(1,9);
		number4=Random.Range(0,9);
		
		answer2=number3+number4;
		
		number5=Random.Range(1,9);
		number6=Random.Range(0,9);
		
		answer3=number5+number6;
		
		number7=Random.Range(1,9);
		number8=Random.Range(0,9);
		
		answer4=number7+number8;
		
		number9=Random.Range(1,9);
		number10=Random.Range(0,9);
		
		answer5=number9+number10;
	}
	
	void Update () 
	{
		if(Input.inputString!=null)
		{
			int a;
			if(int.TryParse(Input.inputString,out a))
			{
				input += Input.inputString;
			}
		}
		
		if(input==answer.ToString())
		{
			pos.active=false;
			input="";		
		}	
		else if (input==answer2.ToString())
		{
			pos2.active=false;
			input="";		
		}	
		else if(input==answer3.ToString())
		{
			pos3.active=false;
			input="";		
		}	
		else if (input==answer4.ToString())
		{
			pos4.active=false;
			input="";		
		}	
		else if (input==answer5.ToString())
		{
			pos5.active=false;
			input="";		
		}	
		
		if(Input.GetMouseButtonDown(0))
		{
			input="";
		}
		
		if(Input.GetMouseButtonDown(1))
		{
			number1=Random.Range(0,9);
			number2=Random.Range(0,9);
		
			answer=number1+number2;
			
			number3=Random.Range(1,9);
			number4=Random.Range(0,9);
		
			answer2=number3+number4;
		
			number5=Random.Range(1,9);
			number6=Random.Range(0,9);
		
			answer3=number5+number6;
		
			number7=Random.Range(1,9);
			number8=Random.Range(0,9);
		
			answer4=number7+number8;
		
			number9=Random.Range(1,9);
			number10=Random.Range(0,9);
			
			answer5=number9+number10;
			
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
		if (pos.active==true)
		GUI.Label(new Rect(Screenpos.x,Screen.height-Screenpos.y,100,50),trueAnswer);
		if (pos2.active==true)
		GUI.Label(new Rect(Screenpos2.x,Screen.height-Screenpos2.y,100,50),trueAnswer2);
		if (pos3.active==true)
		GUI.Label(new Rect(Screenpos3.x,Screen.height-Screenpos3.y,100,50),trueAnswer3);
		if (pos4.active==true)
		GUI.Label(new Rect(Screenpos4.x,Screen.height-Screenpos4.y,100,50),trueAnswer4);
		if (pos5.active==true)
		GUI.Label(new Rect(Screenpos5.x,Screen.height-Screenpos5.y,100,50),trueAnswer5);
		GUI.Label(new Rect(10,60,100,50),input.ToString());
	}
}
