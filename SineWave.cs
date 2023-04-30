using UnityEngine;

public class SineWave : MonoBehaviour
{
    #region Variables

    public float MoveSpeed = 0.3f;
    public float Frequency = 3.0f;  // Speed of sine movement
    public float Magnitude = 0.2f;   // Size of sine movement

    private Vector3 axis;
    private Vector3 pos;

    #endregion

    void Start()
    {
        
        pos = transform.position;
        //DestroyObject(gameObject, 1.0f);
        axis = new Vector2 (0,2) ;  // May or may not be the axis you want

    }

    void Update()
    {
        pos += -transform.right * Time.deltaTime * MoveSpeed;
        pos += transform.up * Time.deltaTime * MoveSpeed;

        transform.position = pos + axis * Mathf.Sin(Time.time * Frequency) * Magnitude;
    }
}
