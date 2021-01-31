using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMoveScript : MonoBehaviour
{
	public float speed;

    // Update is called once per frame
    void Update()
    {
		GetComponent<Rigidbody2D>().velocity = new Vector2(-speed,0);
    }

	void OnCollisionEnter2D (Collision2D other) 
	{
		if (other.gameObject.tag == "Portal") 
		{
			Destroy(this.gameObject);
			Destroy(other.gameObject);
		}
	}
}
