using UnityEngine;
using System.Collections;

public class DialPuzzle : MonoBehaviour 
{
	public GameObject[] dialList; // List of Dials
	public GameObject selectedDial;
	public float rotSpeed; // Rotation Speed
	public int dialNum = 0; // Dial Number

	public FPC player; // Player Script

	// Colours for showing player what dial is/isn't selected
	public Color selectedColor;
	public Color originalColor;

	public void Start()
	{
		// First Dial is selected by default
		selectedDial = dialList[0];
		originalColor = dialList[1].renderer.material.color;

		// Start each dial at a random rotation
		for (int i = 0; i < dialList.Length; i++) 
		{
			dialList[i].gameObject.transform.Rotate(0, Random.Range(0,306),0);
		}
	}

	public void Update()
	{
		// if Finale is activated
		if(player.playState == FPC.playerState.finale)
		{
			if (Input.GetKey (KeyCode.LeftArrow))
			{RotateLeft ();}

			if (Input.GetKey (KeyCode.RightArrow))
			{RotateRight ();}

			if (Input.GetKeyDown (KeyCode.UpArrow))
			{ChangeUp ();}

			if (Input.GetKeyDown (KeyCode.DownArrow))
			{ChangeDown ();}

			// change selected dial's colour
			selectedDial.renderer.material.color = selectedColor;


			// Making sure the not selected dials are returned to their original colours
			for (int i = 0; i < dialList.Length; i++) 
			{
				if (i != dialNum)
				{
					dialList[i].renderer.material.color = originalColor;
				}
			}
		}
	}

	void RotateLeft()
	{
		selectedDial.gameObject.transform.Rotate (new Vector3 (0, -1, 0) * rotSpeed);
	}

	void RotateRight()
	{
		selectedDial.gameObject.transform.Rotate (new Vector3 (0, 1, 0) * rotSpeed);
	}

	void ChangeUp()
	{
		// checking if at Begining of list
		if (selectedDial == dialList[0])
		{
			selectedDial = dialList [2];	
			dialNum = 2;
		}
		// otherwise Select next dial
		else
		{
			selectedDial = dialList [dialNum - 1];
			dialNum--;
		}
	}

	void ChangeDown()
	{
		// Checking if at end of List
		if (selectedDial == dialList[2])
		{
			selectedDial = dialList [0];	
			dialNum = 0;
		}
		// otherwise Select next dial
		else
		{
			selectedDial = dialList [dialNum + 1];
			dialNum++;
		}
	}

	void Win()
	{
		player.playState = FPC.playerState.grandFinale;
		player.cam.changeView ();
	}

}
