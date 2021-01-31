using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RollieKiller : MonoBehaviour
{
   public float speed; // declare speed
	public int enemyHealth; // var that tracks enemy health
	public GameObject player; //slot for the player

	public float distanceBetweenObjects; // checks to see the distance between the player and the object
	private Transform target; // what the enemy will chase after
	

	// Use this for initialization
	void Start () {

		// the enemy will search for the object called player
		target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
		

	}
	
	// Update is called once per frame
	void Update () 
	{ 
		// sets the distance between the enemy and the player
		distanceBetweenObjects = this.gameObject.transform.position.x - player.transform.position.x;

		if (distanceBetweenObjects < 8)
		{
			// this will set up enemy's target, movement, and speed
			transform.position = Vector2.MoveTowards (transform.position, target.position, speed * Time.deltaTime);
		}

		// checks to see if the enemy's health is zero
		if (enemyHealth == 0) 
		{
			Destroy (this.gameObject); // the killer is killed
		}
	}

	// this function is used to check for collisions
	void OnCollisionEnter2D (Collision2D other) 
	{
		//checks to see if the enemy hit the barbed wire
		if (other.gameObject.tag == "BarbedWire") 
		{
			enemyHealth = 0; // health is zero
		}

		if (other.gameObject.tag == "Player") 
		{
			RespawnRollieKiller();
		}
	}

	public void RespawnRollieKiller()
	{
		Vector2 Respawn = new Vector2 (107.82f, 11.51f);
		transform.position = Respawn;
	}
}
