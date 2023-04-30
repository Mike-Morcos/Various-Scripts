using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Movement : MonoBehaviour
{
    //-----------------------------------------------------------------------
    // Target for camera to follow.
    public Transform target;
    // Variable to accelerate camera speed.
    public float smoothing;
    // Variable to describe the maximum and minimim position
    // for the camera so it doesn't go out of bounds.
    public Vector2 maxPosition, minPosition;
    //-----------------------------------------------------------------------

    //-----------------------------------------------------------------------
    // LateUpdate is called last to avoid the camera script
    // firing before the player to avoid jerky motion.
    void FixedUpdate()// Late Update
    {
        // If our transform position is not equal to our targets position
        // we are going to mov toward the tagets position.
        if (transform.position != target.position)
        {
            //-----------------------------------------------------------------------
            // Variable to restrict the camera movement on the z axis
            // and keep the target position on the x and y axis.
            Vector3 TargetPosition = new Vector3
                (target.position.x, target.position.y, transform.position.z);
            //-----------------------------------------------------------------------

            //-----------------------------------------------------------------------
            // Clamps the targets position by getting value between 
            //the minimum and maximum float values.
          
             TargetPosition.x = Mathf.Clamp
                (TargetPosition.x, minPosition.x, maxPosition.x);

            //TargetPosition.y = Mathf.Clamp
            //    (TargetPosition.y, minPosition.y, maxPosition.y);

            //-----------------------------------------------------------------------

            //-----------------------------------------------------------------------
            // will find the distance between the camera and the target
            // and return a percentage of that distance each frame.
            transform.position = Vector3.Lerp
                (transform.position, TargetPosition, smoothing * Time.fixedDeltaTime);
            //-----------------------------------------------------------------------
        }
    }
}
