using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class ComboTrigger : MonoBehaviour {

	public List<GameObject> objInTrigger = new List<GameObject>();

	bool correctCombo = false;

	// Objects attached to each dial that are used to check if dials are aligned
	public GameObject dial1; 
	public GameObject dial2;
	public GameObject dial3;

	void Start()
	{
		dial1 = GameObject.Find ("Dial1 Correct");
		dial2 = GameObject.Find ("Dial2 Correct");
		dial3 = GameObject.Find ("Dial3 Correct");
	}


	void Update()
	{
		// if each dial checker(obj) is in the Trigger
		if (correctCombo == false && objInTrigger.Contains (dial1) && objInTrigger.Contains (dial2) && 
		    objInTrigger.Contains (dial3)) 
		{
			// Combo = Correct and activate EndGame func
			correctCombo = true;
			EndGame();
		}
	}


	public void OnTriggerEnter(Collider other)
	{
		// Adds each object inside trigger to a list
		GameObject go = other.gameObject;
		if(!objInTrigger.Contains(go))// making sure obj is not already in the list
		{
			objInTrigger.Add(go);
		}
	}

	void OnTriggerExit(Collider other)
	{
		// Remove Object from list of collisions
		GameObject go = other.gameObject;
		objInTrigger.Remove(go);
	}

	void EndGame()
	{
		// send message to parent object (DialPuzzle.cs)
		SendMessageUpwards ("Win");
	}


}
