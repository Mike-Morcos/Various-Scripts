//The TimeDestroy class simply destroys the object to which it's attached after
//a specified interval (DestroyTime) has elapsed.

using UnityEngine;
//using System.Collections;

public class TimedDestroy : MonoBehaviour
{
	public float DestroyTime = 2f;
	
	void Start()
	{
		Invoke("Die", DestroyTime);
	}
	void Die()
	{
		Destroy(gameObject);		
	}	
}
