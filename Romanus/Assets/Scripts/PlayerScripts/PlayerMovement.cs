using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour {

	public float speed; //how fast he goes
	private float horizontal; //controls horizontal axis

	// this pair of bools is used to determine where the camera should go when the player warps through time
	public bool portalOne; // this bool checks to see if the past portal is active
	public bool portalTwo; // this bool checks to see if the future portal is active

	public bool isForward; // used to determine which direction the player can attack

	public float jumpForce; //how high he can jump
	public bool grounded = false; // checks to see if the player is touching the ground
	public GameObject groundCheck = null; // slot for the ground checker
	public GameObject camera; // slot for the camera
	private Rigidbody2D MyRb; //need a body to jump

	public AudioClip jumpSound; // sound that plays when the player jumps
	public AudioClip gateSound; // sound that plays when the player passes through a gate
	public AudioClip portalSound; // sound that plays when the player warps through a portal
	private AudioSource movementSound; // audio source used t play sounds

	Animator myAnimator;
	public bool isWalking = false;
	public bool isJumping = false;

	// Use this for initialization
	void Start () 
	{
		MyRb = GetComponent<Rigidbody2D> (); //connect ref to rigidbody
		myAnimator = GetComponent<Animator>();
		movementSound = GetComponent<AudioSource>(); // looks for audio source on the player
		portalTwo = true; // the future portal is currently active
		portalOne = false; // the past portal is currently inactive

	}

	void Update()
	{
		myAnimator.SetBool ("isWalk", isWalking);
		myAnimator.SetBool ("isJump", isJumping);

		// when the player is at this location
		if (portalTwo == true && portalOne == false) 
		{
			// follow the player while in the past
			camera.transform.position = new Vector3 (transform.position.x + speed, 0, -10);
		}

		// checks to see if the player warped to the future
		else if (portalOne == true && portalTwo == false) 
		{
			// follow the player while in the future
			camera.transform.position = new Vector3 (transform.position.x + speed, -50, -10);
		} 

		// Flip the character
		Vector2 characterScale = transform.localScale;

		//checks to see if the player is moving to the left
		if (Input.GetAxis("Horizontal") < 0) 
		{
			isForward = false; // the player is facing backwards
			characterScale.x = -1f; // flips the model to face left
			characterScale.y = 1f;
			isWalking = true;
		}

		//checks to see if the player is moving to the right
		else if (Input.GetAxis("Horizontal") > 0) 
		{
			isForward = true; // player is foreward
			characterScale.x = 1f; //flips the model to face right (if the player isn't already facing right)
			characterScale.y = 1f;
			isWalking = true;
		}

		else
		{
			isWalking = false;
		}

		transform.localScale = characterScale; // sets the players scale to the new variable
	}
		
	void FixedUpdate () 
	{
		myAnimator.SetBool ("isWalk", isWalking);
		myAnimator.SetBool ("isJump", isJumping);

		//gives the player horizontal movement
		horizontal= Input.GetAxisRaw ("Horizontal");
		MyRb.velocity = new Vector2 (horizontal * speed, MyRb.velocity.y); 

		// checks to see if the player and groundCheck are touching a platform
		if (Physics2D.Linecast (transform.position, groundCheck.transform.position))
		{
			grounded = true; // allows the player to jump
		}
		else // runs while player is in the air
		{
			grounded = false; // prevents the player from jumping
		}

		//if the player presses space while grounded, he or she jumps
		if(Input.GetKeyDown(KeyCode.Space) && grounded) 
		{ 
			GetComponent<Rigidbody2D>().AddForce(new Vector2(0,jumpForce)); 
			movementSound.PlayOneShot (jumpSound, 1f); // plays jump sound
			isJumping = true;
		}

		else
		{
			isJumping = false;
		}
	}

	// this function is used to check for collisions
	void OnCollisionEnter2D (Collision2D other) 
	{
		// checks to see if the player collided with a gate
		if (other.gameObject.tag == "Gate") 
		{
			other.gameObject.SetActive (false); // sets the gate to false
			movementSound.PlayOneShot(gateSound,1f); // plaves gate sound
		}

		// checks to see if the player reached the end of level 2
		if (other.gameObject.tag == "Endzone") 
		{
			SceneManager.LoadScene ("CutsceneFour"); // loads the third cutscene of the game
		}
	
		// checks to see if the player is colliding with a future portal
		if (other.gameObject.tag == "FuturePortal") 
		{
			// declares a new var that moves the player to the future part of the level
			Vector2 futureWarp = new Vector2 (transform.position.x, transform.position.y - 50);
			transform.position = futureWarp; // sets the player's position to the new value
			portalOne = true; // the future portal is active
			portalTwo = false; // the past portal is inactive
			movementSound.PlayOneShot(portalSound,1f); // plays warp sound
		}

		// checks to see if the player is colliding with a past portal
		if (other.gameObject.tag == "PastPortal") 
		{
			// declares a new var that moves the player back to the past
			Vector2 pastWarp = new Vector2 (transform.position.x, transform.position.y + 50);
			transform.position = pastWarp; // sets the player's position to the new value
			portalTwo = true; // the past portal is active
			portalOne = false; // the future portal is inactive
			movementSound.PlayOneShot(portalSound,1f); // plays warp sound
		}
    }
}