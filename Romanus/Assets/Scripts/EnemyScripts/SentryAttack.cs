using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SentryAttack : MonoBehaviour {

	public GameObject Bullet; // slot for the bullet prefab
	public Transform bulletSpawner1; // slot for object that will spawn the top bullet
	public Transform bulletSpawner2; // slot for object that will spawn the middle bullet
	public Transform bulletSpawner3; // slot for object that will spawn the lower bullet

	private float timeBtwShots; // time between when arrows have been shot
	public float startTimeBetweenShots; // initial time when the bullets have been launched

	public GameObject player; // slot for the player
	public float distanceBetweenObjects; // checks the distance between this object and the player

	public int sentryHealth; // the Sentry's health
	public float speed; // how fast it can move
	private Transform target; // used to find player

	public AudioClip shootSound; // sound for when the Sentry shoots the player
	public AudioClip hitSound; // sound for when the Sentry gets damaged
	public AudioClip stunSound; // sound for when the Sentry gets hit, but not damaged
	private AudioSource sentrySound; // reference to the audio source

	// Use this for initialization
	void Start () 
	{
		sentryHealth = 3; // sets the Sentry's health to 3
		// sets this variable so it can find the player
		target = GameObject.FindGameObjectWithTag ("Player").GetComponent<Transform> ();
		sentrySound = GetComponent<AudioSource> (); // gets the audio source on the sentry
	}
	
	// Update is called once per frame
	void Update () 
	{
		// sets this variable to the difference of these two objects
		distanceBetweenObjects = this.gameObject.transform.position.x - player.transform.position.x;

		// checks to see if the sentry lost all of its health
		if (sentryHealth == 0) 
		{
			Destroy (this.gameObject); // the sentry is dead
		}

		// checks to see if the player is 10 units away from the sentry
		if (distanceBetweenObjects < 10) 
		{
			// makes the Sentry move towards the player
			transform.position = Vector2.MoveTowards (transform.position, target.position, speed * Time.deltaTime);
		}

		// checks to see if the distance between the objects is less than 16
		if (timeBtwShots <= 0 && distanceBetweenObjects < 8) 
		{
			Instantiate (Bullet, bulletSpawner1.position, transform.rotation); // creates an bullet
			Instantiate (Bullet, bulletSpawner2.position, transform.rotation); // creates an bullet
			Instantiate (Bullet, bulletSpawner3.position, transform.rotation); // creates an bullet
			sentrySound.PlayOneShot(shootSound,1f);
			timeBtwShots = startTimeBetweenShots; // sets these two variables equal to each other
		} 
		else // runs when the if statement is false
		{
			timeBtwShots -= Time.deltaTime; // decreases this value over real time
		}
	}

	// used to check for collisions with other game objects
	void OnCollisionEnter2D(Collision2D other)
	{
		// checks to see if the sentry was hit with the spear
		if (other.gameObject.tag == "Spear") 
		{
			sentryHealth -= 1; // the sentry loses one point of health
			sentrySound.PlayOneShot (hitSound, 1f); // plays the hit sound
		}

		// checks to see if the sentry was shot at by a bullet
		if (other.gameObject.tag == "Bullet") 
		{
			// pushes the sentry back
			transform.position = new Vector2 (transform.position.x + 1, transform.position.y);
			sentrySound.PlayOneShot (stunSound, 1f); // plays the stun sound
		}
	}
}