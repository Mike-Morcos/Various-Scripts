using UnityEngine;
using TMPro;

public class BirdController : MonoBehaviour
{
    public float jumpForce;
    public TextMeshProUGUI scoreText, finalScore;

    [SerializeField] private float minRotation = 30f;
    [SerializeField] private float maxRotation = -90f;
    [SerializeField] private float rotationSensitivity = 10f;

    private Rigidbody2D rb;
    private bool isJumping;
    private int score;
    [SerializeField] private GameObject restartMenu;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        score = 0;
        UpdateScoreText();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            isJumping = true;
        }

        // Smoothly rotate the bird based on velocity
        float targetRotation = Mathf.Lerp(minRotation, maxRotation, rb.velocity.y / rotationSensitivity);
        transform.rotation = Quaternion.Euler(0f, 0f, targetRotation);
    }

    private void FixedUpdate()
    {
        if (isJumping)
        {
            Jump();
            isJumping = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Pipe"))
        {
            score++;
            UpdateScoreText();
        }

        if (collision.CompareTag("Obstacle"))
        {
            rb.velocity = Vector2.zero;
            restartMenu.SetActive(true);
            finalScore.text = score.ToString();
        }
    }

    private void UpdateScoreText()
    {
        scoreText.text = score.ToString();
    }

    private void Jump()
    {
        rb.velocity = new Vector2(0f, jumpForce);
    }
}
