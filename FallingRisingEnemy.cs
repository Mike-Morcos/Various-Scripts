// The Falling-Rising Enemy is a class in Unity that creates an enemy object which detects the player
// within a specified range and falls down to ground level to attack the player. The enemy then rises
// up to its initial position and repeats the process after a cooldown period. The class takes several
// parameters such as the detection range, falling and rising speeds, ground level, and cooldown time
// for the falling attack. The enemy object also has falling and rising sprites that are displayed
// during the respective phases of the attack. The Falling-Rising Enemy class provides an interactive
// game element that challenges the player's ability to dodge attacks from the enemy while staying
// within the detection range to attack back.
using UnityEngine;

public class FallingRisingEnemy : MonoBehaviour
{
    public float detectionRange = 5f;
    public float fallSpeed = 10f;
    public float riseSpeed = 5f;
    public float groundLevel = 0f;
    public float fallCooldown = 2f;
    [SerializeField] Sprite fallingSprite;
    [SerializeField] Sprite risingSprite;

    private Transform playerTransform;
    private bool isFalling = false;
    private bool isRising = false;
    private float initialY;
    private float fallTimer = 0f;
    private SpriteRenderer spriteRenderer;

    private void Start()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        initialY = transform.position.y;
        spriteRenderer = GetComponent<SpriteRenderer>();
        // Idle sprite also
        spriteRenderer.sprite = risingSprite;
    }

    private void Update()
    {
        // Check if the player is within range
        float distanceToPlayer = Vector2.Distance(transform.position, playerTransform.position);
        if (distanceToPlayer < detectionRange && !isFalling && !isRising && fallTimer <= 0f)
        {
            // Start falling
            isFalling = true;
            fallTimer = fallCooldown;
            spriteRenderer.sprite = fallingSprite;
        }

        // Fall down
        if (isFalling)
        {
            transform.position -= new Vector3(0f, fallSpeed * Time.deltaTime, 0f);
            if (transform.position.y <= groundLevel)
            {
                // Hit the ground
                transform.position = new Vector3(transform.position.x, groundLevel, transform.position.z);
                isFalling = false;
                isRising = true;
                spriteRenderer.sprite = risingSprite;
            }
        }

        // Rise up
        if (isRising)
        {
            transform.position += new Vector3(0f, riseSpeed * Time.deltaTime, 0f);
            if (transform.position.y >= initialY)
            {
                // Reset position
                transform.position = new Vector3(transform.position.x, initialY, transform.position.z);
                isRising = false;
                spriteRenderer.sprite = risingSprite; 
            }
        }

        // Update timer
        if (fallTimer > 0f)
        {
            fallTimer -= Time.deltaTime;
        }
    }
}
