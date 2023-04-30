using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class Health : MonoBehaviour {

	public float health = 1f;
	public GameObject deathEffect;

	// Reference to health bar script
	[SerializeField] private HealthBar healthBar;
	
	public void TakeDamage (float damage)
	{
		health -= damage;
		// Health bar script
		healthBar.SetSize(health);
		if (health > .63f)
		{
			healthBar.SetColor(Color.green);
		}
		if (health < .63f)
		{
			healthBar.SetColor(Color.yellow);
		}
		if (health < .33f)
		{
			healthBar.SetColor(Color.red);
		}
		
		if (health <= 0)
		{
			//Instantiate(deathEffect, transform.position, Quaternion.identity);
			Destroy(gameObject);
		}

	}
}
