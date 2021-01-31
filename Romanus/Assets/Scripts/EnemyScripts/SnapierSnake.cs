using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnapierSnake : MonoBehaviour
{
	public float speed; // controls how fast the snake goes
	public GameObject player; // reference to the player
	public int snakeHealth; // the snake's health

	public float distanceBetweenObjects; // used to check distance between the snake and the player

    // Update is called once per frame
    void Update()
    {
		// sets this variable to be the distance between the snake and the player
		distanceBetweenObjects = transform.position.x - player.transform.position.x;

		// checks to see if the player is at least 12 units away
		if (distanceBetweenObjects <= 12) 
		{
			// moves towards the player
			transform.position = new Vector2 (transform.position.x - speed * Time.deltaTime, transform.position.y);
		}

		// checks to see if the snake lost all of its health
		if (snakeHealth <= 0) 
		{
			Destroy (this.gameObject); // kill the snake
		}
    }

	// used to check for collisions with other game objects
	void OnCollisionEnter2D (Collision2D other)
	{
		// checks to see if the snake has hit the player
		if (other.gameObject.tag == "Player") 
		{
			snakeHealth -= 1; // the snake loses one point of health
		}
	}
}
