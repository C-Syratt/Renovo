using UnityEngine;
using System.Collections;

public class camScript : MonoBehaviour {

	public enum camView
		{
			thirdPerson,
			birdsEye
		}

	GameObject player;

	[SerializeField] float distanceAway;
	[SerializeField] float distanceUp;
	Transform follow;
	[SerializeField]Vector3 camTarg;
	[SerializeField] float smooth;
	
	//Vector3 targV; // Target Vector
	float minDistAway = 1.5f;
	float maxDistAway = 2.5f;
	float zoomAmount;

	public camView view;
	public float mouseSensitivity = 2.0f;
	//float vertRot = 0;
	public float upDownRange = 40.0f;
	//Vector3 mouse;


	void Start()
	{
		player = GameObject.Find ("Player");
		follow = GameObject.FindGameObjectWithTag("Player").transform;
//		controller = player.GetComponent<FPC> ();
	}

	void LateUpdate()
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
//		vertRot -= Input.GetAxis ("Mouse Y") * mouseSensitivity;
//		vertRot = Mathf.Clamp (vertRot, -upDownRange, upDownRange);

		distanceAway += -Input.GetAxis ("Mouse ScrollWheel");
		distanceAway = Mathf.Clamp (distanceAway, minDistAway, maxDistAway);

		camTarg = follow.position + follow.up * distanceUp - follow.forward * distanceAway;
		WallColl(follow.position, ref camTarg);
		transform.position = Vector3.Lerp (transform.position, camTarg, Time.deltaTime * smooth);

		transform.LookAt (follow);
		//transform.localRotation = Quaternion.Euler (vertRot, 90, 0);
	
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
		}

	}

	void WallColl(Vector3 fromObj, ref Vector3 toTarg)
	{
		Debug.DrawLine (fromObj, toTarg, Color.cyan);
		
		RaycastHit wallHit = new RaycastHit();
		if (Physics.Linecast(fromObj, toTarg, out wallHit))
		{
			toTarg = new Vector3(wallHit.point.x, toTarg.y, wallHit.point.z);
		}
	}




}
