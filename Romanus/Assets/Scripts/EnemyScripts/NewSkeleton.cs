using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewSkeleton : MonoBehaviour {

	public float speed; // declare speed
	public int enemyHealth; // var that tracks enemy health
	public GameObject player; //slot for the player

	public float distanceBetweenObjects; // checks to see the distance between the player and the object
	private Transform target; // what the enemy will chase after

	public AudioClip hitSound; // sound for when the skeleon gets hit
	private AudioSource skeletonSound; // reference to the audio source

	// Use this for initialization
	void Start () {

		// the enemy will search for the object called player
		target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
		skeletonSound = GetComponent<AudioSource> (); // gets the audio source
	}
	
	// Update is called once per frame
	void Update () {

		// sets the distance between the enemy and the player
		distanceBetweenObjects = this.gameObject.transform.position.x - player.transform.position.x;

		if (distanceBetweenObjects < 8)
		{
			// this will set up enemy's target, movement, and speed
			transform.position = Vector2.MoveTowards (transform.position, target.position, speed * Time.deltaTime);
		}

		// checks to see if the enemy's health is zero
		if (enemyHealth <= 0) 
		{
			Destroy(this.gameObject); // the skeleton is now dead
		}
	}

	// this function is used to check for collisions
	void OnCollisionEnter2D (Collision2D other) 
	{
		// checks to see if the skeleton was hit by a spear
		if (other.gameObject.tag == "Spear") 
		{
			enemyHealth -= 3; // take away one health point
		}

		// checks to see if the skeleton was shot at with a bullet
		if (other.gameObject.tag == "Bullet") 
		{
			enemyHealth -= 1; // take away one health points
			skeletonSound.PlayOneShot(hitSound,1f); // plays the hit sound
		}
	}
}


