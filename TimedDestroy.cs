//------------------------------
using UnityEngine;
using System.Collections;
//------------------------------
public class TimedDestroy : MonoBehaviour
{
	//public GameObject[] obj;
	public float DestroyTime = 2f;
	//------------------------------
	// Use this for initialization
	void Start()
	{
		Invoke("Die", DestroyTime);
	}
	void Die()
	{
		Destroy(gameObject);
		/*
		   Destroy(obj[0]);
		   Destroy(obj[1]);
		*/
	}
	//------------------------------
}
//------------------------------

/*
	• The TimeDestroy class simply destroys the object to which it's attached after
a specified interval (DestroyTime) has elapsed.

	• The Invoke function is called in the Start event. Invoke will execute a
function of the specified name once, and only once, after a specified interval
has elapsed. The interval is measured in seconds.

	• Like SendMessage, the Invoke function relies on Reflection. For this
reason, it should be used sparingly for best performance.

	• The Die function will be executed by Invoke after a specified interval to
destroy the gameobject (such as a particle system).
*/
