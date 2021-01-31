using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingPlatform : MonoBehaviour {

	void OnCollisionEnter2D (Collision2D other)
	{
		// checks to see if the platform collided with the player
		if (other.gameObject.tag == "Player") 
		{
			this.gameObject.AddComponent<Rigidbody2D> (); // give it a 2D rigidbody so that it will fall
		}

		// checks to see if the platform collided with the player
		if (other.gameObject.tag == "RollieKiller") 
		{
			this.gameObject.AddComponent<Rigidbody2D> (); // give it a 2D rigidbody so that it will fall
		}

		// checks to see if this platform collided with a mine
		if (other.gameObject.tag == "Mine") 
		{
			Destroy (this.gameObject); // destroys it
		}

		// checks to see if the platform landed on the barbed wire
		if (other.gameObject.tag == "BarbedWire") 
		{
			Destroy (this.gameObject); // destroys it
		}
	}
}
