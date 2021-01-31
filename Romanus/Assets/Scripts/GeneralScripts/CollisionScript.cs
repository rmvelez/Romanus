using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionScript : MonoBehaviour
{
	public GameObject vicInFront;
	public GameObject vicInBack;
	public GameObject cop;

	void OnCollisionEnter2D (Collision2D other) 
	{
		if (other.gameObject.tag == "Portal") 
		{
			Destroy(this.gameObject);
			Destroy(other.gameObject);
		}

		if (other.gameObject.tag == "bullet") 
		{
			Destroy(other.gameObject);
			vicInFront.gameObject.SetActive(false);
			vicInBack.gameObject.SetActive(true);
			//cop.gameObject.SetActive(false);
		}

		if (other.gameObject.tag == "bullet2") 
		{
			Destroy(other.gameObject);
			cop.gameObject.SetActive(false);
		}

	}
}
