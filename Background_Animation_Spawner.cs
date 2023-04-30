using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background_Animation_Spawner : MonoBehaviour
{
    public GameObject gameObj;
    public float minPosition  = -3.5f, maxPosition =  139f;
    private float timer = .6f;

    void Start()
    {
      
    }

    // Update is called once per frame
    void FixedUpdate()
    {     
       
        timer -= Time.fixedDeltaTime;
        if (timer < 0)
        {
            // stores the gameobjects position within a random on the x, and its original position on the Y
            Vector2 gameObjectPosition = new Vector2(Random.Range(minPosition, maxPosition), transform.position.y);
            // Instanitaites the object in the empty game objects rotation and position.
            Instantiate(gameObj, gameObjectPosition, transform.rotation);
            timer = .6f;           
        }
    
    }
  
}

