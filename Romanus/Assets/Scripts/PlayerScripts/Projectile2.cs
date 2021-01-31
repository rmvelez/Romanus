using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile2 : MonoBehaviour
{
   public float speed; // var that controls speed of the bullet

    void Update()
	{
		// makes the bullet move when spawned
		transform.Translate (transform.right * -speed * Time.deltaTime);
	}

	// function used to check for collisions with various objects
	void OnCollisionEnter2D (Collision2D other)
	{
		// checks to see if the bullet collided with a skeleton
		if (other.gameObject.tag == "Skeleton") 
		{
			Destroy (this.gameObject); // destroys the bullet
		}

		// checks to see if the bullet collided with a Potion
		if (other.gameObject.tag == "Potion") 
		{
			Destroy (this.gameObject); // destroys the bullet
		}

		// checks to see if the bullet collided with a 1-Up
		if (other.gameObject.tag == "1-Up") 
		{
			Destroy (this.gameObject); // destroys the bullet
		}

		// checks to see if the bullet collided with a Dark-Hound
		if (other.gameObject.tag == "Dark-Hound") 
		{
			Destroy (this.gameObject); // destroys the bullet
		}

		// checks to see if the bullet collided with a PumpkinBat
		if (other.gameObject.tag == "PumpkinBat") 
		{
			Destroy (this.gameObject); // destroys the bullet
		}
		 
		// checks to see if the bullet collided with the Hawk-Knight
		if (other.gameObject.tag == "Hawk-Knight") 
		{
			Destroy (this.gameObject); // destroys the bullet
		}

		// checks to see if the bullet collided with a Wall
		if (other.gameObject.tag == "Wall") 
		{
			Destroy (this.gameObject); // destroys the bullet
		}

		// checks to see if the bullet collided with a platform
		if (other.gameObject.tag == "Platform") 
		{
			Destroy (this.gameObject); // destroys the bullet
		}

		// checks to see if the bullet collided with a platform
		if (other.gameObject.tag == "Trap") 
		{
			Destroy (this.gameObject); // destroys the bullet
		}

		// checks to see if the bullet collided with a Boss Key
		if (other.gameObject.tag == "BossKey") 
		{
			Destroy (this.gameObject); // destroys the bullet
		}

		// checks to see if the bullet collided with a SnapierSnake
		if (other.gameObject.tag == "SnapierSnake") 
		{
			Destroy (this.gameObject); // destroys the bullet
		}

		// checks to see if the bullet collided with a Gate
		if (other.gameObject.tag == "Gate") 
		{
			Destroy (this.gameObject); // destroys the bullet
		}

		// checks to see if the bullet collided with a Floor
		if (other.gameObject.tag == "Floor") 
		{
			Destroy (this.gameObject); // destroys the bullet
		}

		// checks to see if the bullet collided with a Boss Gate
		if (other.gameObject.tag == "BossGate") 
		{
			Destroy (this.gameObject); // destroys the bullet
		}

		// checks to see if the bullet collided with a Spike
		if (other.gameObject.tag == "Spike") 
		{
			Destroy (this.gameObject); // destroys the bullet
		}

		// checks to see if the bullet collided with a Sentry
		if (other.gameObject.tag == "Sentry") 
		{
			Destroy (this.gameObject); // destroys the bullet
		}

		// checks to see if the bullet collided with a Laser cat
		if (other.gameObject.tag == "Laser-Cat") 
		{
			Destroy (this.gameObject); // destroys the bullet
		}
			
		// checks to see if the bullet collided with Medusa's 1st form
		if (other.gameObject.tag == "Medusa1stForm") 
		{
			Destroy (this.gameObject); // destroys the bullet
		}

		// checks to see if the bullet collided with Medusa's 2nd form
		if (other.gameObject.tag == "Medusa2ndForm") 
		{
			Destroy (this.gameObject); // destroys the bullet
		}

		// checks to see if the bullet collided with Rollie Killer
		if (other.gameObject.tag == "RollieKiller") 
		{
			Destroy (this.gameObject); // destroys the bullet
		}

		// checks to see if the bullet collided with Future Portal
		if (other.gameObject.tag == "FuturePortal") 
		{
			Destroy (this.gameObject); // destroys the bullet
		}

		// checks to see if the bullet collided with Past Portal
		if (other.gameObject.tag == "PastPortal") 
		{
			Destroy (this.gameObject); // destroys the bullet
		}

		// checks to see if the bullet collided with Guard A
		if (other.gameObject.tag == "GuardA") 
		{
			Destroy (this.gameObject); // destroys the bullet
		}

		// checks to see if the bullet collided with Guard B
		if (other.gameObject.tag == "GuardB") 
		{
			Destroy (this.gameObject); // destroys the bullet
		}

		// checks to see if the bullet collided with Guard C
		if (other.gameObject.tag == "GuardC") 
		{
			Destroy (this.gameObject); // destroys the bullet
		}

		// checks to see if the bullet collided with the Endzone
		if (other.gameObject.tag == "Endzone") 
		{
			Destroy (this.gameObject); // destroys the bullet
		}

		// checks to see if the bullet collided with the Silk Wizard
		if (other.gameObject.tag == "SilkWizard") 
		{
			Destroy (this.gameObject); // destroys the bullet
		}

		// checks to see if the bullet collided with Dimitri
		if (other.gameObject.tag == "Dimitri") 
		{
			Destroy (this.gameObject); // destroys the bullet
		}
	}
}
