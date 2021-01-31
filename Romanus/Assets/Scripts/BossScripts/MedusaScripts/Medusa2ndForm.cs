using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Medusa2ndForm : MonoBehaviour {

	public int secondFormHealth; // Medusa's health while in her second form
	public Transform firePoint; // place where fireballs will be shot
	public GameObject fireBall; // the fireball objects that will be fired
	private float timeBtwShots; // time after initial shot
	public float startTimeBtwShots; // initial time for when she shoots

	public GameObject player; // slot for the player

	public float distanceBetweenObjects; // tracks difference between shots
	public float speed; // tracks how fast she moves in this form
	private Transform target; // used to find the player

	public AudioClip shootSound; // sound for when the Sentry shoots the player
	public AudioClip hitSound; // sound for when the Sentry gets damaged
	public AudioClip stunSound; // sound for when the Sentry gets hit, but not damaged
	private AudioSource monsterSound; // reference to the audio source

	// Use this for initialization
	void Start () 
	{
		secondFormHealth = 10; // sets her health in this form to 10
		// sets this var so that it will find the player
		target = GameObject.FindGameObjectWithTag ("Player").GetComponent<Transform> ();
		monsterSound = GetComponent<AudioSource> (); // gets the audio source on medusa's second form
	}
	
	// Update is called once per frame
	void Update () 
	{
		// checks to see if she lost all of her health in this form
		if (secondFormHealth == 0)
		{
			SceneManager.LoadScene ("ConclusionScene"); // loads the win scene
		}

		// sets the distance between objects to be the difference between the position of the player and Medusa
		distanceBetweenObjects = this.gameObject.transform.position.x - player.transform.position.x;

		// checks to see if the player is close enough
		if (distanceBetweenObjects < 18) 
		{
			// Medusa will move towards the player
			transform.position = Vector2.MoveTowards (transform.position, target.position, speed * Time.deltaTime);
		}

		// checks to see if the player is closer and the time var is zero
		if (distanceBetweenObjects < 16 && timeBtwShots <= 0) 
		{
			// makes a fireball
			Instantiate (fireBall, firePoint.position, transform.rotation);
			monsterSound.PlayOneShot (shootSound, 1f); // plays the shoot sound
			timeBtwShots = startTimeBtwShots; // sets the time var back to its initial value
		}
		else // when previous if statement is false
		{
			timeBtwShots -= Time.deltaTime; // decreases this var over real time
		}

	}

	void OnCollisionEnter2D (Collision2D other)
	{
		// checks to see if Medusa collides with the Spear in this form
		if (other.gameObject.tag == "Spear") 
		{
			secondFormHealth -= 1; // lose one health point
			monsterSound.PlayOneShot (hitSound, 1f); // plays the hit sound
		}

		// checks to see if Medusa was hit by a bullet while in this form
		if (other.gameObject.tag == "Bullet") 
		{
			// pushes her back
			transform.position = new Vector2 (transform.position.x + 2, transform.position.y);
			monsterSound.PlayOneShot (stunSound, 1f); // plays the stun sound
		}
	}
}
