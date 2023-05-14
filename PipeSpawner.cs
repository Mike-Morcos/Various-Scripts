// This script spawns pipes at regular intervals and moves them horizontally

using UnityEngine;

public class PipeSpawner : MonoBehaviour
{
    [SerializeField] GameObject pipe; // Prefab of the pipe object to be spawned
    [SerializeField] float spawnInterval = 2f; // Interval between spawning pipes
    [SerializeField] float minHeight = 4f; // Minimum height for the spawned pipes
    [SerializeField] float maxHeight = 4f; // Maximum height for the spawned pipes

    private void Start()
    {
        // Invoke the SpawnPipe method repeatedly with the specified interval
        InvokeRepeating("SpawnPipe", 0f, spawnInterval);
    }

    private void SpawnPipe()
    {
        // Generate a random height for the pipe within the specified range
        float randomHeight = Random.Range(minHeight, maxHeight);
        float pipeHeight = randomHeight;

        // Set the position of the pipe based on the spawner's position and the generated height
        Vector3 pipePosition = new Vector3(transform.position.x, pipeHeight, 0f);
        // Instantiate a new pipe at the calculated position
        GameObject spawnedPipe = Instantiate(pipe, pipePosition, Quaternion.identity);

        // Move the spawned pipe horizontally
        MovePipe(spawnedPipe);

        // Destroy the spawned pipe after 10 seconds
        Destroy(spawnedPipe, 10f);
    }

    private void MovePipe(GameObject pipeObject)
    {
        // Get the Rigidbody2D component of the pipe
        Rigidbody2D pipeRigidbody = pipeObject.GetComponent<Rigidbody2D>();
        // Set the velocity of the pipe to move it horizontally
        pipeRigidbody.velocity = new Vector2(-2f, 0f);
    }
}
