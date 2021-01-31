using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TeufelControl : MonoBehaviour
{
	public float speed; // controls how fast Teufel moves
	public int bossHealth; // int that tracks Trufel's health

	public GameObject player; // slot for the player
	public float distanceBetweenObjects; // checks the distance between Teufel and the player
	private Transform target; // used to find the player

	public Transform firePoint; // place where fireballs will be shot
	public GameObject fireBall; // the fireball objects that will be fired
	private float timeBtwShots; // time after initial shot
	public float startTimeBtwShots; // initial time for when she shoots

    // Start is called before the first frame update
    void Start()
    {
		// sets target to the transform position of the player
		target = GameObject.FindGameObjectWithTag ("Player").GetComponent<Transform> ();
    }

    // Update is called once per frame
    void Update()
    {
		// checks to see if Teufel's health has been depleted
		if (bossHealth <= 0) 
		{
			Destroy (this.gameObject); // Teufel is dead
			SceneManager.LoadScene ("CutsceneTwo"); // loads the next cutscene
		}

		// sets distance between objects to be the difference between Teufel's position and that of the player
		distanceBetweenObjects = transform.position.x - player.transform.position.x;

		// checks to see if the player is at least 10 units away from Teufel
		if (distanceBetweenObjects < 10) 
		{
			// makes teufel move towards the player
			transform.position = Vector2.MoveTowards (transform.position, target.position, speed * Time.deltaTime);
		}

		// checks to see if the player is at least 8 units away from Teufel
		if (distanceBetweenObjects < 8 && timeBtwShots <= 0) 
		{
			// makes a fireball
			Instantiate (fireBall, firePoint.position, transform.rotation);
			timeBtwShots = startTimeBtwShots; // sets the time var back to its initial value
		} 

		// runs when all the other statements are false
		else 
		{
			timeBtwShots -= Time.deltaTime; // decreases this value over real time
		}
    }

	// used to check for collisions with various game objects
	void OnCollisionEnter2D (Collision2D other)
	{
		// checks to see if the spear has hit Teufel
		if (other.gameObject.tag == "Spear") 
		{
			bossHealth -= 1; // he loses one point of health
			transform.position = new Vector2 (transform.position.x + 1, transform.position.y); // he moves back a bit
		}
	}
}
