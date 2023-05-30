//------------------------------------------------------------------------------------------------------------
// This script controls the movement of the camera to follow a target object.
// It smoothly interpolates the camera's position towards the target's position,
// keeping the camera within specified bounds.
//------------------------------------------------------------------------------------------------------------

using UnityEngine;

[System.Serializable]
public class CameraMovement : MonoBehaviour
{
    [SerializeField] private Transform _target;
    [SerializeField] private float _smoothing;
    [SerializeField] private Vector2 _maxPosition;
    [SerializeField] private Vector2 _minPosition;

    private void FixedUpdate()
    {
        if (transform.position != _target.position)
        {
            Vector3 targetPosition = new Vector3(_target.position.x, _target.position.y, transform.position.z);

            targetPosition.x = Mathf.Clamp(targetPosition.x, _minPosition.x, _maxPosition.x);

            transform.position = Vector3.Lerp(transform.position, targetPosition, _smoothing * Time.fixedDeltaTime);
        }
    }

