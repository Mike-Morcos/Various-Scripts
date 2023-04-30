using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gravity_Controller : MonoBehaviour
{
    // Start is called before the first frame update
    Rigidbody2D rb;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Draggable.isDragged)
        {
            rb.gravityScale = 0f;
        }
        else
            rb.gravityScale = 1f;
    }
}
