using UnityEngine;
using System.Collections;

public class pageManager : MonoBehaviour {

	public pageCam pageCamManager;
	//public AudioClip voiceOver;

 	void Start()
	{
		pageCamManager = GameObject.Find ("CameraManager").GetComponent<pageCam>();
	}


	void OnTriggerEnter()
	{
		triggerFunc (gameObject.name);
	}

	void OnTriggerExit()
	{
		triggerUnFunc (gameObject.name);
	}
	
	public void triggerFunc(string page)
	{
		switch (page) 
		{
		case "Page One":
			pageCamManager.TurnCamOn(1); // Tell pageCam.cs to turn on Camera One
			//AudioSource.PlayClipAtPoint(voiceOver, gameObject.transform.position, 0.5f);
			break;
		
		case "Page Two":
			pageCamManager.TurnCamOn(2); // Tell pageCam.cs to turn on Camera Two
			//AudioSource.PlayClipAtPoint(voiceOver, gameObject.transform.position, 0.5f);
			break;

		case "Page Three":
			pageCamManager.TurnCamOn(3); // Tell pageCam.cs to turn on Camera Three
			//AudioSource.PlayClipAtPoint(voiceOver, gameObject.transform.position, 0.5f);
			break;

		case "Page Four":
			pageCamManager.TurnCamOn(4); // Tell pageCam.cs to turn on Camera Four
			//AudioSource.PlayClipAtPoint(voiceOver, gameObject.transform.position, 0.5f);
			break;

		case "Page Five":
			pageCamManager.TurnCamOn(5); // Tell pageCam.cs to turn on Camera Four
			//AudioSource.PlayClipAtPoint(voiceOver, gameObject.transform.position, 0.5f);
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

		case "Page Five":
			pageCamManager.TurnCamOff(5); // Tell pageCam.cs to turn off Camera Four
			break;
		}
	}

}
