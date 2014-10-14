using UnityEngine;
using System.Collections;

public class MenuCam : MonoBehaviour {

	[SerializeField]float camSpeed;
		
	Vector3 newPos;
	Vector3 mainPos = new Vector3(26f,0.25f,2.12f);
	Vector3 controlPos = new Vector3(26f,7.61f,-0.5771289f);

	
	void Start () 
	{
		newPos = mainPos;
	}
	
	void Update () 
	{
		transform.position = Vector3.MoveTowards(transform.position, newPos, camSpeed * Time.deltaTime);
	}
	
	void MoveCam(string buttonPressed)
	{
		switch (buttonPressed) 
		{
		case "Instruct":
			newPos = controlPos;
			break;
			
		case "Credits":
			//
			break;
			
		case "Back":
			newPos = mainPos;
			break;
			
		}
	}
}
