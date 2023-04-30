using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallaxing_Background : MonoBehaviour
{
    // Figuring out how much the camera has moved
    [SerializeField] private Vector2 parallaxEffectMultiplier;
    private Transform cameraTransform;
    private Vector3 lastCameraPosition;
    void Start()
    {
        // Automatically capture the main camera.
        cameraTransform = Camera.main.transform;

        // Set lastCameraPosition to its current position.
        lastCameraPosition = cameraTransform.position;
    }

    // Using late update
    void LateUpdate()
    {
      
        // Change in camera movement = cameras position - its last position.
        Vector3 deltaMovement = cameraTransform.position - lastCameraPosition;
        // Modify its position by the change in movement
        transform.position += new Vector3 (deltaMovement.x * parallaxEffectMultiplier.x, deltaMovement.y * parallaxEffectMultiplier.y, 0);
        // reset lastCameraPosition to its current position.
        lastCameraPosition = cameraTransform.position;
    }
}
