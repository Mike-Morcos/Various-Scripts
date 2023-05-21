//---------------------------------------------------------------------------------------------------------------------
// The PingPongMotion class is responsible for moving a GameObject back and
// forth from an original starting point.using UnityEngine;
//---------------------------------------------------------------------------------------------------------------------

public class PingPongMotion : MonoBehaviour
{

    Vector3 _originalPosition = Vector3.zero;

    [SerializeField] Vector3 _moveAxis = Vector3.zero;
    [SerializeField] float _distance = 3f;



    private void Awake()
    {
        _originalPosition = transform.position;
    }

    // The Update function relies on the Mathf.PingPong function to transition a
    // value smoothly between a minimum and maximum.This function fluctuates
    // a value between minimum and maximum repeatedly and continuously over
    // time, allowing you move objects linearly.For more information, see the Unity
    // online documentation at http://docs.unity3d.com/ScriptReference/
    // Mathf.PingPong.html.
    private void Update()
    {
        _transform.position = _originalPosition + _moveAxis * Mathf.PingPong(Time.time, _distance);
    }
}