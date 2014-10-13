using UnityEngine;
using System.Collections;

public class Tomes : MonoBehaviour 
{

	[SerializeField]public string trigName;

	void OnTriggerEnter(Collider col)
	{
		switch (trigName)
		{
		case "Tome_1":
			col.gameObject.SendMessage("CanJump");
			break;
		case "Tome_2":
			col.gameObject.SendMessage("SecondPuzzle");
			break;
		case "Tome_3":
			break;
		}

	}

}
