using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserCat : MonoBehaviour {

	public int laserCatHealth; // the amount of health that the laser cat has
	public GameObject laserCatClaws; // slot for the laser cat's claws

	public GameObject player; // slot for the player

	public float speed; // controls how fast the cat can go
	public float distanceBetweenObjects; // tracks the distance between the player and the cat
	private Transform target; // used to find the player

	private float timeBtwStabs; // the time before the cat can attack
	public float startTimeBtwStabs; // the initial value of the previous timer
	private float durationTime; // how long the claws will last for

	public AudioClip stabSound; // sound for when the LaserCat stabs the player
	public AudioClip hitSound; // sound for when the LaserCat gets damaged
	public AudioClip stunSound; // sound for when the LaserCat gets hit, but not damaged
	private AudioSource catSound; // reference to the audio source

	// Use this for initialization
	void Start () 
	{
		laserCatHealth = 4; // how much health the cat has

		laserCatClaws.gameObject.SetActive (true); // the first claw is active
		laserCatClaws.gameObject.SetActive (false); // the second one isn't

		// looks for the transform component on the player
		target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform> ();

		catSound = GetComponent<AudioSource> (); // gets the audio source
	}
	
	// Update is called once per frame
	void Update () {

		// sets the distance between the cat and the player
		distanceBetweenObjects = this.gameObject.transform.position.x - player.transform.position.x;

		// checks to see if the cat lost all of it's health
		if (laserCatHealth == 0) 
		{
			Destroy (this.gameObject); // the cat is dead
		}

		// checks to see if the player is at least six units away from the laser cat
		if (distanceBetweenObjects < 6) 
		{
			// the cat moves towards the player
			transform.position = Vector2.MoveTowards (transform.position, target.position, speed * Time.deltaTime);

			// checks to see if the cat can attack
			if (timeBtwStabs <= 0) 
			{
				laserCatClaws.gameObject.SetActive (false); // first claw is inactive
				laserCatClaws.gameObject.SetActive (true); // second claw is active
				catSound.PlayOneShot (stabSound, 1f); // plays the stab sound

				durationTime = 15f; // sets the duration time to 15 seconds

				timeBtwStabs = startTimeBtwStabs; // this var is set back to its initial value
			}

			// checks to see if the duration timer has ran out
			if (durationTime <= 0)
			{
				// both claws are inacive
				laserCatClaws.gameObject.SetActive (false); 
				laserCatClaws.gameObject.SetActive (false); 

				timeBtwStabs -= Time.deltaTime; // this value decreases over real time
			}
		}

		durationTime -= 1f; // the time the weapons will last for
	}

	// used to check for various collisions
	void OnCollisionEnter2D (Collision2D other)
	{
		// checks to see if the cat was hit by a bullet
		if (other.gameObject.tag == "Bullet") 
		{
			laserCatHealth -= 2; // take away 2 pieces of health
			catSound.PlayOneShot (hitSound, 1f); // plays the hit sound
		}

		// checks to see if the cat was hit with the spear
		if (other.gameObject.tag == "Spear") 
		{
			// pushes the cat back by a bit
			transform.position = new Vector2 (transform.position.x + 3, transform.position.y);
			catSound.PlayOneShot (stunSound, 1f); // plays the stun sound
		}

		if (other.gameObject.tag == "Spike") 
		{
			Destroy (this.gameObject);
		}
	}
}
