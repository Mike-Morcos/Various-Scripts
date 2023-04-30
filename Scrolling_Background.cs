
using UnityEngine;

public class Scrolling_Background : MonoBehaviour
{
   

    // Update is called once per frame
    void Update()
    {
        //***********************************************************************
        transform.position += new Vector3(0f, Ui_Manager.trackSpeed * Time.deltaTime, 0f);
        //***********************************************************************
        if (transform.position.y > 16f)
        {
            transform.position = new Vector3(transform.position.x, -16f);
        }
    }
}
