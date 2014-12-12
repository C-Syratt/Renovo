using UnityEngine;
using System.Collections;

public class text : MonoBehaviour {

	  /*
		THE MAJORITY OF THIS SCRIPT IS NOT MY WORK,
		HOWEVER I INCLUDED IT ANYWAY AS IT WAS IN THE FINAL BUILD
		(I point out which sections I wrote, any other than those is not my work)
	  */


	public TextMesh dispText;

	[SerializeField] bool fadeIn = false;
	[SerializeField] bool maxFadeIn = false;
	[SerializeField] bool fadeOut = false;
	[SerializeField] float counter;
	[SerializeField] float timer = 5.0f;
	float fadeSpeed = 0.01f;
	float minAlpha = 0.0f;
	float maxAlpha = 1.0f;
	Color color;
		
	void Awake()
	{
		color = renderer.material.color;
		color.a = minAlpha;
	}
	
	void Update()
	{   
		renderer.material.color = color;
		
		if(fadeIn && !fadeOut)
		{
			FadeIn ();
		}
		
		if(fadeOut && !fadeIn)
		{
			FadeOut ();
		}

		if(maxFadeIn)
		{
			counter += Time.deltaTime;
			if (counter > timer)
			{
				maxFadeIn = false;
				fadeOut = true;
				counter = 0;
			}
		}
		// so shit and stuff
		if(color.a <= minAlpha)
		{
			fadeOut = false;
		}
		
		if(color.a >= maxAlpha)
		{
			if (fadeIn)
				maxFadeIn = true;

			fadeIn = false;
		}
	}
	
	public void DisplayText(string txt) //<- I wrote this Function
	{
		fadeIn = true;
		dispText.text = ResolveTextSize(txt,25);
	}

	public void DisplaySpecialText(string txt) // <- and this one
	{
		fadeIn = true;
		dispText.text = ResolveTextSize(txt,30);
	}

	void FadeIn()
	{
		color.a += fadeSpeed;
	}

	void FadeOut()
	{
		color.a -= fadeSpeed;
	}

	// Wrap text by line height
	private string ResolveTextSize(string input, int lineLength){
		
		// Split string by char " "       
		string[] words = input.Split(" "[0]);
		
		// Prepare result
		string result = "";
		
		// Temp line string
		string line = "";
		
		// for each all words        
		foreach(string s in words){
			// Append current word into line
			string temp = line + " " + s;
			
			// If line length is bigger than lineLength
			if(temp.Length > lineLength){
				
				// Append current line into result
				result += line + "\n";
				// Remain word append into new line
				line = s;
			}
			// Append current word into current line
			else {
				line = temp;
			}
		}
		
		// Append last line into result      
		result += line;
		
		// Remove first " " char
		return result.Substring(1,result.Length-1);
	}




}
