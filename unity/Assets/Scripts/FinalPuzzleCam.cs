using UnityEngine;
using System.Collections;

public class FinalPuzzleCam : MonoBehaviour {

	public GameObject finalCam;

	public GameObject[] text;

	void OnTriggerEnter(Collider col)
	{
		finalCam.SetActive (true);
		text[0].SetActive (true);
		text[1].SetActive (true);
		col.SendMessage("ActivateFinale");
	}
}
