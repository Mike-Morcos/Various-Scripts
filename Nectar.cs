//using System.Collections;
//using System.Collections.Generic;
using UnityEngine;


public class Nectar : MonoBehaviour
{
    public static int nectarCount = 0;
    public static float NectarBarFill = 0f;
   
    //-------------------------
    // Use this for initialization
    void Awake()
    {
        //Object created, increment nectar count
        //++Nectar.nectarCount;
    }
    //--------------------------------------------------------
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //If player collected nectar, then destroy object
        if (collision.CompareTag("Player"))
            Destroy(gameObject);
    }
    //--------------------------------------------------------
    //Called when object is destroyed
    void OnDestroy()
    {
        NectarBarFill += .1f;
        //Decrement nectar count
        ++Nectar.nectarCount;
        //Check remaining nectar
        if (Nectar.nectarCount <= 0)
        {
            // We have won
        }
    }
    //--------------------------------------------------------
}
