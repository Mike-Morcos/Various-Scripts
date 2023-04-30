//-------------------------------------------
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//-------------------------------------------
public class Shooting : MonoBehaviour
{
	// Prefab instantiated as our bullet.
	public Rigidbody bullet;
	public float velocity =10.0f;
	//-------------------------------------------
	void FixedUpdate()
    {
        if(Input.GetButtonDown("Fire1"))
		{
			Rigidbody newBullet = Instantiate(bullet, transform.position, transform.rotation)as Rigidbody;
			// Adds a force to the bullet RigidBody ignoring mass to reach max velocity.
			newBullet.AddForce(transform.forward * velocity, ForceMode.VelocityChange);
		}
    }
}
