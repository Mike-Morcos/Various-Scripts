using UnityEngine;

public class InfiniteScrolling : MonoBehaviour
{
    public float scrollSpeed = 2f; // Adjust the speed as per your requirements
    private float tileSize;
    private Vector3 startPosition;

    private void Start()
    {
        // Get the size of the sprite
        tileSize = GetComponent<SpriteRenderer>().bounds.size.x;

        // Store the initial position
        startPosition = transform.position;

        Debug.Log("new");
    }

    private void Update()
    {
        // Calculate the distance scrolled
        float distanceScrolled = Time.time * scrollSpeed;

        // Calculate the remainder distance after reaching the tileSize
        float remainderDistance = distanceScrolled % tileSize;

        // Calculate the new position
        Vector3 newPosition = startPosition + Vector3.left * remainderDistance;

        // Wrap the position if it goes beyond the left screen edge
        if (newPosition.x < startPosition.x - tileSize)
        {
            newPosition += Vector3.right * tileSize;
        }

        // Move the platform sprite
        transform.position = newPosition;
    }
}
