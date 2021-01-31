using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour {

	public GameObject projectile; // slot for the bullets
	public GameObject projectile2; // the bullets that go backwards
	public GameObject weapon; // slot for the Silver Spear
	public GameObject weapon2; // the version of the spear that faces the other way
	public Transform meleePoint; // place where the Spear is spawned
	public Transform shotPoint; // place where the bullets are spawned

	private float timeBtwShots; // time between player shots
	private float timeBtwAttack; // time between when players can use the Spear
	public float startTimeBtwShots; // the initial time for when players can shoot
	public float startTimeBtwAttack; // the initial time for when players can attack with the Spear

	public AudioClip stabSound; // sound for the spear
	public AudioClip shootSound; // sound for the bullets
	private AudioSource attackSound; // used to play the sounds
	public PlayerMovement playerMovement; //reference to player movement

	Animator myAnimator; 
	public bool isSpearAttacking = false;
	public bool isCannonAttacking = false;

	void Start()
	{
		attackSound = GetComponent<AudioSource> (); // looks for audio source
		playerMovement = GetComponent<PlayerMovement>(); // gets the player movement script from the player
		myAnimator = GetComponent<Animator>();
	}

	void Update()
	{
		myAnimator.SetBool ("isCannonAttack", isCannonAttacking);
		myAnimator.SetBool ("isSpearAttack", isSpearAttacking);
		SpearAttack (); // runs the function that lets players attack with the spear
		BusterAttack (); // runs the function that lets players attack with the buster
	}

	// the function that allows the player to attack with the silver spear
	public void SpearAttack()
	{
		// checks to see if the player is foreward when attacking
		if (playerMovement.isForward == true && timeBtwAttack <= 0 && Input.GetKeyDown (KeyCode.Z))
		{
			Instantiate (weapon, meleePoint.position, weapon.transform.rotation); // makes the Silver Spear appear
			attackSound.PlayOneShot(stabSound,1f); // plays stab sound
			timeBtwAttack = startTimeBtwAttack; // sets timeBtwAttack to the start time variable
			isSpearAttacking = true;
		} 

		// checks to see if the player isn't foreward when attacking
		else if (playerMovement.isForward == false && timeBtwAttack <= 0 && Input.GetKeyDown(KeyCode.Z))
		{
			Instantiate(weapon2, meleePoint.position, weapon2.transform.rotation); // makes the Silver Spear appear
			attackSound.PlayOneShot(stabSound, 1f); // plays stab sound
			timeBtwAttack = startTimeBtwAttack; // sets timeBtwAttack to the start time variable
			isSpearAttacking = true;
		} 

		// runs if the player is standing still while attacking
		else if (Input.GetAxis("Horizontal") == 0 && timeBtwAttack <= 0 && Input.GetKeyDown(KeyCode.Z)) 
		{
			Instantiate(weapon, meleePoint.position, weapon.transform.rotation);
			timeBtwAttack = startTimeBtwAttack; // sets timeBtwAttack to the start time variable
			isSpearAttacking = true;
		}

		else // runs when the previous statements are false
		{
			timeBtwShots -= Time.deltaTime; // decreases this variable over time
			isSpearAttacking = false;
		}
	}

	public void BusterAttack()
	{

		// checks to see if the player is facing foreward when attacking
		if (playerMovement.isForward == true && timeBtwShots <= 0 && Input.GetKeyDown (KeyCode.X)) 
		{
			Instantiate (projectile, shotPoint.position, projectile.transform.rotation); // creates the bullet
			attackSound.PlayOneShot(shootSound,1f); // plays shoot sound
			timeBtwShots = startTimeBtwShots; // sets timeBtwShots equal to the start time variable
			isCannonAttacking = true;
		} 

		// checks to see if the player is not facing foreward when attacking
		if (playerMovement.isForward == false && timeBtwShots <= 0 && Input.GetKeyDown(KeyCode.X))
		{
			Instantiate(projectile2, shotPoint.position, projectile2.transform.rotation); // makes the Silver Spear appear
			attackSound.PlayOneShot(shootSound, 1f); // plays stab sound
			timeBtwShots = startTimeBtwShots; // sets timeBtwAttack to the start time variable
			isCannonAttacking = true;
		}

		// runs if the player is standing still while attacking
		else if (Input.GetAxis("Horizontal") == 0 && timeBtwShots <= 0 && Input.GetKeyDown(KeyCode.X)) 
		{
			Instantiate(projectile, shotPoint.position, projectile.transform.rotation);
			timeBtwAttack = startTimeBtwAttack; // sets timeBtwAttack to the start time variable
			isCannonAttacking = true;
		}

		else // runs when the previous statement is false
		{
			timeBtwAttack -= Time.deltaTime; // decreases this variable over time
			isCannonAttacking = false;
		}
	}
}