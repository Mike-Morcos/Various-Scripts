// This script creates a parallax scrolling effect in a 2D game in Unity.
// The script captures the main camera's transform component and stores it in the 'cameraTransform' variable.
// It uses the camera's position to determine the amount of movement in the frame, and applies a parallax effect
// to the background by modifying its position based on the camera's movement.

using UnityEngine;

public class ParallaxingBackground : MonoBehaviour
{
    [SerializeField] private Vector2 _parallaxEffectMultiplier;
    private Transform _cameraTransform;
    private Vector3 _lastCameraPosition;
    private void Start()
    {
        // Automatically capture the main camera.
        _cameraTransform = Camera.main.transform;

        // Set _lastCameraPosition to its current position.
        _lastCameraPosition = _cameraTransform.position;
    }

    private void LateUpdate()
    {
        // Change in camera movement = camera's position - its last position.
        Vector3 deltaMovement = _cameraTransform.position - _lastCameraPosition;

        // Modify background position by the change in movement
        transform.position += new Vector3(deltaMovement.x * _parallaxEffectMultiplier.x, deltaMovement.y * _parallaxEffectMultiplier.y, 0);

        // Reset _lastCameraPosition to its current position.
        _lastCameraPosition = _cameraTransform.position;
    }
}