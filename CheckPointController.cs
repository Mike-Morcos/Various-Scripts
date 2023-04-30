using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPointController : MonoBehaviour
{
    public static CheckPointController instance;
    // Start is called before the first frame update
    private CheckPoint[] checkpoints;
    public Vector3 spawnPoint;
    public void Awake()
    {
        instance = this;
    }
    void Start()
    {
        // Finds all the objects in the scene that has a CheckPoint script
        checkpoints = FindObjectsOfType<CheckPoint>();
        spawnPoint = Player_Movement_2.PlayerInstance.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void DeactivateCheckpoints()
    {
        // checking all the checkpoint elements and deactivates the previous checkpoints
        for(int i = 0; i < checkpoints.Length; i++)
        {
            checkpoints[i].ResetCheckPoint();
        }
    }

    public void SetSpawnPoint(Vector3 newSpawnPoint)
    {
        spawnPoint = newSpawnPoint;
    }
}
