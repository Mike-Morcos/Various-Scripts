using UnityEngine;

public class PingPongMotion : MonoBehaviour
{
    // The PingPongMotion class is responsible for moving a GameObject back and
    // forth from an original starting point.// Original position
    private Vector3 _origPosition = Vector3.zero;
    // Axis to move on
    public Vector3 moveAxis = Vector3.zero;
    // Speed at which we want to move back and forth
    public float distance = 3f;

    private Transform _transform;

    private void Awake()
    {
        // Get transform component
        _transform = transform;
        // Copy original position
        _origPosition = _transform.position;
    }

    // The Update function relies on the Mathf.PingPong function to transition a
    // value smoothly between a minimum and maximum.This function fluctuates
    // a value between minimum and maximum repeatedly and continuously over
    // time, allowing you move objects linearly.For more information, see the Unity
    // online documentation at http://docs.unity3d.com/ScriptReference/
    // Mathf.PingPong.html.
    private void Update()
    {
        // Update platform position with ping pong
        _transform.position = _origPosition + moveAxis * Mathf.PingPong(Time.time, distance);
    }
}