using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack3 : MonoBehaviour {

	public GameObject projectile; // slot for the bullet
    public GameObject projectile2; // slot for the bullet
    public Transform shotPoint; // place where the Spear is spawned
 
    private float timeBtwShots; // time between when players can use the Spear
    public float startTimeBtwShots; // the initial time for when players can attack with the Spear

    public AudioClip shootSound; // sound for the bullets
    private AudioSource attackSound; // used to play the sounds
	public PlayerMovement playerMovement; // reference to the player movement script

	Animator myAnimator; 
	public bool isAttacking = false;

    void Start()
    {
        attackSound = GetComponent<AudioSource>(); // looks for audio source
		playerMovement = GetComponent<PlayerMovement>(); // gets the player movement script
		myAnimator = GetComponent<Animator>();
    }

    void Update()
    {
		myAnimator.SetBool ("isCannonAttack", isAttacking);

        // checks to see if the player is foreward, the buster is ready and the other attack button has been pressed
		if (playerMovement.isForward == true && timeBtwShots <= 0 && Input.GetKeyDown(KeyCode.X))
        {
            Instantiate(projectile, shotPoint.position, projectile.transform.rotation); // fires a bullet
            attackSound.PlayOneShot(shootSound, 1f); // plays shoot sound
            timeBtwShots = startTimeBtwShots; // sets timeBtwAttack to the start time variable
			isAttacking = true;
        }

		// checks to see if the player is not foreward, the buster is ready and the other attack button has been pressed
		else if (playerMovement.isForward == false && timeBtwShots <= 0 && Input.GetKeyDown(KeyCode.X))
        {
            Instantiate(projectile2, shotPoint.position, projectile2.transform.rotation); // fires a bullet
            attackSound.PlayOneShot(shootSound, 1f); // plays shoot sound
            timeBtwShots = startTimeBtwShots; // sets timeBtwAttack to the start time variable
			isAttacking = true;
        }

		// checks to see if the player is shooting while standing still
		else if (Input.GetAxis("Horizontal") == 0 && timeBtwShots <= 0 && Input.GetKeyDown(KeyCode.X)) 
		{
			Instantiate(projectile, shotPoint.position, projectile.transform.rotation); // spawns a bullet
			timeBtwShots = startTimeBtwShots; // sets timeBtwAttack to the start time variable
			isAttacking = true;
		}

        else // runs when the previous statement is false
        {
            timeBtwShots -= Time.deltaTime; // decreases this variable over time
			isAttacking = false;
        }
    }
}

