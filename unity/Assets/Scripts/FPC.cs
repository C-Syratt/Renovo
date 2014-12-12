using UnityEngine;
using System.Collections;

public class FPC : MonoBehaviour {

	// Player's state, could/should have been made a game state in a GameManager
	public enum playerState
	{
		game,
		finale,
		grandFinale,
		Exit
	}
	
	CharacterController charC;
	public camScript cam;

	public Transform mage;
	public GameObject player;
	public bool canJump = false;
	public playerState playState;

	[SerializeField] AudioClip[] jumpAud;

	Vector3 speed;

	public float moveSpeed = 5.0f;
	public float jumpSpeed = 5.0f;

	float counter;
	float t = 5;
	float vertVelo = 0;

	void Start () 
	{
		if(Application.loadedLevelName != "MainMenu")
		{
			Screen.lockCursor = true;
		}
		charC = GetComponent<CharacterController> ();
		player = this.gameObject;

		playState = playerState.game;
	}

	public void CanJump()
	{
		canJump = true;
	}

	/* !!WARNING!!
	 * The following code is a mess and should have been sorted into indiviual functions 
	 * Also because this script was adpated from a First Person Controller Script (FPC)
	 * and a lot of messing about trying to do different things/intergrate animations
	 */
	void Update () 
	{
		// if player is in Game/Grandfinale/Exit, they can move around
		if(playState == playerState.game || playState == playerState.grandFinale || playState == playerState.Exit)
		{
			// increase velocity the longer you fall
			if (!charC.isGrounded) 
			{
				vertVelo += Physics.gravity.y * Time.deltaTime;
			}

			// Jumping if the character is on the ground/player can not jump while already in air
			if (canJump == true) 
			{
				if (charC.isGrounded && Input.GetButtonDown ("Jump")) 
				{
					vertVelo = jumpSpeed;
					AudioSource.PlayClipAtPoint(jumpAud [Random.Range (0, jumpAud.Length)], gameObject.transform.position);
					mage.animation.Play("Jumping");
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

			if ( !Input.GetButton( "Horizontal" ) && !Input.GetButton( "Vertical" ) && charC.isGrounded) 
			{
				// Play Idle Anim when no buttons(movement) are pressed and player on the ground
				mage.animation.CrossFade("Idle");
			}

			if ((Input.GetButton("Horizontal") || Input.GetButton ("Vertical")) && !audio.isPlaying && charC.isGrounded) 
			{
				// play footstep(Audio) and Running(Animation) if player is on the ground and moving(buttons pressed)
				audio.Play ();
				mage.animation.CrossFade("Running");
			}
			else if ( !Input.GetButton( "Horizontal" ) && !Input.GetButton( "Vertical" ) && audio.isPlaying 
			         && charC.isGrounded)
			{
				audio.Stop(); // stop playing footstep(audio) is player is standing still
			}

			if(forwardSpeed < 0)
			{
				// Player backpedal(animation) if player is moving backwards
				mage.animation.CrossFade("Back");
			}
			else if(sideSpeed > 0)
			{
				// Play RightStep(animation) if player is moving Right
				mage.animation.CrossFade("RightStep");
			}
			else if(sideSpeed < 0)
			{
				// Play RightStep(animation) if player is moving Left
				mage.animation.CrossFade("LeftStep");
			}
		}

		// if final puzzle is completed/player finds exit begin time out (5s)
		if(playState == playerState.grandFinale || playState == playerState.Exit)
		{
			counter += Time.deltaTime;
			if(counter > t)
			{
				if(playState == playerState.grandFinale)
				{
					Win();
				}

				if(playState == playerState.Exit)
				{
					Exit();
				}
			}
		}
		if(Input.GetKeyDown(KeyCode.Escape))
			Application.LoadLevel(0); // return to main menu
		
	}

	public void ActivateFinale()
	{
		playState = playerState.finale; // final puzzle state
		cam.changeView ();
	}

	public void ActivateExit()
	{
		playState = playerState.Exit; // when player finds secret exit
	}

	void Win()
	{
		// Load the Level Again
		Application.LoadLevel(1);
	}

	void Exit()
	{
		// Load Main Menu
		Application.LoadLevel(0);
	}

}
