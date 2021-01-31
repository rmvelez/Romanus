using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecondHazard : MonoBehaviour {

	public GameObject laser; // the laser itself
	public Transform laserPoint; // place where lasers spawn from
	private float timeBtwShots; // time it shoots for
	public float startTimeBtwShots; // initial shooting time

	public GameObject player; // slot for player
	public float distanceBetweenObjects; // tracks distance between player and cannon

	public AudioClip laserSound; // sound for the lasers
	private AudioSource laserCannon; // var that plays the sound

	// Use this for initialization
	void Start () {
		laserCannon = GetComponent<AudioSource> (); // looks for the audio source
	}
	
	// Update is called once per frame
	void Update () {

		// sets the distance between the enemy and the player
		distanceBetweenObjects = this.gameObject.transform.position.x - player.transform.position.x;

		// checks to see if the player is 6 units away and timeBtwShots is less than or equal to zero
		if (timeBtwShots <= 0 && distanceBetweenObjects < 6) 
		{
			// create a laser that can damage the player
			Instantiate (laser, laserPoint.position, transform.rotation);
			laserCannon.PlayOneShot (laserSound, 1f);
			timeBtwShots = startTimeBtwShots; // set these two variables equal to each other
		} 

		else // when if is false
		{
			timeBtwShots -= Time.deltaTime; // decrease this value over real time
		}

		// checks to see if the player went past the cannon
		if (distanceBetweenObjects <= 0) 
		{
			laserCannon.Stop (); // stops shooting bullets
		}
	}
}