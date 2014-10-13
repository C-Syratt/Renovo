using UnityEngine;
using System.Collections;

public class SecondPuzzle : MonoBehaviour {


	void OnTriggerEnter(Collider other)
	{
		other.SendMessage("TorchOff");
	}

	void OnTriggerExit(Collider other)
	{
		other.SendMessage("TorchOn");
	}

}
