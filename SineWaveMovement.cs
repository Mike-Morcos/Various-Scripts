//  This script creates a sine wave movement pattern for a game object in the Unity game engine.
//  The wave moves along a specific axis and has a certain speed, frequency,
//  and magnitude that can be adjusted.

using UnityEngine;

public class SineWaveMovement : MonoBehaviour
{
    [SerializeField] float moveSpeed = 0.3f;
    [SerializeField] float frequency = 3.0f;  // Speed of sine movement
    [SerializeField] float magnitude = 0.2f;  // Size of sine movement

    private Vector3 axis;
    private Vector3 pos;

    private void Start()
    {
        pos = transform.position;
        axis = new Vector2(0, 2);  // May or may not be the axis you want
    }

    private void Update()
    {
        pos += -transform.right * Time.deltaTime * moveSpeed;
        pos += transform.up * Time.deltaTime * moveSpeed;

        transform.position = pos + axis * Mathf.Sin(Time.time * frequency) * magnitude;
    }
}

