using UnityEngine;
using System.Collections;

public class pageManager : MonoBehaviour {

	public pageCam pageCamManager;

 	void Start()
	{
		pageCamManager = GameObject.Find ("CameraManager").GetComponent<pageCam>();
	}


	void OnTriggerEnter()
	{
		triggerFunc (gameObject.name);
		print ("Yo bitch read now");
	}

	void OnTriggerExit()
	{
		triggerUnFunc (gameObject.name);
		print ("stahp yo readin now");
	}
	
	public void triggerFunc(string page)
	{
		switch (page) 
		{
		case "Page One":
			pageCamManager.TurnCamOn(1); // Tell pageCam.cs to turn on Camera One
			break;
		
		case "Page Two":
			pageCamManager.TurnCamOn(2); // Tell pageCam.cs to turn on Camera Two
			break;

		case "Page Three":
			pageCamManager.TurnCamOn(3); // Tell pageCam.cs to turn on Camera Three
			break;

		case "Page Four":
			pageCamManager.TurnCamOn(4); // Tell pageCam.cs to turn on Camera Four
			break;
		}
	}

	public void triggerUnFunc(string page)
	{
		switch (page) 
		{
		case "Page One":
			pageCamManager.TurnCamOff(1); // Tell pageCam.cs to turn off Camera One
			break;
			
		case "Page Two":
			pageCamManager.TurnCamOff(2); // Tell pageCam.cs to turn off Camera Two
			break;
			
		case "Page Three":
			pageCamManager.TurnCamOff(3); // Tell pageCam.cs to turn off Camera Three
			break;
			
		case "Page Four":
			pageCamManager.TurnCamOff(4); // Tell pageCam.cs to turn off Camera Four
			break;
		}
	}

}
