﻿using UnityEngine;
using System.Collections;

public class FinalPuzzleCam : MonoBehaviour {

	public GameObject finalCam;
	public FPC player;


	public GameObject[] text;

	void Update()
	{
		if (player.playState == FPC.playerState.grandFinale)
		{
			DisableCam ();
		}
	}


	void OnTriggerEnter(Collider col)
	{
		finalCam.SetActive (true);
		text[0].SetActive (true);
		text[1].SetActive (true);
		col.SendMessage("ActivateFinale");
	}

	void DisableCam()
	{
		finalCam.SetActive (false);
		text[0].SetActive (false);
		text[1].SetActive (false);
		text[2].SetActive (true);
		text[3].SetActive (true);
		text[4].SetActive (true);
	}


}
