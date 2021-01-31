using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldedGuard : MonoBehaviour
{
	private int guardHealth; // int used to track the health of the shielded guard

	public GameObject guardBullet; // slot for the guard's bullet
	public Transform bulletSpawner; // slot that spawns the bullets
	private float timeBtwShots; // time between when the bullets have been shot
	public float startTimeBtwShots; // initial time for when bullets have been shot

	public float distanceBetweenObjects; // tracks the distance between this enemy and the player
	public GameObject player; // slot for the player

	private AudioSource shieldSound; // source where the sounds come from
	public AudioClip shootSound; // sound that plays when the guard fires a bullet
	public AudioClip hurtSound; // sound that plays when the guard has been hit

    // Start is called before the first frame update
    void Start()
    {
		guardHealth = 3; // the guard starts off with three points of health
		shieldSound = GetComponent<AudioSource>(); // gets the audio source to play the sounds
    }

    // Update is called once per frame
    void Update()
    {
		// checks to see if the guard lost all of it's health
		if (guardHealth <= 0) 
		{
			Destroy (this.gameObject); // this guard is dead
		}

		// sets this var to the distance between this guard and the player
		distanceBetweenObjects = transform.position.x - player.transform.position.x;

		// checks to see if the player is at least 10 units away and the enemy can fire
		if (distanceBetweenObjects < 10 && timeBtwShots <= 0) 
		{
			// fire the bullet
			Instantiate (guardBullet, bulletSpawner.position, transform.rotation);
			shieldSound.PlayOneShot (shootSound, 1f); // plays the shoot sound
			timeBtwShots = startTimeBtwShots; // sets this variable to its initial value
		}

		// runs when the previous statement is false
		else 
		{
			timeBtwShots -= Time.deltaTime; // decreases this value over time
		}
    }

	// used to check for collisions with other game objects
	void OnCollisionEnter2D(Collision2D other)
	{
		// checks to see if the guard got shot
		if (other.gameObject.tag == "Bullet") 
		{
			guardHealth -= 1; // take away a third of it's health
			shieldSound.PlayOneShot(hurtSound, 1f);
		}

		if (other.gameObject.tag == "BarbedWire") 
		{
			guardHealth = 0;  // take away a third of it's health
		}
	}
}
