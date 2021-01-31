using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DimitriControl : MonoBehaviour {

	public float jumpforce = 1f;
	public float speed = -2f; //how fast he goes
	public bool grounded = false; // checks to see if Dimitri is touching the ground
	public GameObject groundCheck = null;
	public int enemyHealth; // var that tracks enemy health
	public GameObject player; //slot for the player

	private Rigidbody2D MyRb; //need a body to jump
	private float horizontal; 
	private Transform target; // what the enemy will chase after
	public float distanceBetweenObjects; // checks to see the distance between Dimitri and the object

    // Start is called before the first frame update
    void Start()
    {
		MyRb = GetComponent<Rigidbody2D> (); //connect ref to rigidbody

		// the enemy will search for the object called player
		target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
       // sets the distance between the enemy and the player
		distanceBetweenObjects = this.gameObject.transform.position.x - player.transform.position.x;

		if (distanceBetweenObjects < 8)
		{
			// this will set up enemy's target, movement, and speed
			transform.position = Vector2.MoveTowards (transform.position, target.position, speed * Time.deltaTime);
		}

		// checks to see if the enemy's health is zero
		if (enemyHealth <= 0) 
		{
			SceneManager.LoadScene("CutsceneFive");
		}
    }

    void OnCollisionEnter2D (Collision2D other) 
	{
		// checks to see if the skeleton was hit by a spear
		if (other.gameObject.tag == "Spear") 
		{
			transform.position = new Vector2(transform.position.x + 1, transform.position.y); // pushes him back
		}

		// checks to see if the skeleton was shot at with a bullet
		if (other.gameObject.tag == "Bullet") 
		{
			enemyHealth -= 2; // take away one health point
		}
	}

	void OnTriggerEnter2D (Collider2D col)
	{
		
	}
}
