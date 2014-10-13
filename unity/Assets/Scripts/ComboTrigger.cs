using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class ComboTrigger : MonoBehaviour {

	public List<GameObject> objInTrigger = new List<GameObject>();

	bool correctCombo = false;

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
		if (correctCombo == false && objInTrigger.Contains (dial1) && objInTrigger.Contains (dial2) && 
		    objInTrigger.Contains (dial3)) 
		{
			correctCombo = true;
			EndGame();
		}
	}

	public void OnTriggerEnter(Collider other)
	{
		GameObject go = other.gameObject;
		if(!objInTrigger.Contains(go))
		{
			objInTrigger.Add(go);
		}
	}

	void OnTriggerExit(Collider other)
	{
		GameObject go = other.gameObject;
		objInTrigger.Remove(go);
	}

	void EndGame()
	{
		SendMessageUpwards ("Win");
	}


}
