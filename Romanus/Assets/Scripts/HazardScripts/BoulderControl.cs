using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoulderControl : MonoBehaviour
{
	// checks for collisions with other game objects
    void OnCollisionEnter2D(Collision2D other)
    {
        // checks to see if the Boulder collided with the player
        if (other.gameObject.tag == "Player")
        {
            Destroy(this.gameObject); // eliminates the Boulder
        }

		// checks to see if the Boulder landed on the floor
        if (other.gameObject.tag == "Wall")
        {
            Destroy(this.gameObject); // eliminates the Boulder when it touches the ground
        }

    }

}
