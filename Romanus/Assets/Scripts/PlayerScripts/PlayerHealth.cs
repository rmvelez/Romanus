using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PlayerHealth : MonoBehaviour {

	public int playerHealth; // var that tracks the player's health
	public int playerLives; // var that holds player lives
	public Text playerHealthText; // var that displays health
	public Text playerLivesText; // var that displays lives

	private bool hasKey = false; // checks to see if players have the boss key

	public AudioClip hurtSound; // sound for when player gets hit
	public AudioClip deathSound; // sound for when players lose a life
	public AudioClip itemFoundSound; // sound that plays when an item has been found
	public AudioClip itemUsedSound; // sound that plays when an item has been used
	private AudioSource healthSound; // reference to audio source

	public PlayerMovement playerMovement; // reference to the player movement script
	public bool isDead; // bool used to determine if the player has died
	
	// Use this for initialization
	void Start () 
	{
		playerHealthText.text = "Health: " + playerHealth; // displays health
		playerLivesText.text = "Lives: " + playerLives; // displays amount of lives
		healthSound = GetComponent<AudioSource>(); // looks for the audio source
		playerMovement = GetComponent<PlayerMovement>(); // looks for the script
		isDead = false; // the player is not dead
	}
	
	// Update is called once per frame
	void Update () 
	{
		// checks to see if the player lost all of their health
		if (playerHealth <= 0)
		{
			playerMovement.portalTwo = true; // sets the second portal to true
			playerMovement.portalOne = false; // sets the first portal to flase
			// the camera is reset when the player dies
			RespawnPlayer (); // calls the function that respawns the player
			
		}

		// checks to see if the player lost all of their lives
		if (playerLives == 0) 
		{
			this.gameObject.SetActive (false); // the player object is inactive
			isDead = true; // the player is dead
		} 
	}

	public void RespawnPlayer() 
	{
		Vector2 Respawn = new Vector2 (-5.3f,-3.1f); // new location to bring back the player
		transform.position = Respawn; // sets the player's position to the respawn point			
		playerLives -= 1; // the player loese one life
		playerHealth = 12; // the player regains their health
		healthSound.PlayOneShot(deathSound,1f); // plays death sound
		playerHealthText.text = "Health: " + playerHealth; // displays health
		playerLivesText.text = "Lives: " + playerLives; // displays amount of lives
	}

	// this function is used to check for collisions
	void OnCollisionEnter2D (Collision2D other) 
	{
		// checks to see if the enemy is a skeleton
		if (other.gameObject.tag == "Skeleton") 
		{
			playerHealth -= 1; // take away one health point
			healthSound.PlayOneShot(hurtSound,1f); // plays hurt sound
			playerHealthText.text = "Health: " + playerHealth; // displays health
		}

		// checks to see if the enemy is a skeleton
		if (other.gameObject.tag == "GuardC") 
		{
			playerHealth -= 1; // take away one health point
			healthSound.PlayOneShot(hurtSound,1f); // plays hurt sound
			playerHealthText.text = "Health: " + playerHealth; // displays health
		}

		// checks to see if the enemy is a Silk Wizard
		if (other.gameObject.tag == "SilkWizard") 
		{
			playerHealth -= 3; // take away one health point
			healthSound.PlayOneShot(hurtSound,1f); // plays hurt sound
			playerHealthText.text = "Health: " + playerHealth; // displays health
		}

		// checks to see if the player was hit by one of the future skeleton's bullets
		if (other.gameObject.tag == "SkeletonBullet") 
		{
			playerHealth -= 1; // take away one health point
			healthSound.PlayOneShot(hurtSound,1f); // plays hurt sound
			playerHealthText.text = "Health: " + playerHealth; // update text field
		}

		// checks to see if the player was hit by one of the silk wizard's orbs
		if (other.gameObject.tag == "SilkWizardOrb") 
		{
			playerHealth -= 1; // take away one health point
			healthSound.PlayOneShot(hurtSound,1f); // plays hurt sound
			playerHealthText.text = "Health: " + playerHealth; // update text field
		}

		// checks to see if the player collided with the Dark-Hound
		if (other.gameObject.tag == "Dark-Hound") 
		{
			playerHealth -= 2; // takes away two points of health
			healthSound.PlayOneShot(hurtSound,1f); // plays hurt sound
			playerHealthText.text = "Health: " + playerHealth; // displays health
		}

		// checks to see if the player collided with the PumpkinBat
		if (other.gameObject.tag == "PumpkinBat") 
		{
			playerHealth -= 1; // takes away one point of health
			healthSound.PlayOneShot(hurtSound,1f); // plays hurt sound
			playerHealthText.text = "Health: " + playerHealth; // displays health
		}

		// checks to see if the player collided with the Hawk-Knight
		if (other.gameObject.tag == "Hawk-Knight") 
		{
			playerHealth -= 3; // takes away two points of health
			healthSound.PlayOneShot(hurtSound,1f); // plays hurt sound
			playerHealthText.text = "Health: " + playerHealth; // displays health
		}

		// checks to see if the player collided with a spike
		if (other.gameObject.tag == "Spike") 
		{
			playerHealth = 0; // player is dead
		}

		// checks to see if the player collided with BarbedWire
		if (other.gameObject.tag == "BarbedWire") 
		{
			playerHealth = 0; // player is dead
		
		}

		// checks to see if the player collided with RollieKiller
		if (other.gameObject.tag == "RollieKiller") 
		{
			playerHealth = 0; // player is dead
		}

		// checsk to see if the player was shot with an arrow
		if (other.gameObject.tag == "Arrow") 
		{
			playerHealth -= 1; // take away one health point
			healthSound.PlayOneShot(hurtSound,1f); // plays hurt sound
			playerHealthText.text = "Health: " + playerHealth; // update text field
		}

		// checsk to see if the player was shot with Silk Wizard orb
		if (other.gameObject.tag == "SilkWizardOrb") 
		{
			playerHealth -= 2; // take away one health point
			healthSound.PlayOneShot(hurtSound,1f); // plays hurt sound
			playerHealthText.text = "Health: " + playerHealth; // update text field
		}

        // checsk to see if the player was hit by boulder
        if (other.gameObject.tag == "Boulder")
        {
            playerHealth = 0; // take away one health point
            healthSound.PlayOneShot(hurtSound, 1f); // plays hurt sound
            playerHealthText.text = "Health: " + playerHealth; // update text field
        }

        // checsk to see if the player was shot with a laser
        if (other.gameObject.tag == "Laser") 
		{
			playerHealth -= 1; // take away one health point
			healthSound.PlayOneShot(hurtSound,1f); // plays hurt sound
			playerHealthText.text = "Health: " + playerHealth; // update text field
		}

		// checks to see if the player was hit by the sentry
		if (other.gameObject.tag == "Sentry") 
		{
			playerHealth -= 1; // take away three health points
			healthSound.PlayOneShot(hurtSound,1f); // plays hurt sound
			playerHealthText.text = "Health: " + playerHealth; // update text field
		}

		// checks to see if the player was hit by the Laser-Cat
		if (other.gameObject.tag == "Laser-Cat") 
		{
			playerHealth -= 2; // take away two health points
			healthSound.PlayOneShot(hurtSound,1f); // plays hurt sound
			playerHealthText.text = "Health: " + playerHealth; // update text field
		}

		// checks to see if the player was hit by one of the sentry's bullets
		if (other.gameObject.tag == "SentryBullet") 
		{
			playerHealth -= 1; // take away one health point
			healthSound.PlayOneShot(hurtSound,1f); // plays hurt sound
			playerHealthText.text = "Health: " + playerHealth; // update text field
		}

		// checks to see if the player was hit by the snapier snake
		if (other.gameObject.tag == "SnapierSnake") 
		{
			transform.position = new Vector2 (transform.position.x - 1, transform.position.y); // pushes the player back
			playerHealth -= 1; // the player loses one point of health
			healthSound.PlayOneShot (hurtSound, 1f); // plays the hurt sound
			playerHealthText.text = "Health " + playerHealth; // updates the health text
		}

		// checks to see if the player was attacked by Medusa while in her 1st form
		if (other.gameObject.tag == "Medusa1stForm") 
		{
			playerHealth -= 2; // take away two health points
			healthSound.PlayOneShot(hurtSound,1f); // plays hurt sound
			playerHealthText.text = "Health: " + playerHealth; // update text field
		}

        // checks to see if the player was attacked by The Raging Demon
        if (other.gameObject.tag == "RagingDemon")
        {
            playerHealth -= 3; // take away two health points
            healthSound.PlayOneShot(hurtSound, 1f); // plays hurt sound
            playerHealthText.text = "Health: " + playerHealth; // update text field
        }

        // checks to see if the player was hit by Medusa while in her second form
        if (other.gameObject.tag == "Medusa2ndForm") 
		{
			playerHealth -= 4; // take away four health points
			healthSound.PlayOneShot(hurtSound,1f); // plays hurt sound
			playerHealthText.text = "Health: " + playerHealth; // update text field
		}

		// checks to see if the player was hit by Medusa while in her second form
		if (other.gameObject.tag == "Dimitri") 
		{
			playerHealth -= 1; // take away four health points
			healthSound.PlayOneShot(hurtSound,1f); // plays hurt sound
			playerHealthText.text = "Health: " + playerHealth; // update text field
		}

		// checks to see if the player was hit by one of Medusa's fireballs
		if (other.gameObject.tag == "FireBall") 
		{
			playerHealth -= 2; // take away four health points
			healthSound.PlayOneShot(hurtSound,1f); // plays hurt sound
			playerHealthText.text = "Health: " + playerHealth; // update text field
		}

		// checks to see if the player was hit by one of mines
		if (other.gameObject.tag == "Mine") 
		{
			transform.position = new Vector2 (transform.position.x - 2, transform.position.y + 2);
			playerHealth -= 4; // take away one health point
			playerHealthText.text = "Health: " + playerHealth; // update text field
			Destroy(other.gameObject);
		}

		// checks to see if the player was attacked by Teufel
		if (other.gameObject.tag == "Teufel") 
		{
			transform.position = new Vector2 (transform.position.x - 1, transform.position.y); // pushes the player back
			playerHealth -= 2; // the player loses two points of health
			healthSound.PlayOneShot (hurtSound, 1f); // the hurt sound plays
			playerHealthText.text = "Health: " + playerHealth; // the health text is updated
		}

		// checks to see if the player has the potion
		if (other.gameObject.tag == "Potion")
		{
			playerHealth += 3; // increases the player's HP by three
			playerHealthText.text = "Health: " + playerHealth; // updates the text field
			healthSound.PlayOneShot(itemUsedSound,1f); // plays the sound that indicates that this item has been used
			Destroy(other.gameObject); // destroys the potion
		}

		// checks to see if the player has the potion
		if (other.gameObject.tag == "1-Up")
		{
			playerLives += 1; // increases the player's Lives by one
			playerLivesText.text = "Lives: " + playerLives; // updates the text field
			healthSound.PlayOneShot(itemUsedSound,1f); // plays the sound that indicates that this item has been used
			Destroy(other.gameObject); // destroys the one up
		}

		// checks to see if the player has the key to the boss room
		if (other.gameObject.tag == "BossKey")
		{
			hasKey = true; // player has potion
			healthSound.PlayOneShot(itemFoundSound); // plays a sound to indicate that players have found an item
			other.gameObject.SetActive (false); // hides object
		}

		// checks to see if the player has the potion
		if (other.gameObject.tag == "BossGate" && hasKey == true)
		{
			other.gameObject.SetActive (false); // hides object
			healthSound.PlayOneShot(itemUsedSound,1f); // plays the sound that indicates that this item has been used
			hasKey = false; // the player no longer has the boss key
		}

		// checks to see if the player was hit by one of Medusa's fireballs
		if (other.gameObject.tag == "Dimitri") 
		{
			transform.position = new Vector2 (transform.position.x - 2, transform.position.y); // pushes the player back
			playerHealth -= 3; // take away four health points
			healthSound.PlayOneShot(hurtSound,1f); // plays hurt sound
			playerHealthText.text = "Health: " + playerHealth; // update text field
		}
	}
}
