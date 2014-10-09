using UnityEngine;
using System.Collections;

public class Tomes : MonoBehaviour 
{
	void OnTriggerEnter(Collider col)
	{
		switch (gameObject.name)
		{
		case "Tome One":
			col.gameObject.SendMessage("CanJump");
			break;
		case "Tome Two":
			break;
		case "Tome Three":
			break;
		}

	}

}
