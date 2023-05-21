//---------------------------------------------------------------------------------------------------------------------
// The Falling-Rising Enemy is a class in Unity that creates an enemy object which detects the player
// within a specified range and falls down to ground level to attack the player. The enemy then rises
// up to its initial position and repeats the process after a cooldown period. The class takes several
// parameters such as the detection range, falling and rising speeds, ground level, and cooldown time
// for the falling attack. The enemy object also has falling and rising sprites that are displayed
// during the respective phases of the attack. The Falling-Rising Enemy class provides an interactive
// game element that challenges the player's ability to dodge attacks from the enemy while staying
// within the detection range to attack back.
//---------------------------------------------------------------------------------------------------------------------

using UnityEngine;

public class FallingRisingEnemy : MonoBehaviour
{
    [SerializeField] float _detectionRange = 5f;
    [SerializeField] float _fallSpeed = 10f;
    [SerializeField] float _riseSpeed = 5f;
    [SerializeField] float _groundLevel = 0f;
    [SerializeField] float _fallCooldown = 2f;

    Transform _playerTransform;
    bool _isFalling = false;
    bool _isRising = false;
    float _initialY;
    float _fallTimer = 0f;
    SpriteRenderer _spriteRenderer;

    private void Start()
    {
        // Find and store a reference to the player's transform
        _playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        // Store the initial Y position of the enemy
        _initialY = transform.position.y;
        // Get the SpriteRenderer component attached to this object
        _spriteRenderer = GetComponent<SpriteRenderer>();
        // Set the sprite to the rising sprite initially
        _spriteRenderer.sprite = risingSprite;
    }

    private void Update()
    {
        // Check if the player is within range
        float distanceToPlayer = Vector2.Distance(transform.position, _playerTransform.position);
        if (distanceToPlayer < _detectionRange && !_isFalling && !_isRising && _fallTimer <= 0f)
        {
            // Start falling
            _isFalling = true;
            _fallTimer = _fallCooldown;
            // Change the sprite to the falling sprite
            _spriteRenderer.sprite = fallingSprite;
        }

        // Fall down
        if (_isFalling)
        {
            // Move the enemy downwards based on the fall speed
            transform.position -= new Vector3(0f, _fallSpeed * Time.deltaTime, 0f);
            if (transform.position.y <= _groundLevel)
            {
                // Hit the ground
                // Set the position to the ground level to prevent sinking below it
                transform.position = new Vector3(transform.position.x, _groundLevel, transform.position.z);
                // Stop falling and start rising
                _isFalling = false;
                _isRising = true;
                // Change the sprite to the rising sprite
                _spriteRenderer.sprite = risingSprite;
            }
        }

        // Rise up
        if (_isRising)
        {
            // Move the enemy upwards based on the rise speed
            transform.position += new Vector3(0f, _riseSpeed * Time.deltaTime, 0f);
            if (transform.position.y >= _initialY)
            {
                // Reset position to the initial Y position
                transform.position = new Vector3(transform.position.x, _initialY, transform.position.z);
                // Stop rising
                _isRising = false;
            }
        }

        // Update the fall timer
        if (_fallTimer > 0f)
        {
            _fallTimer -= Time.deltaTime;
        }
    }
}

