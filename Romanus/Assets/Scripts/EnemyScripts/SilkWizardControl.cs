using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SilkWizardControl : MonoBehaviour 
{
	public int silkHealth; // health for the silk wizard

	public GameObject orbPrefab; // var to hold prefab for instantiating orbs

	public GameObject player; // var to hold prefab for player object

	public float distanceBtwObjects; // shows the distance between player & silk wizard

	public float speed = 10f; // speed ship is moving
	float movingLeft = 127f; // distance before the wizard changes direction
	float movingRight = 137f; // distance before the wizard changes direction

	float chanceDirectionChange = 0.04f; // how likely ship will change direction

	public float secsBetweenLaunch = 4f; // rate that we generate orbs from the ship

	void Start()
	{
		InvokeRepeating("LaunchOrb", 2f, secsBetweenLaunch);  //calls a function every x secs 2f from start of game
	}

	void LaunchOrb() 
	{
		GameObject orb = Instantiate (orbPrefab) as GameObject; // create reference to hold game object
		orb.transform.position = new Vector2 (transform.position.x,transform.position.y - 2);
	}

	// Update is called once per frame
	void Update () 
	{

		distanceBtwObjects = this.gameObject.transform.position.x - player.transform.position.x;

		if (silkHealth <= 0)
		{
			Destroy (this.gameObject);
		}

		if (distanceBtwObjects <= 10) 
		{
			Vector2 pos = transform.position; // create a var to hold current position
			pos.x += speed * Time.deltaTime; // sets the xpos of our ship to the speed var * sec since last frame
			transform.position = pos;

			if (pos.x > movingRight) 
			{ // if the ship pos is greater than 163f set speed to a pos number
				speed = -Mathf.Abs (speed); 
			} 

			else if (pos.x < movingLeft) 
			{
				speed = Mathf.Abs (speed);  // if the ship pos x is less than 152f, reverse speed
			}

		}
	}

	void FixedUpdate() 
	{
		if (Random.value < chanceDirectionChange) // change direction at a random interval
		{  
			speed *= -1;
		}
	}

	void OnCollisionEnter2D (Collision2D other)
	{
		if (other.gameObject.tag == "Spear") 
		{
			silkHealth -= 3;
		}
	}
}
