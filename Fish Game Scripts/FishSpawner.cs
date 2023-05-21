// This script handles spawning fish game objects in a Unity game. It does this by reducing the
// time between each spawn and randomly choosing a fish to spawn within a given range of y values.

using UnityEngine;

public class FishSpawner : MonoBehaviour
{
    private Vector2 _spawnPosition;

    private float _spawnMaxY = 7.5f;
    private float _spawnMinY = -3.5f;   
    private float _spawnTimer = 10f;
    private float _reduceSpawnTimeTimer = 8f;
    private float _reduceSpawnTime = 0f;
    private float _reduceSpawnTimeMax;

    [SerializeField] private GameObject[] fish;

    private void Awake()
    {
        _spawnPosition = transform.position;
        _reduceSpawnTimeMax = _spawnTimer - 1.2f;
    }

    private void Start()
    {
        InvokeRepeating(nameof(SpawnFish), _spawnTimer, _spawnTimer);
        InvokeRepeating(nameof(ReduceSpawnTime), _reduceSpawnTimeTimer, _reduceSpawnTimeTimer);
    }

    private void SpawnFish()
    {
        int spawnRandomFish = Random.Range(0, fish.Length);
        _spawnPosition.y = Random.Range(_spawnMaxY, _spawnMinY);
        Instantiate(fish[spawnRandomFish], _spawnPosition, Quaternion.identity);
        _spawnTimer -= _reduceSpawnTime;
    }

    private void ReduceSpawnTime()
    {
        if (_reduceSpawnTime < _reduceSpawnTimeMax)
        {
            _reduceSpawnTime += 0.2f;
        }
    }
}
