using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour {

	public float speed; // var that controls speed of the bullet

	private Transform target; // what the enemy will chase after

	// Use this for initialization
	void Start () {

		// the enemy will search for the object called player
		target = GameObject.FindGameObjectWithTag("Spot").GetComponent<Transform>();	
	}

	void Update()
	{
		// this will set up enemy's target, movement, and speed
		transform.position = Vector2.MoveTowards (transform.position, target.position, speed * Time.deltaTime);
	}

	// function used to check for collisions with various objects
	void OnCollisionEnter2D (Collision2D other)
	{
		// checks to see if the laser hit a platform
		if (other.gameObject.tag == "Platform") 
		{
			Destroy (this.gameObject); // destroys the laser
		}

		// checks to see if the laser hit the player
		if (other.gameObject.tag == "Player") 
		{
			Destroy (this.gameObject); // destroys the laser
		}

		// checks to see if the bullet collided with Guard A
		if (other.gameObject.tag == "GuardA") 
		{
			Destroy (this.gameObject); // destroys the laser
		}

		// checks to see if the bullet collided with Guard B
		if (other.gameObject.tag == "GuardB") 
		{
			Destroy (this.gameObject); // destroys the laser
		}

		// checks to see if the bullet collided with Guard A
		if (other.gameObject.tag == "Spot") 
		{
			Destroy (this.gameObject); // destroys the laser
		}
	}
}

