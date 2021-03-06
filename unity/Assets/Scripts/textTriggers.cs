﻿using UnityEngine;
using System.Collections;

public class textTriggers : MonoBehaviour {

	/*
		This Script is attached to multiple triggers
	 */

	[SerializeField] text txt;

	void OnTriggerEnter(Collider other)
	{
		if (other.name == "Player") // if player enters the trigger
		{
			ChangeText();
		}
	}

	void ChangeText()
	{
		// this function changes the text on the 3d text attached to the player camera
		// by passing a string into the text.cs script

		switch(gameObject.name)
		{
		case "Feel Weak":
			txt.DisplayText("You awake with no memory of previous events");
			Destroy(gameObject);
			break;

		case "Jump":
			txt.DisplayText("The Spell in the tome allows you to Jump");
			break;

		case "Dead End":
			txt.DisplayText("A dead end");
			break;

		case "Strong Wind":
			txt.DisplayText("A Magic field seems to dull light");
			break;

		case "Lift Spell":
			txt.DisplayText("The Magic Field lifts");
			break;

		case "Locked":
			txt.DisplayText("The Door cannot be opened from here");
			break;

		case "Trolloll Fields":
			txt.DisplayText("You shouldn't have come up here...");
			break;

		case "End":
			txt.DisplayText("You feel light headed as the spell begins to work");
			break;

		case "Exit":
			txt.DisplaySpecialText("You have resisted temptation. You are free from Renovo");
			break;

		}
	}




}
