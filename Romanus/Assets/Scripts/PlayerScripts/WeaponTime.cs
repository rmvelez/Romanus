using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponTime : MonoBehaviour {

	float spawnTime = .2f; // the time the spear will last for

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		spawnTime -= Time.deltaTime; // decreases this variable over real time

		// checks to see if spawn time has run out
		if (spawnTime <= 0) 
		{
			Destroy (this.gameObject); // destroys the spear
		}
		
	}
}
