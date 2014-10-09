using UnityEngine;
using System.Collections;

public class pageCam : MonoBehaviour 
{
	public static pageCam pc;


	void Start()
	{
		pc = gameObject.GetComponent<pageCam> ();
	}

	public static void TurnCamOn(string camNum)
	{
		foreach(Transform child in transform)
		{
			if(child.name == camNum) //Camera One
			{
				child.gameObject.SetActive(true);
			}
			if(child.name == "CamTwo")
			{
				child.gameObject.SetActive(true);
			}
			if(child.name == "CamThree")
			{
				child.gameObject.SetActive(true);
			}
		}
	}





}
