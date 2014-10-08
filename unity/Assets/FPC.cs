using UnityEngine;
using System.Collections;

public class FPC : MonoBehaviour {


	CharacterController charC;
	public GameObject player;
	[SerializeField]camScript cam;

	//public AudioClip jumpAud;

	public float moveSpeed = 5.0f;
	public float jumpSpeed = 5.0f;

//	public float mouseSensitivity = 2.0f;
//	public float upDownRange = 50.0f;
//	// sadfasdfa
//
//	float vertRot = 0;
	float vertVelo = 0;

	// Use this for initialization
	void Start () 
	{
		Screen.lockCursor = true;
		charC = GetComponent<CharacterController> ();
		player = this.gameObject;
	}
	
	// Update is called once per frame
	void Update () 
	{
//		float yaw = Input.GetAxis("Mouse X") * mouseSensitivity;
//		transform.Rotate (0, yaw, 0);
//		vertRot -= Input.GetAxis ("Mouse Y") * mouseSensitivity;
//
//		// more shit about stuff.rg78oashud fg7yukhqwef
//		vertRot = Mathf.Clamp (vertRot, -upDownRange, upDownRange);
//		Camera.main.transform.localRotation = Quaternion.Euler(vertRot, 0, 0);
//
//
		// increase velocity the longer you fall
		vertVelo += Physics.gravity.y * Time.deltaTime;

		// Jumping if the character is on the ground/player can not jump wile already in air
		if (charC.isGrounded && Input.GetButtonDown ("Jump")) 
		{
			vertVelo = jumpSpeed;
			//AudioSource.PlayClipAtPoint(jumpAud, gameObject.transform.position);
		}

		// Standard WASD/UDLR controls
		float forwardSpeed = Input.GetAxis ("Vertical") * moveSpeed;
		float sideSpeed = Input.GetAxis ("Horizontal") * moveSpeed;
		Vector3 speed = new Vector3 (sideSpeed, vertVelo, forwardSpeed);
		speed = transform.rotation * speed;
		charC.Move (speed * Time.deltaTime);

	}








}
