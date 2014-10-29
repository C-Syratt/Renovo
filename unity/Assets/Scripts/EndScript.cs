using UnityEngine;
using System.Collections;

public class EndScript : MonoBehaviour {


	void OnTriggerEnter (Collider other)
	{
		if (other.name == "Player") 
		{
			other.SendMessage("ActivateExit");
		}
	}


	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
