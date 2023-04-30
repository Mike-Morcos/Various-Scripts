using UnityEngine;

public class Damage_Enemy : MonoBehaviour
{

	private void OnTriggerEnter2D(Collider2D collision)
	{
		// Make sure all enemys have this tag
		if(collision.gameObject.tag == "Enemy")
		{
			Destroy(collision.gameObject);
		}
	}
}
