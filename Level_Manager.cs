using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level_Manager : MonoBehaviour
{
    public static Level_Manager instance;
    
    public float waitToRespawn;
    private void Awake()
    {
        instance = this;  
    }
   
    // Update is called once per frame
    void Update()
    {
        
    }

    public void RespawnPlayer()
    {
        StartCoroutine(RespawnCo());
    }
    // Enumerators happen outside the normal Unity updates
    private IEnumerator RespawnCo()
    {
        // Sets Game Object to false
        Player_Movement_2.PlayerInstance.gameObject.SetActive(false);
        // Waits a few seconds
        yield return new WaitForSeconds(waitToRespawn);
        // Sets Game Object to true
        Player_Movement_2.PlayerInstance.gameObject.SetActive(true);
        Player_Movement_2.PlayerInstance.transform.position = CheckPointController.instance.spawnPoint;
   

    }
  
}
