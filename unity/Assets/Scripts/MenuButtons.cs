using UnityEngine;
using System.Collections;

public class MenuButtons : MonoBehaviour {

	[SerializeField]GameObject cam;

	void OnMouseDown()
	{
		switch(gameObject.name)
		{
		case "Start":
			Application.LoadLevel(1);
			break;

		case "Back":
			cam.SendMessage("MoveCam", "Back");
			break;

		case "Instructions":
			cam.SendMessage("MoveCam", "Instruct");
			break;
		
		}
	}
}
