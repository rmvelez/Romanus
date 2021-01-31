using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewDarkHound : MonoBehaviour {

	public float speed; // declare speed
	public int enemyHealth; // var that tracks enemy health
	public GameObject player; //slot for the player

	public float distanceBetweenObjects; // checks to see the distance between the player and the object
	private Transform target; // what the enemy will chase after

	public AudioClip hitSound; // sound for when the Dark-Hound gets damaged
	public AudioClip stunSound; // sound for when the Dark-Hound gets hit, but not damaged
	private AudioSource houndSound; // reference to the audio source

	// Use this for initialization
	void Start ()
	{

		// the enemy will search for the object called player
		target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
		houndSound = GetComponent<AudioSource> (); // gets the audio source
	}
	
	// Update is called once per frame
	void Update () 
	{

		// sets the distance between the enemy and the player
		distanceBetweenObjects = this.gameObject.transform.position.x - player.transform.position.x;

		if (distanceBetweenObjects < 6)
		{
			// this will set up enemy's target, movement, and speed
			transform.position = Vector2.MoveTowards (transform.position, target.position, speed * Time.deltaTime);
		}

		// checks to see if the enemy's health is zero
		if (enemyHealth <= 0) 
		{
			Destroy (this.gameObject); // the dark hound is dead
		}
	}

	// this function is used to check for collisions
	void OnCollisionEnter2D (Collision2D other) 
	{
		// checks to see if the enemy was hit by a spear
		if (other.gameObject.tag == "Spear") 
		{
			enemyHealth -= 2; // take away two health points
			houndSound.PlayOneShot(hitSound,1f); // plays the hit sound
		}

		// checks to see if the enemy was shot at with a bullet
		if (other.gameObject.tag == "Bullet") 
		{
			// pushes the dark hound back so the player has more time to defeat him
			transform.position = new Vector2 (transform.position.x + 1, transform.position.y);
			houndSound.PlayOneShot(stunSound,1f); // plays the stun sound
		}
	}
}

