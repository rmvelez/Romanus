using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RagingDemon : MonoBehaviour {

    public int RagingDemonHealth; // Raging Demon's health 
    public GameObject RagingDemonWeapon; // Raging Demon's melee weapon
    public GameObject RagingDemonWeapon2; // Raging Demon's melee weapon
    public GameObject player; // slot for the player

    public float speed; // controls how fast The Raging Demon moves while in this form
    public float distanceBetweenObjects; // tracks distance

    public float startTimeBtwStabs; // initial time for when he attacks
    private float timeBtwStabs; // time after initial attack
    private float durationTime; // how long the attack will last for
    private Transform target; // tracks where the player is

    public AudioClip stabSound; // sound for when the Sentry shoots the player
    public AudioClip hitSound; // sound for when the Sentry gets damaged
    private AudioSource humanSound; // reference to the audio source

    // Start is called before the first frame update
    void Start()
    {
        RagingDemonHealth = 10; // gives The Raging Demon 10 hp

        RagingDemonWeapon.gameObject.SetActive(false); // sets the weapon false
        RagingDemonWeapon2.gameObject.SetActive(false); // sets the weapon false

        // sets target to where the player is
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        humanSound = GetComponent<AudioSource>(); // gets the audio source component on the demon
    }

    // Update is called once per frame
    void Update()
    {
        // sets this var to be the difference between the Raging Demon and the player
        distanceBetweenObjects = this.gameObject.transform.position.x - player.transform.position.x;

        // checks to see if The Raging Demon ran out of health
        if (RagingDemonHealth <= 0)
        {
            Destroy(this.gameObject); // The Raging Demon disappears
        }

        // checks to see if the player is close enought
        if (distanceBetweenObjects < 12)
        {
            // The Raging Demon will move towards the player
            transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);

            //checks to see if this variable is less than or equal to zero
            if (timeBtwStabs <= 0)
            {
                // makes his weapon appear
                RagingDemonWeapon.gameObject.SetActive(true);
                RagingDemonWeapon2.gameObject.SetActive(true);
                humanSound.PlayOneShot(stabSound, 1f);

                durationTime = 15f; // sets this timer to fifteen seconds

                timeBtwStabs = startTimeBtwStabs; // sets this variable back to its initial value
            }

            //checks to see if this timer is equal to zero
            if (durationTime <= 0)
            {
                RagingDemonWeapon.gameObject.SetActive(false); // makes her weapon disappear
                RagingDemonWeapon2.gameObject.SetActive(false); // makes her weapon disappear

                timeBtwStabs -= Time.deltaTime; // decreases this variable over real time
            }
        }

        durationTime -= 1f; // decreases this value by 1 second
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        // checks to see if The Raging Demon was hit by the Bullet
        if (other.gameObject.tag == "Spear")
        {
            transform.position = new Vector2(transform.position.x + 4, transform.position.y); // pushes him back
            RagingDemonHealth -= 1; // decreases his health by 1
            humanSound.PlayOneShot(hitSound, 1f); // plays the hurt sound
        }
    }
}
