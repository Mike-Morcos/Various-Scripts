using UnityEngine;

public class Smoke : MonoBehaviour
{

	#region Varaibles
	float speed = 30f;
	public Rigidbody2D rb;
	public GameObject smoke;
	public Transform spawn;
	float delayTimer = .5f;
	float timer;
	#endregion

	void Start()
	{
		rb.velocity = transform.up * speed * Time.deltaTime;
		timer = delayTimer;
	}
	private void Update()
	{
		timer -= Time.deltaTime;
		if (timer <= 0 )
		{
			Instantiate(smoke, spawn.position, transform.rotation);

			timer = delayTimer;
		}
		
	}

}
