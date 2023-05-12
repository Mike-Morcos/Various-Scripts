using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generate_Circle : MonoBehaviour
{
    [SerializeField] GameObject circle;
    private float spawnTimer;
    private Transform newPosition;
    private Vector3 addToPosition;

    
    public static int circleCounter;
    void Start()
    {
        
        addToPosition = new Vector3(0f, 0f, 0f);
        //spawnTimer = .2f;
        circleCounter = 0;
       
    }

    // Update is called once per frame
    void Update()
    {
        //spawnTimer -= Time.deltaTime;
        
        if(/*spawnTimer < 0 &&*/  circleCounter < 50)
        {
            addToPosition = new Vector3(Random.Range(-30f, 30f), Random.Range(-30f, 30f), 0f);
            //newPosition.position = addToPosition;
            if(addToPosition.x < -5f || addToPosition.x > 5f || addToPosition.y < -5f || addToPosition.y > 5f)
            {
                Instantiate(circle, transform.position + addToPosition, transform.transform.rotation);
               // spawnTimer = .2f;
                circleCounter++;
            }
            
        }
       
    }
}
