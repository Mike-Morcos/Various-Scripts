//---------------------------------------------------------------------------------------------------------------------
// This script creates an infinite scrolling effect for a platform or background sprite in Unity. It attaches to a game object
// and scrolls it horizontally. The scroll speed can be adjusted using the scrollSpeed variable. The script calculates
// the distance scrolled based on the elapsed time and scroll speed. It wraps the position of the sprite when it goes
// beyond the left screen edge, creating a seamless scrolling effect. The initial size of the sprite is obtained
// and stored in _tileSize, and the initial position is stored in _startPosition.
//---------------------------------------------------------------------------------------------------------------------


using UnityEngine;

public class InfiniteScrolling : MonoBehaviour
{
    [SerializeField] float _scrollSpeed = 2f; 
    float _tileSize;
    Vector3 _startPosition;

    private void Start()
    {
        // Get the size of the sprite
        _tileSize = GetComponent<SpriteRenderer>().bounds.size.x;

        // Store the initial position
        _startPosition = transform.position;

    }

    private void Update()
    {
        // Calculate the distance scrolled
        float distanceScrolled = Time.time * _scrollSpeed;

        // Calculate the remainder distance after reaching the tileSize
        float remainderDistance = distanceScrolled % _tileSize;

        // Calculate the new position
        Vector3 newPosition = _startPosition + Vector3.left * remainderDistance;

        // Wrap the position if it goes beyond the left screen edge
        if (newPosition.x < _startPosition.x - _tileSize)
        {
            newPosition += Vector3.right * _tileSize;
        }

        // Move the platform sprite
        transform.position = newPosition;
    }
}
