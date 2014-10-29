using UnityEngine;
using System.Collections;

public class Troll : MonoBehaviour {

	void OnTriggerEnter()
	{
		Application.LoadLevel (2);
	}
}
