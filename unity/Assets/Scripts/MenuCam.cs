using UnityEngine;
using System.Collections;

public class MenuCam : MonoBehaviour {

	[SerializeField]float camSpeed;

	Vector3 newPos;

	// I apparently like hard coding things...
	Vector3 mainPos = new Vector3(26f,0.25f,2.12f);
	Vector3 controlPos = new Vector3(26f,7.61f,-0.5771289f);
	
	void Start () 
	{
		newPos = mainPos;
		Screen.lockCursor = false;
	}
	
	void Update () 
	{
		// move camera to active position
		transform.position = Vector3.MoveTowards(transform.position, newPos, camSpeed * Time.deltaTime);
		if(Input.GetKeyDown(KeyCode.Escape))
			Application.Quit();
	}
	
	void MoveCam(string buttonPressed)
	{
		switch (buttonPressed) 
		{
		
		case "Instruct":
			newPos = controlPos; // Set Active position to control screen
			break;
			
		case "Back":
			newPos = mainPos; // Set Active position to main screen
			break;
			
		}
	}
}
