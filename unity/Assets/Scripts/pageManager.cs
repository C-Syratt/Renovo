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
		print ("text 'n' shit to read yo");
		triggerFunc (gameObject.name);
	}

	public void triggerFunc(string page)
	{
		switch (page) 
		{
		case "Page One":
			pageCamManager.TurnCamOn("CamOne"); // Tell pageCam.cs to turn on Camera One
			break;
		}
	}

}
