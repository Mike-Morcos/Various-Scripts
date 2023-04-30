
using UnityEngine;

public class Object_Mover : MonoBehaviour
{

    void Update()
    {
        //***********************************************************************
        transform.Translate (new Vector2(0, 1f * Time.deltaTime * Ui_Manager.trackSpeed));
        //***********************************************************************
    }
}
