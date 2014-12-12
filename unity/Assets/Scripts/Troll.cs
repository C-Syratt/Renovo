using UnityEngine;
using System.Collections;

public class Troll : MonoBehaviour {

	// This script is attached to triggers at the top of the walls in the world
	// if the player "mountain goats" up the walls, they get teleported to the old level
	// and we all know how exciting that is

	float t = 5;
	float c;
	bool triggered = false;

	void OnTriggerEnter()
	{
		triggered = true;
	}

	void Update()
	{
		// begin timer if triggered
		if(triggered == true)
		{
			c += Time.deltaTime;
			if(c >= t)
			{
				ByeBye();
			}
		}

	}

	void ByeBye()
	{
		// load old level
		Application.LoadLevel (2);
	}
}
