using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowControl : MonoBehaviour {

	public float speed; // speed of the arrow

	// Update is called once per frame
	void Update () 
	{
		// makes a new vector2 that increases the x value by speed
		Vector2 moveArrow = new Vector2 (transform.position.x - speed, transform.position.y);
		transform.position = moveArrow; // allows the arrow to move by speed
	}

	// checks for collsiions with other game objects
	void OnCollisionEnter2D (Collision2D other)
	{
		// checks to see if the arrow collided with the player
		if (other.gameObject.tag == "Player") 
		{
			Destroy (this.gameObject); // eliminates the arrow
		}

		// checks to see if the arrow collided with a gate
		if (other.gameObject.tag == "Gate") 
		{
			Destroy (this.gameObject); // eliminates the arrow
		}

		// checks to see if the arrow collided with a gate
		if (other.gameObject.tag == "Wall") 
		{
			Destroy (this.gameObject); // eliminates the arrow
		}

		// checks to see if the arrow collided with a Sentry
		if (other.gameObject.tag == "Sentry") 
		{
			Destroy (this.gameObject); // eliminates the arrow
		}

		// checks to see if the arrow collided with the BossGate
		if (other.gameObject.tag == "BossGate") 
		{
			Destroy (this.gameObject); // eliminates the arrow
		}

		// checks to see if the bullet collided with a platform
		if (other.gameObject.tag == "Trap") 
		{
			Destroy (this.gameObject); // destroys the arrow
		}

		// checks to see if the bullet collided with Guard A
		if (other.gameObject.tag == "GuardA") 
		{
			Destroy (this.gameObject); // destroys the arrow
		}

		// checks to see if the bullet collided with Guard B
		if (other.gameObject.tag == "GuardB") 
		{
			Destroy (this.gameObject); // destroys the arrow
		}

		// checks to see if the bullet collided with Guard B
		if (other.gameObject.tag == "Platform") 
		{
			Destroy (this.gameObject); // destroys the arrow
		}
	}
}
