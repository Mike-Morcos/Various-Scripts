using System.Collections;
//using System.Collections.Generic;
using UnityEngine;

public class Ground_Move : MonoBehaviour
{
	public float speed = 10.0f;
	
    void Update()
    {
		transform.position += transform.forward * speed * Time.deltaTime;
    }
}
