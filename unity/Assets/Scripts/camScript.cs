using UnityEngine;
using System.Collections;

public class camScript : MonoBehaviour {

	public enum camView
		{
			thirdPerson,
			birdsEye
		}

	GameObject player;
	//FPC controller;
	public camView view;
	public float mouseSensitivity = 2.0f;
	float vertRot = 0;
	public float upDownRange = 40.0f;
	Vector3 mouse;


	void Start()
	{
		player = GameObject.Find ("Player");
//		controller = player.GetComponent<FPC> ();
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
		gameObject.GetComponent<Camera>().enabled = true;

		float yaw = Input.GetAxis ("Mouse X") * mouseSensitivity;
		player.transform.Rotate (0, yaw, 0);
		vertRot -= Input.GetAxis ("Mouse Y") * mouseSensitivity;

		vertRot = Mathf.Clamp (vertRot, -upDownRange, upDownRange);
		transform.localRotation = Quaternion.Euler (vertRot, 0, 0);
	}

	void BirdsEye()
	{
		gameObject.GetComponent<Camera>().enabled = false;
	}


	public void changeView()
	{
		if (view == camView.thirdPerson)
			view = camView.birdsEye;

		else if (view == camView.birdsEye)
		{
			view = camView.thirdPerson;
			print ("switch back");
		}

	}





}
