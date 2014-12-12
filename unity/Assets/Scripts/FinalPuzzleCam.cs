using UnityEngine;
using System.Collections;

public class FinalPuzzleCam : MonoBehaviour {

	public GameObject finalCam; // Camera above the puzzle
	public FPC player; // Player Script
	bool triggered = false; // to stop players activating the puzzle again when it is completed
	
	public GameObject[] text; // 3d Text for Controls

	void Update()
	{
		// turn of puzzlecam if puzzle is completed
		if (player.playState == FPC.playerState.grandFinale)
		{
			DisableCam ();
		}
	}


	void OnTriggerEnter(Collider col)
	{
		if(triggered == false)
		{
			finalCam.SetActive (true); // Turn on Camera
			text[0].SetActive (true); // Turn on Control Text
			text[1].SetActive (true); // Turn on Camera
			col.SendMessage("ActivateFinale"); // Set player's state to Finale/lock out player movement
			triggered = true; // to make it this is not triggered again
		}
	}

	void DisableCam()
	{
		// turn shit off
		finalCam.SetActive (false);
		text[0].SetActive (false);
		text[1].SetActive (false);
		text[2].SetActive (true); // Particles for end sequence
		text[3].SetActive (true); // Particles for end sequence(on Player)
		text[4].SetActive (true); // Trigger for displaying text to player
	}


}
