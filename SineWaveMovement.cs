//---------------------------------------------------------------------------------------------------------------------
//  This script creates a sine wave movement pattern for a game object in the Unity game engine.
//  The wave moves along a specific axis and has a certain speed, frequency,
//  and magnitude that can be adjusted.
//---------------------------------------------------------------------------------------------------------------------

using UnityEngine;

public class SineWaveMovement : MonoBehaviour
{
    [SerializeField] float _moveSpeed = 0.3f;
    [SerializeField] float _frequency = 3.0f;  // Speed of sine movement
    [SerializeField] float _magnitude = 0.2f;  // Size of sine movement

    Vector3 _axis;
    Vector3 _pos;

    private void Start()
    {
        _pos = transform.position;
        _axis = new Vector2(0, 2);
    }

    private void Update()
    {
        // Move the object horizontally and vertically based on the moveSpeed
        _pos += -transform.right * Time.deltaTime * _moveSpeed;
        _pos += transform.up * Time.deltaTime * _moveSpeed;

        // Calculate the position offset using a sine wave pattern
        float offset = Mathf.Sin(Time.time * _frequency) * _magnitude;
        Vector3 positionOffset = _axis * offset;

        // Update the position of the object with the calculated offset
        transform.position = _pos + positionOffset;
    }
}

