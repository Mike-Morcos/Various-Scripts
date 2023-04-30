using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy_Object : MonoBehaviour
{
 

	private void OnTriggerEnter2D(Collider2D collision)
	{
		// If the attached gameObject collides with the hitbox of the caterpillar
		// destroy the game object attached to this script
		if (collision.gameObject.tag == "Caterpillar_hitbox")
		{

			Destroy(gameObject,1f);
		}
	}
}
