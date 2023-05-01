using UnityEngine;

public class RandomizedObjectSpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] spawnObjects;
    [SerializeField] private float rangeX = 1.0f;
    [SerializeField] private float rangeY = 1.0f;
    [SerializeField] private float minSpawnTime = 1.0f;
    [SerializeField] private float maxSpawnTime = 10.0f;

    private float _nextSpawnTime;

    private void Start()
    {
        _nextSpawnTime = Random.Range(minSpawnTime, maxSpawnTime);
        InvokeRepeating(nameof(SpawnObject), 0f, _nextSpawnTime);
    }

    private void SpawnObject()
    {
        int spawnObjectIndex = Random.Range(0, spawnObjects.Length);
        Vector3 spawnPosition = transform.position + new Vector3(Random.Range(-rangeX, rangeX), Random.Range(-rangeY, rangeY), 0f);
        Instantiate(spawnObjects[spawnObjectIndex], spawnPosition, spawnObjects[spawnObjectIndex].transform.rotation);
        _nextSpawnTime = Random.Range(minSpawnTime, maxSpawnTime);
    }
}
