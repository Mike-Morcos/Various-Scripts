
using UnityEngine;

public class Scrolling_Track : MonoBehaviour
{
    [SerializeField] float speed;
    Vector2 offset;

   

    void Update()
    {
        offset = new Vector2(0, Time.time * speed);
        // Gets the renderer then accesses the material, the main texture offset, and stores it in out offset variable.
        GetComponent<Renderer>().material.mainTextureOffset = offset;

       

    }
}
