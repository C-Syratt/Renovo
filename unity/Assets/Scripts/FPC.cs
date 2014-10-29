using UnityEngine;
using System.Collections;

public class FPC : MonoBehaviour {

	public enum playerState
	{
		game,
		finale,
		grandFinale,
		Exit
	}


	CharacterController charC;
	[SerializeField]public camScript cam;

	public Transform mage;
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
		if(Application.loadedLevelName != "MainMenu")
		{
			Screen.lockCursor = true;
		}
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
		if(playState == playerState.game || playState == playerState.grandFinale || playState == playerState.Exit)
		{
			// increase velocity the longer you fall
			if (!charC.isGrounded) 
			{
				vertVelo += Physics.gravity.y * Time.deltaTime;
			}
			//THIS SHIT IS A COMPLETE MESS!!!
			// Jumping if the character is on the ground/player can not jump wile already in air
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
				// Play Idle Anim
				mage.animation.CrossFade("Idle");
			}

			if ((Input.GetButton("Horizontal") || Input.GetButton ("Vertical")) && !audio.isPlaying && charC.isGrounded) 
			{
				audio.Play ();
				mage.animation.CrossFade("Running");

			}
			else if ( !Input.GetButton( "Horizontal" ) && !Input.GetButton( "Vertical" ) && audio.isPlaying 
			         && charC.isGrounded)
			{
				audio.Stop(); // or Pause()
			}

			if(forwardSpeed < 0)
			{
				mage.animation.CrossFade("Back");
			}
			else if(sideSpeed > 0)
			{
				mage.animation.CrossFade("RightStep");
			}
			else if(sideSpeed < 0)
			{
				mage.animation.CrossFade("LeftStep");
			}
		}


			

		if(playState == playerState.grandFinale || playState == playerState.Exit)
		{
			counter += Time.deltaTime;
			if(counter > t)
			{
				if(playState == playerState.grandFinale)
					Win();

				if(playState == playerState.Exit)
				{
					// print("Exit");
					Exit();
				}
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

	public void ActivateExit()
	{
		print ("Exit");
		playState = playerState.Exit;
	}

	void Win()
	{
		// Load the Level Again
		Application.LoadLevel(1);
	}

	void Exit()
	{
		// Load Main Meny
		Application.LoadLevel(0);
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
