using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PingPong_Motion : MonoBehaviour
{
    
    // The PingPongMotion class is responsible for moving a GameObject back and
    //forth from an original starting point.
  

    //------------------------------------------------------------------------------------------
    //This null doesn't point to a location in memory.
    private Transform ThisTransform = null;
    // Original position
    private Vector3 OrigPos = Vector3.zero;
    // Axis to move on
    public Vector3 MoveAxis = Vector2.zero;
    // Speed at which we want to move back and fourth
    public float Distance = 3f;
    //------------------------------------------------------------------------------------------
    // The Awake function uses the OrigPos variable to record the starting position
    // of the GameObject.
    void Awake()
    {
        //Get transform component
        ThisTransform = GetComponent<Transform>();
        //Copy original position
        OrigPos = ThisTransform.position;
    }
    //------------------------------------------------------------------------------------------
    // The Update function relies on the Mathf.PingPong function to transition a
    // value smoothly between a minimum and maximum.This function fluctuates
    // a value between minimum and maximum repeatedly and continuously over
    // time, allowing you move objects linearly.For more information, see the Unity
    // online documentation at http://docs.unity3d.com/ScriptReference/
    // Mathf.PingPong.html.
    void Update()
    {
        // Update platform position with ping pong
        ThisTransform.position = OrigPos + MoveAxis * Mathf.PingPong(Time.
        time, Distance);
    }
    //------------------------------------------------------------------------------------------
}


