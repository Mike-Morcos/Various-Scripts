using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy_on_collision : MonoBehaviour
{
	public void OnCollisionEnter(Collision colliderObjekt)
	{
		if (colliderObjekt.gameObject.tag == "Ring1")
		{
			Destroy(colliderObjekt.gameObject);
		}
	}
}
