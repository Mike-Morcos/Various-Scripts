using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DotController : MonoBehaviour
{
    // X and Y positions of the first touch.
    private Vector2 firstTouchPos;
    private Vector2 finalTouchPos;
    public float swipeAngle = 0;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnMouseDown()
    {
        // Getting the first touch position and converting from
        // from screenspace coordinates too worldspace coordinates.
        firstTouchPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }
    // Checks to see if your mouse is up globally
    private void OnMouseUp()
    {
        finalTouchPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }
}
