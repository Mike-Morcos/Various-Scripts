using UnityEngine;

public class Laser_movement : MonoBehaviour {

	float speed = 200f;
	public Rigidbody2D rb;
	public float damage = .25f;
	public GameObject impactEffect;
	
	void Start()
	{   // Laser velocity based on fire points position
		rb.velocity = transform.right * speed * Time.deltaTime;
	}

	private void OnTriggerEnter2D(Collider2D hitInfo)
	{   
		Health player = hitInfo.GetComponent<Health>();
		if (player != null)
		{
		   player.TakeDamage(damage);
		}

		Instantiate(impactEffect, transform.position, transform.rotation);

		Destroy(gameObject);
	}

}
