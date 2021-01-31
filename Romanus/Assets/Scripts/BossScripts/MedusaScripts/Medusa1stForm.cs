using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Medusa1stForm : MonoBehaviour {

	public int Medusa1stFormHealth; // Medusa's health while in her first form
	public GameObject Medusa1stFormWeapon; // Medusa's melee weapon
	public GameObject player; // slot for the player
	public GameObject secondForm; // slot for Medusa's second form

	public float speed; // controls how fast Medusa moves while in this form
	public float distanceBetweenObjects; // trscks distance

	public float startTimeBtwStabs; // initial time for when she stabs
	private float timeBtwStabs; // time after initial stab
	private float durationTime; // how long the stab will last for
	private Transform target; // tracks where the player is

	public AudioClip stabSound; // sound for when the Sentry shoots the player
	public AudioClip hitSound; // sound for when the Sentry gets damaged
	public AudioClip stunSound; // sound for when the Sentry gets hit, but not damaged
	private AudioSource humanSound; // reference to the audio source

	// Use this for initialization
	void Start () {
		Medusa1stFormHealth = 10; // gives Medusa 10 hp

		secondForm.gameObject.SetActive (false); // prevents her second form from appearing

		Medusa1stFormWeapon.gameObject.SetActive (false); // sets the weapon false

		// sets target to where the player is
		target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform> ();
		humanSound = GetComponent<AudioSource> (); // reference to the audio source
	}
	
	// Update is called once per frame
	void Update () {

		// sets this var to be the difference between Medusa and the player
		distanceBetweenObjects = this.gameObject.transform.position.x - player.transform.position.x;

		// checks to see if Medusa ran out of health
		if (Medusa1stFormHealth == 0) 
		{
			this.gameObject.SetActive(false); // deactivates her first form
			secondForm.gameObject.SetActive (true); // changes into her second form
		}

		// checks to see if the player is close enought
		if (distanceBetweenObjects < 16) 
		{
			// Medusa will move towards the player
			transform.position = Vector2.MoveTowards (transform.position, target.position, speed * Time.deltaTime);

			//checks to see if this variable is less than or equal to zero
			if (timeBtwStabs <= 0) 
			{
				// makes her weapon appear
				Medusa1stFormWeapon.gameObject.SetActive (true);
				humanSound.PlayOneShot (stabSound, 1f); // plays the stab sound

				durationTime = 15f; // sets this timer to fifteen seconds

				timeBtwStabs = startTimeBtwStabs; // sets this variable back to its initial value
			}

			//checks to see if this timer is equal to zero
			if (durationTime <= 0) 
			{
				Medusa1stFormWeapon.gameObject.SetActive (false); // makes her weapon dissapear

				timeBtwStabs -= Time.deltaTime; // decreases this variable over real time
			}
				
		}

		durationTime -= 1f; // decreases this value by 1 second
	}

	void OnCollisionEnter2D (Collision2D other)
	{
		// checks to see if Medusa was hit by the Bullet
		if (other.gameObject.tag == "Bullet") {

			Medusa1stFormHealth -= 1; // decreases her health by 1
			humanSound.PlayOneShot (hitSound, 1f); // plays the hurt sound
		}

		// checks to see if Medusa was hit by the spear
		if (other.gameObject.tag == "Spear") 
		{
			//pushes Medusa back 
			transform.position = new Vector2 (transform.position.x + 2, transform.position.y);
			humanSound.PlayOneShot (stunSound, 1f); // plays the stun sound
		}
	}
}
