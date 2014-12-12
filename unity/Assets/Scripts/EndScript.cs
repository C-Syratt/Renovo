using UnityEngine;
using System.Collections;

public class EndScript : MonoBehaviour {

	// for the player finding the exit
	void OnTriggerEnter (Collider other)
	{
		if (other.name == "Player") 
		{
			other.SendMessage("ActivateExit");
		}
	}
}
