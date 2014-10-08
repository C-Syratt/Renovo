using UnityEngine;
using System.Collections;

public class camScript : MonoBehaviour {

	public enum camView
		{
			thirdPerson,
			birdsEye
		}

	public GameObject player;
	public camView view;
	public float mouseSensitivity = 2.0f;
	float vertRot = 0;
	public float upDownRange = 50.0f;

	void Start()
	{

	}

	void Update()
	{
		if (view == camView.thirdPerson)
			ThirdPerson ();

		else if (view == camView.birdsEye)
			BirdsEye ();

	}

	void ThirdPerson()
	{
		float yaw = Input.GetAxis ("Mouse X") * mouseSensitivity;
		player.transform.Rotate (0, yaw, 0);
		vertRot -= Input.GetAxis ("Mouse Y") * mouseSensitivity;
		// more shit about stuff
		vertRot = Mathf.Clamp (vertRot, -upDownRange, upDownRange);
		transform.localRotation = Quaternion.Euler (vertRot, 0, 0);
	}

	void BirdsEye()
	{

	}


	public void changeView()
	{
		if (view == camView.thirdPerson)
			view = camView.birdsEye;

		else if (view == camView.birdsEye)
			view = camView.thirdPerson;

	}





}
