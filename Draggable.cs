using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Draggable : MonoBehaviour
{
    //public delegate void DragEndedDelegate(Draggable draggableObjects);
    //public DragEndedDelegate dragEndedCallback;
    public static bool isDragged = false;
    private Vector3 mouseDragStartPosition;
    private Vector3 spriteDragStartPosition;
    //
    //private Rigidbody2D rb;

    
   
    private void OnMouseDown()
    {
        //rb.GetComponent<Rigidbody2D>();
        isDragged = true;
        // getting the mouse position
        mouseDragStartPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        // getting the attached objects transform
        spriteDragStartPosition = transform.localPosition;
    }
    private void OnMouseDrag()
    {
        
        // if is dragged
        if(isDragged)
        {
            //Physics2D.gravity = new Vector2(0, 0);
            transform.localPosition = spriteDragStartPosition + (Camera.main.ScreenToWorldPoint(Input.mousePosition) - mouseDragStartPosition);
            
        }

    }
    private void OnMouseUp()
    {
        isDragged = false;
        //dragEndedCallback(this);
        //Physics2D.gravity = new Vector2(0, -9.8f);
    }
}
