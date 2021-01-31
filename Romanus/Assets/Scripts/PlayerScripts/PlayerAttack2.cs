using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack2 : MonoBehaviour {

   // public GameObject playerObject; //  
    public GameObject weapon; // slot for the Silver Spear
    public GameObject weapon2; // slot for the Silver Spear 2
    public Transform meleePoint; // place where the Spear is spawned
    
    private float timeBtwAttack; // time between when players can use the Spear
    public float startTimeBtwAttack; // the initial time for when players can attack with the Spear

    public AudioClip stabSound; // sound for the spear
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
		myAnimator.SetBool ("isSpearAttack", isAttacking);

       // checks to see is the player is foreward, the spear is ready to attack, and the attack button was pressed
        if (playerMovement.isForward == true && timeBtwAttack <= 0 && Input.GetKeyDown(KeyCode.Z))
        {
            Instantiate(weapon, meleePoint.position, weapon.transform.rotation); // makes the Silver Spear appear
            attackSound.PlayOneShot(stabSound, 1f); // plays stab sound
            timeBtwAttack = startTimeBtwAttack; // sets timeBtwAttack to the start time variable
			isAttacking = true;
        }

		// checks to see if the player is not facing foreward, the spear is ready to be used, and the attack button was pressed
        else if (playerMovement.isForward == false && timeBtwAttack <= 0 && Input.GetKeyDown(KeyCode.Z)) 
        {
            Instantiate(weapon2, meleePoint.position, weapon2.transform.rotation); // makes the Silver Spear appear
            attackSound.PlayOneShot(stabSound, 1f); // plays stab sound
            timeBtwAttack = startTimeBtwAttack; // sets timeBtwAttack to the start time variable
			isAttacking = true;
        } 

		// checks to see if the player attacks while not moving
		else if (Input.GetAxis("Horizontal") == 0 && timeBtwAttack <= 0 && Input.GetKeyDown(KeyCode.Z)) 
        {
            Instantiate(weapon, meleePoint.position, weapon.transform.rotation);
			timeBtwAttack = startTimeBtwAttack; // sets timeBtwAttack to the start time variable
			isAttacking = true;
        }
       
		// runs when all the other if statements are false
		else  
        {
            timeBtwAttack -= Time.deltaTime; // decreases this variable over time
			isAttacking = false;
        }
    }
}