// This script controls the player character, which is a clownfish, in a game.
// The script sets up the initial state of the character, stores axial data and a maximum speed.
// It also provides functionality for the player to move and rotate the character.
// The script also has an enum to store the direction the player is facing and a method to flip the character's direction.
// The script also controls the dash and fart abilities of the character. The character can only use the fart ability when the fart bar is full.
// The script also disables the character when it dies or wins the game.

using UnityEngine;

public class ClownfishController : MonoBehaviour
{
    public enum FaceDirection { Left = -1, Right = 1 }; // Enum to store the direction the player is facing
    public FaceDirection Facing = FaceDirection.Right; // The direction we start off facing

    private float horizontalInput, verticalInput, maxSpeed = 400f; // Variables to store axial data and a max speed
    private bool isDashing;

    private Rigidbody2D _rigidbody;
    private Animator _animator;
    private SpriteRenderer _spriteRenderer;
    private CapsuleCollider2D _collider;

    public GameObject bloodFX, explodeFX, fartFX;
    public Transform fartSpawnPoint;

    public static float playerScale;
    public static float playerScore;
    public static bool isDead;
    public static bool hasWon;
    public static float fartBar;

    public AudioSource bite, explode, fart;

    private float _fartTimer;

    void Awake()
    {
        _animator = GetComponent<Animator>();
        _collider = GetComponent<CapsuleCollider2D>();
        _rigidbody = GetComponent<Rigidbody2D>();
        _spriteRenderer = GetComponent<SpriteRenderer>();

        isDead = false;
        hasWon = false;

        playerScore = 0.2f;
        playerScale = transform.localScale.x;

        _fartTimer = 1f;
        fartBar = 100f;
    }

    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
        if (Input.GetKey(KeyCode.Space))
        {
            isDashing = true;
        }
        else
        {
            isDashing = false;
        }

        _fartTimer -= Time.deltaTime;
        if (Input.GetKeyDown(KeyCode.Q) && fartBar > 95f)
        {
            fartFX.transform.localScale = transform.localScale;
            Instantiate(fartFX, fartSpawnPoint.transform.position, transform.rotation);
            fart.Play();
            fartBar = 0f;
        }
    }

    private void FixedUpdate()
    {
        // Disable the character when it dies or wins the game
        if ((isDead && playerScore <= 4f) || hasWon)
        {
            _animator.enabled = false;
            _spriteRenderer.enabled = false;
            horizontalInput = 0;
            verticalInput = 0;
            _collider.enabled = false;
            fartBar = 0f;
        }
        // Move and rotate the character
        else if (!isDead && playerScore <= 4f)
        {
            Vector2 moveDirection = new Vector2(horizontalInput, verticalInput);
            if (isDashing)
            {
                _rigidbody.AddForce(moveDirection.normalized * maxSpeed * 4 * Time.fixedDeltaTime);
            }
            else
            {
                _rigidbody.AddForce(moveDirection.normalized * maxSpeed * Time.fixedDeltaTime);
            }

            if (horizontalInput == 0 && verticalInput == 0)
            {
                _animator.SetBool("IsMoving", false);
            }
            else
            {
                _animator.SetBool("IsMoving", true);
            }
            if (horizontalInput > 0 && Facing == FaceDirection.Left)
            {
                Flip();
            }
            else if (horizontalInput < 0 && Facing == FaceDirection.Right)
            {
                Flip();
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Food"))
        {
            Destroy(other.gameObject);
            playerScore += 0.1f;
            bite.Play();
        }
        else if (other.gameObject.CompareTag("Mine"))
        {
            Instantiate(explodeFX, other.gameObject.transform.position, Quaternion.identity);
            explode.Play();
            Destroy(other.gameObject);
            playerScore -= 0.5f;
        }

        if (playerScore >= 4f)
        {
            hasWon = true;
        }

        if (playerScore <= 0f)
        {
            isDead = true;
        }
    }

    private void Flip()
    {
        Facing = (FaceDirection)(-(int)Facing);
        Vector3 newScale = transform.localScale;
        newScale.x *= -1;
        transform.localScale = newScale;
    }
}