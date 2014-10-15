using UnityEngine;
using System.Collections;

public class SecondPuzzle : MonoBehaviour {

	public Color oriCol;
	public Color newCol;
	
	void OnTriggerEnter(Collider other)
	{
		other.SendMessage("TorchOff");
		RenderSettings.ambientLight = newCol;
	}

	void OnTriggerExit(Collider other)
	{
		other.SendMessage("TorchOn");
		RenderSettings.ambientLight = oriCol;
	}

	void DeActivate()
	{
		RenderSettings.ambientLight = oriCol;
		gameObject.SetActive (false);
	}

}
