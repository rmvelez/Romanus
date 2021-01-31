using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoulderTrap : MonoBehaviour {

public GameObject Net; // slot for the net that holds the bolder in place

	// checks for collision with other game objects
    void OnCollisionEnter2D(Collision2D other)
    {
		// checks to see if the player hit the switch
        if (other.gameObject.tag == "Player")
        {
            Destroy(this.gameObject); // the switch dissapears
            Destroy(Net); // the net is destroyed so that the bolder can fall
        }
    }
}
