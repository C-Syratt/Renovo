using UnityEngine;
using System.Collections;

public class Troll : MonoBehaviour {

	float t = 5;
	float c;
	bool triggered = false;

	void OnTriggerEnter()
	{
		triggered = true;
	}

	void Update()
	{
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
		Application.LoadLevel (2);
	}
}
