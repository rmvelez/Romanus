using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowLauncher : MonoBehaviour {

	public GameObject Arrow; // slot for the arrow prefab
	public Transform arrowSpawner; // slot for object that will spawn arrows
	public GameObject player; // slot for the player
	public float distanceBetweenObjects; // checks the distance between this object and the player

	private float timeBtwShots; // time between when arrows have been shot
	public float startTimeBetweenShots; // initial time when arrows are launched
	
	// Update is called once per frame
	void Update () {
		
		// sets this variable to the difference of these two objects
		distanceBetweenObjects = this.gameObject.transform.position.x - player.transform.position.x;

		// checks to see if the distance between the objects is less than 13
		if (timeBtwShots <= 0 && distanceBetweenObjects < 13) 
		{
			Instantiate (Arrow, arrowSpawner.position, transform.rotation); // creates an arrow
			timeBtwShots = startTimeBetweenShots; // sets these two variables equal to each other
		} 
		else // runs when the if statement is false
		{
			timeBtwShots -= Time.deltaTime; // decreases this value over real time
		}
	}
}
