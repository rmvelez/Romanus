using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HawknightAttack : MonoBehaviour {

	public int hawkNightHealth; // health for Hawk-Knight
	public GameObject hawkShield; // slot for the Hawk-Knight's shield
	public GameObject hawkSword; // slot for the Hawk-Knight's sword
	public GameObject player; // slot for the player

	public float speed; // speed of the hawk knight
	public float distanceBetweenObjects; // checks to see the distance between the player and the object
	private Transform target; // what the enemy will chase after

	private float timeBtwStabs; // time between when Hawk-Knight attacks
	public float startTimeBtwStabs; // the initial time for when Hawk-Knight attacks
	private float durationTime; // var that controls how long

	public AudioClip stabSound; // sound for when the Hawk-Knight stabs the player
	public AudioClip hitSound; // sound for when the Hawk-Knight gets damaged
	public AudioClip stunSound; // sound for when the Hawk-Knight gets hit, but not damaged
	private AudioSource knightSound; // reference to the audio source

	// Use this for initialization
	void Start () {
		hawkNightHealth = 4; // this enemy starts off with three points of health
		hawkShield.gameObject.SetActive (true); // makes his shield appear
		hawkSword.gameObject.SetActive (false); // hides his sword

		// the enemy will search for the object called player
		target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();	
		knightSound = GetComponent<AudioSource> (); // gets the audio source
	}
	
	// Update is called once per frame
	void Update () {

		// sets the distance between the enemy and the player
		distanceBetweenObjects = this.gameObject.transform.position.x - player.transform.position.x;

		// checks to see if this enemy's health is at zero
		if (hawkNightHealth <= 0) 
		{
			Destroy (this.gameObject); // kills the enemy
		}

		if (distanceBetweenObjects < 12)
		{
			// this will set up enemy's target, movement, and speed
			transform.position = Vector2.MoveTowards (transform.position, target.position, speed * Time.deltaTime);

			// checks to see if timeBtwSwipes 
			if (timeBtwStabs <= 0) 
			{
				hawkShield.gameObject.SetActive (false); // hides his shield
				hawkSword.gameObject.SetActive (true); // draws his sword
				knightSound.PlayOneShot(stabSound,1f); // plays the stab sound
				durationTime = 15f; // makes the attack last for 15 seconds
				timeBtwStabs = startTimeBtwStabs; // sets these variables equal to each other
			} 
			// runs when the previous statement is false
			if (durationTime <= 0)
			{
				hawkShield.gameObject.SetActive (true); // makes his shield appear
				hawkSword.gameObject.SetActive (false); // hides his sword
				timeBtwStabs -= Time.deltaTime; // decreases this value over time
			}
		}

		durationTime -= 1f; // decreases this variable by 1
	}

	void OnCollisionEnter2D (Collision2D other)
	{
		// checks to see if the Hawk-Knight was hit with a bullet
		if (other.gameObject.tag == "Bullet") 
		{
			hawkNightHealth -= 1; // take away one point of health
			knightSound.PlayOneShot(hitSound,1f); // plays hit sound
		}

		// checsk to see if the Hawk Knight was attacked with the spear
		if (other.gameObject.tag == "Spear") 
		{
			// pushes the Hawk-Knight back so the player has more time to defeat him
			transform.position = new Vector2 (transform.position.x + 3, transform.position.y);
			knightSound.PlayOneShot (stunSound, 1f); // plays the stun sound
		}
	}
}
