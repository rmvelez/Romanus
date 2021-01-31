using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RomanusMovingRight : MonoBehaviour
{
	public float speed;

    // Update is called once per frame
    void Update()
    {
		GetComponent<Rigidbody2D>().velocity = new Vector2(speed,0);
    }
}
