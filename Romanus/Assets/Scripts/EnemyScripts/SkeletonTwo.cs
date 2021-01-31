using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletonTwo : MonoBehaviour {

	public int skeletonHealth; // var that holds the health for the shooting skeletons

	public GameObject skeletonBullet; // slot for the skeleton's bullet
	public Transform bulletSpawner; // slot that spawns the bullets
	private float timeBtwShots; // time between when the bullets have been shot
	public float startTimeBetweenShots; // initial time for when bullets have been shot

	public GameObject player; // slot for the player
	public float distanceBetweenObjects; // tracks distance between player and skeleton

	public AudioClip hitSound; // sound for when the skeleon gets hit
	public AudioClip shootSound; // sound for when this skeleton type fires a bullet
	private AudioSource skeletonSound; // reference to the audio source

	// Use this for initialization
	void Start () {
		skeletonHealth = 3; // gives the skeleton three points of health
		skeletonSound = GetComponent<AudioSource> (); // gets the audio source
	}
	
	// Update is called once per frame
	void Update () {

		// sets this variable to be the difference between the skeleton's position and that of the player 
		distanceBetweenObjects = this.gameObject.transform.position.x - player.transform.position.x;

		// checks to see if the skeleton ran out of health
		if (skeletonHealth <= 0) 
		{
			Destroy (this.gameObject); // kill it
		}

		// chceks to see if the player is close enough and timeBtwShots is less than or equal to zero
		if (distanceBetweenObjects < 10 && timeBtwShots <= 0)
		{
			// fire the bullet
			Instantiate (skeletonBullet, bulletSpawner.position, transform.rotation);
			skeletonSound.PlayOneShot(shootSound,1f); // plays the hit sound
			timeBtwShots = startTimeBetweenShots; // sets this variable to its initial value
		} 

		else // when if is false
		{
			timeBtwShots -= Time.deltaTime; // decrease this value over real time
		}

	}

	void OnCollisionEnter2D(Collision2D other)
	{
		// checks to see if the skeleton was hit by the spear
		if (other.gameObject.tag == "Spear") 
		{
			skeletonHealth -= 3; // take away all of its hp
		}

		// checks to see if the skeleton got shot
		if (other.gameObject.tag == "Bullet") 
		{
			skeletonHealth -= 1; // take away a third of it's health
			skeletonSound.PlayOneShot(hitSound,1f); // plays the hit sound
		}

		// checks to see if the skeleton got shot
		if (other.gameObject.tag == "BarbedWire") 
		{
			skeletonHealth = 0; // take away a third of it's health
			skeletonSound.PlayOneShot(hitSound,1f); // plays the hit sound
		}

		// checks to see if the bullet collided with a trap platform
		if (other.gameObject.tag == "Trap") 
		{
			Destroy (this.gameObject); // destroys Guard A
		}
	}
}
