using UnityEngine;
using System.Collections;

public class FPC : MonoBehaviour {

	public enum playerState
	{
		game,
		finale,
		grandFinale
	}


	CharacterController charC;
	[SerializeField]public camScript cam;

	public GameObject player;
//	public GameObject torch;
//	public GameObject blindlight;
//	public GameObject puzzle2;
	public bool canJump = false;
	public playerState playState;

	[SerializeField] AudioClip[] jumpAud;

	Vector3 speed;

	public float moveSpeed = 5.0f;
	public float jumpSpeed = 5.0f;

	float counter;
	float t = 5;
	float vertVelo = 0;

	// Use this for initialization
	void Start () 
	{
		Screen.lockCursor = true;
		charC = GetComponent<CharacterController> ();
		player = this.gameObject;

		playState = playerState.game;
//		puzzle2 = GameObject.Find("Puzzle2Trigger");
	}

	public void CanJump()
	{
		canJump = true;
	}

	void Update () 
	{
		if(playState == playerState.game || playState == playerState.grandFinale)
		{
			// increase velocity the longer you fall
			if (!charC.isGrounded) 
			{
				vertVelo += Physics.gravity.y * Time.deltaTime;
			}

			// Jumping if the character is on the ground/player can not jump wile already in air
			if (canJump == true) 
			{
				if (charC.isGrounded && Input.GetButtonDown ("Jump")) 
				{
					vertVelo = jumpSpeed;
					AudioSource.PlayClipAtPoint(jumpAud [Random.Range (0, jumpAud.Length)], gameObject.transform.position);
				}
			}

			// Standard WASD/UDLR controls
			float forwardSpeed = Input.GetAxis ("Vertical") * moveSpeed;
			float sideSpeed = Input.GetAxis ("Horizontal") * moveSpeed;
			speed = new Vector3 (sideSpeed, vertVelo, forwardSpeed);
			speed = transform.rotation * speed;
			charC.Move (speed * Time.deltaTime);

			if (!charC.isGrounded) 
			{
				audio.Stop();
			}

			if ((Input.GetButton("Horizontal") || Input.GetButton ("Vertical")) && !audio.isPlaying) 
			{
				audio.Play ();
			}
			else if ( !Input.GetButton( "Horizontal" ) && !Input.GetButton( "Vertical" ) && audio.isPlaying 
			         && charC.isGrounded)
			{
				audio.Stop(); // or Pause()
			}
		}

		if(playState == playerState.grandFinale)
		{
			counter += Time.deltaTime;
			if(counter > t)
			{
				Win();
			}
		}
		if(Input.GetKeyDown(KeyCode.Escape))
			Application.LoadLevel(0);
		
	}

	public void ActivateFinale()
	{
		playState = playerState.finale;
		cam.changeView ();
	}

	void Win()
	{
		// Load the Level Again
		Application.LoadLevel(1);
	}

//	public void TorchOn()
//	{
//		torch.SetActive (true);
//		blindlight.SetActive (false);
//	}
//
//	public void TorchOff()
//	{
//		torch.SetActive (false);
//		blindlight.SetActive (true);
//	}
//	public void SecondPuzzle()
//	{
//		Destroy (puzzle2);
//		puzzle2.SendMessage("DeActivate");
//		TorchOn ();
//	}

}
