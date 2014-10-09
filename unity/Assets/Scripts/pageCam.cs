using UnityEngine;
using System.Collections;

public class pageCam : MonoBehaviour 
{
	public static pageCam pc;
	public GameObject camOne;
	public GameObject camTwo;
	public GameObject camThree;
	public GameObject camFour;
	
	void Start()
	{
		pc = gameObject.GetComponent<pageCam> ();
	}

	public void TurnCamOn(int camNum)
	{
		switch (camNum) 
		{
		case 1:
			camOne.SetActive(true);
			break;
		case 2:
			camTwo.SetActive(true);
			break;
		case 3:
			camThree.SetActive(true);
			break;
		case 4:
			camFour.SetActive(true);
			break;
		}
	}

	public void TurnCamOff(int camNum)
	{
		switch (camNum) 
		{
		case 1:
			camOne.SetActive(false);
			break;
		case 2:
			camTwo.SetActive(false);
			break;
		case 3:
			camThree.SetActive(false);
			break;
		case 4:
			camFour.SetActive(false);
			break;
		}
	}






}
