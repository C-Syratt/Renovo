using UnityEngine;
using System.Collections;

public class camScript : MonoBehaviour {
	
	// for checking/switching between camera/s
	public enum camView
	{
		thirdPerson,
		birdsEye
	}

	public camView view;
	public float mouseSensitivity = 2.0f;

	[SerializeField] Vector3 camTarg;
	[SerializeField] float distanceAway; // Camera's distance away from target
	[SerializeField] float distanceUp;	// Camera's height above target
	[SerializeField] float smooth; // Camera speed

	GameObject player;
	Transform follow; // The point the camera looks at (attached to player)

	float minDistUp = -0.3f; // how far the player can look down
	float maxDistUp = 1.3f; // how far the player cam look up

	void Start()
	{
		// assign Player and Camera Target
		player = GameObject.Find ("Player");
		follow = GameObject.FindGameObjectWithTag("Player").transform;
	}

	void LateUpdate()
	{
		// check camera state, run corresponding functions
		if (view == camView.thirdPerson)
			ThirdPerson ();

		else if (view == camView.birdsEye)
			BirdsEye ();
	}

	void ThirdPerson()
	{
		// make sure the camera component is switched on
		if(gameObject.GetComponent<Camera>().enabled == false)
			{gameObject.GetComponent<Camera>().enabled = true;}

		// mapping yaw value to Mouse input && rotating player with yaw value
		float yaw = Input.GetAxis ("Mouse X") * mouseSensitivity;
		player.transform.Rotate (0, yaw, 0);

		// mapping looking up/down to mouse wheel && and clamping it
		distanceUp += -Input.GetAxis ("Mouse ScrollWheel");
		distanceUp = Mathf.Clamp (distanceUp, minDistUp, maxDistUp);

		// Setting camera's position away from player/target
		camTarg = follow.position + follow.up * distanceUp - follow.forward * distanceAway;
		WallColl(follow.position, ref camTarg);// accounting for wall collisions

		// moving camera to set position
		transform.position = Vector3.Lerp (transform.position, camTarg, Time.deltaTime * smooth);
		transform.LookAt (follow); // look at camera's target

	}

	void BirdsEye()
	{
		gameObject.GetComponent<Camera>().enabled = false;
		/* NOTE: 
		 * A script elsewhere turns on another camera,
		 * This script turns off the player camera to make the other camera the one the player sees with
		 */
	}
	
	public void changeView()
	{
		// made this the one function rather than two different funcs
		if (view == camView.thirdPerson)
		{
			view = camView.birdsEye;
		}

		else if (view == camView.birdsEye)
		{
			view = camView.thirdPerson;
		}

	}

	void WallColl(Vector3 fromObj, ref Vector3 toTarg)
	{
		Debug.DrawLine (fromObj, toTarg, Color.cyan); // for Scene view purposes
		
		RaycastHit wallHit = new RaycastHit();
		if (Physics.Linecast(fromObj, toTarg, out wallHit))
		{
			// stop camera from moving into walls
			toTarg = new Vector3(wallHit.point.x, toTarg.y, wallHit.point.z);
		}
	}




}
