using UnityEngine;

public class PiranhaEnemy : MonoBehaviour
{
    #region Fields
    private float _attackRadius = 6f;
    private Transform _player;
    private Vector2 _movingVector;
    private float _attackTimer = 2f;
    private Rigidbody2D _rigidBody;
    private float _randomSpeed;

    private Animator _animator;

    private bool _playerIsSeen;

    private bool _isMoving;
    private bool _isAttacking;
    #endregion

    void Start()
    {
        // Get required components and initialize variables
        _animator = GetComponentInChildren<Animator>();
        _rigidBody = GetComponent<Rigidbody2D>();
        _movingVector = Vector2.right;
        _isMoving = true;
        _randomSpeed = Random.Range(100f, 150f);
        _player = GameObject.Find("Player").transform;
    }

    void FixedUpdate()
    {
        // If the player is near the Piranha within the attack radius, set _playerIsSeen to true
        if (Vector2.Distance(_player.position, transform.position) < _attackRadius)
        {
            _playerIsSeen = true;
        }

        // If the player is seen by the Piranha and the Piranha is not currently attacking, rotate towards the player and set _isMoving to false
        if (_playerIsSeen && !_isAttacking)
        {
            // Stop the Piranha's movement
            _isMoving = false;

            // Play the idle animation
            _animator.Play("piranhaIdle");

            // Get the vector in the player's direction
            Vector3 vectorToTarget = _player.position - transform.position;

            // Set the velocity to zero
            _rigidBody.velocity = Vector2.zero;

            // Rotate the Piranha's forward vector towards the player's position
            Quaternion lookRotation = Quaternion.LookRotation((vectorToTarget).normalized);
            transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.fixedDeltaTime * 3f);

            // Decrement the attack timer
            _attackTimer -= Time.fixedDeltaTime;

            if (_attackTimer < 0)
            {
                // Set the moving direction towards the player's position
                _movingVector = _player.position - transform.position;

                // Increase the Piranha's speed
                _randomSpeed *= 3f;

                // Reset the attack timer
                _attackTimer = 100;

                // Set the Piranha to move and attack
                _isMoving = true;
                _isAttacking = true;
            }
        }

        // If the Piranha is moving
        if (_isMoving)
        {
            // Set the velocity to the moving vector and play the swim animation
            _rigidBody.velocity = _movingVector.normalized * _randomSpeed * Time.fixedDeltaTime;
            _animator.Play("piranhaSwim");
        }
    }
}
