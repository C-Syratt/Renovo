using UnityEngine;
using System.Collections;

public class FPC : MonoBehaviour {

	public enum playerState
	{
		game,
		finale
	}


	CharacterController charC;
	[SerializeField]camScript cam;

	public GameObject player;
	public GameObject torch;
	public GameObject puzzle2;
	public bool canJump = false;
	public playerState playState;

	//public AudioClip jumpAud;
	// jumpin and shit

	public Vector3 speed;

	public float moveSpeed = 5.0f;
	public float jumpSpeed = 5.0f;
	
	float vertVelo = 0;

	// Use this for initialization
	void Start () 
	{
		Screen.lockCursor = true;
		charC = GetComponent<CharacterController> ();
		player = this.gameObject;

		playState = playerState.game;
		puzzle2 = GameObject.Find("Puzzle2Trigger");
	}

	public void CanJump()
	{
		canJump = true;
	}



	// Update is called once per frame
	void Update () 
	{
		if(playState == playerState.game)
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
				//AudioSource.PlayClipAtPoint(jumpAud, gameObject.transform.position);
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
	}

	public void ActivateFinale()
	{
		playState = playerState.finale;
		cam.changeView ();
	}

	public void TorchOn()
	{
		torch.SetActive (true);
	}

	public void TorchOff()
	{
		torch.SetActive (false);
	}
	public void SecondPuzzle()
	{
		Destroy (puzzle2);
		TorchOn ();
	}

}
