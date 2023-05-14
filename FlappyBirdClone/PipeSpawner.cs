using UnityEngine;

public class PipeSpawner : MonoBehaviour
{
    [SerializeField] GameObject pipe;
    [SerializeField] float spawnInterval = 2f;
    [SerializeField] float minHeight = 4f;
    [SerializeField] float maxHeight = 4f;

    private void Start()
    {
        InvokeRepeating("SpawnPipe", 0f, spawnInterval);
    }

    private void SpawnPipe()
    {
        float randomHeight = Random.Range(minHeight, maxHeight);
        float pipeHeight = randomHeight;

        Vector3 pipePosition = new Vector3(transform.position.x, pipeHeight, 0f);
        GameObject spawnedPipe = Instantiate(pipe, pipePosition, Quaternion.identity);

        MovePipe(spawnedPipe);

        Destroy(spawnedPipe, 10f);
    }

    private void MovePipe(GameObject pipeObject)
    {
        Rigidbody2D pipeRigidbody = pipeObject.GetComponent<Rigidbody2D>();
        pipeRigidbody.velocity = new Vector2(-2f, 0f); // Adjust the velocity as per your requirements
    }
}
