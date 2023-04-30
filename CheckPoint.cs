using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    public SpriteRenderer SR;
    public Sprite checkPointOn, checkPointOff;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    void OnTriggerEnter2D(Collider2D collision)
    {
        // Turning on checkpoint by swapping sprites.
        if(collision.CompareTag("Player"))
        {
            // Deactivates the other checkpoints through the checkpoints controller script.
            CheckPointController.instance.DeactivateCheckpoints();
            SR.sprite = checkPointOn;
            CheckPointController.instance.SetSpawnPoint(transform.position);
        }
    }
    public void ResetCheckPoint()
    {
        
        SR.sprite = checkPointOff;
    }
}
