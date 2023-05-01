//  This script creates a sine wave movement pattern for a game object in the Unity game engine.
//  The wave moves along a specific axis and has a certain speed, frequency,
//  and magnitude that can be adjusted.

using UnityEngine;

public class SineWaveMovement : MonoBehaviour
{
    public float moveSpeed = 0.3f;
    public float frequency = 3.0f;  // Speed of sine movement
    public float magnitude = 0.2f;  // Size of sine movement

    private Vector3 _axis;
    private Vector3 _pos;

    private void Start()
    {
        _pos = transform.position;
        _axis = new Vector2(0, 2);  // May or may not be the axis you want
    }

    private void Update()
    {
        _pos += -transform.right * Time.deltaTime * moveSpeed;
        _pos += transform.up * Time.deltaTime * moveSpeed;

        transform.position = _pos + _axis * Mathf.Sin(Time.time * frequency) * magnitude;
    }
}

