// This script controls the behavior of a bird character in a game that is based off flappy bird

using UnityEngine;
using TMPro;

public class BirdController : MonoBehaviour
{
    [SerializeField] private float jumpForce; // The vertical force applied when the bird jumps
    [SerializeField] private float minRotation = 30f; // The minimum rotation angle of the bird
    [SerializeField] private float maxRotation = -90f; // The maximum rotation angle of the bird
    [SerializeField] private float rotationSensitivity = 10f; // The sensitivity of bird rotation to velocity

    public TextMeshProUGUI scoreText; // The TextMeshProUGUI element to display the current score
    public TextMeshProUGUI finalScore; // The TextMeshProUGUI element to display the final score

    [SerializeField] private GameObject restartMenu; // The game menu that appears when the bird collides with an obstacle

    private Rigidbody2D rb; // Reference to the Rigidbody2D component of the bird
    private bool isJumping; // Flag indicating if the bird is currently jumping
    private int score; // The current score

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>(); // Get the Rigidbody2D component attached to the bird
        score = 0; // Initialize the score to 0
        UpdateScoreText(); // Update the score text display
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            isJumping = true; // Set the isJumping flag to true when the jump key is pressed
        }

        // Smoothly rotate the bird based on its velocity
        float targetRotation = Mathf.Lerp(minRotation, maxRotation, rb.velocity.y / rotationSensitivity);
        transform.rotation = Quaternion.Euler(0f, 0f, targetRotation);
    }

    private void FixedUpdate()
    {
        if (isJumping)
        {
            Jump(); // Make the bird jump when the isJumping flag is true
            isJumping = false; // Reset the isJumping flag
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Pipe"))
        {
            score++; // Increase the score when the bird collides with a pipe
            UpdateScoreText(); // Update the score text display
        }

        if (collision.CompareTag("Obstacle"))
        {
            rb.velocity = Vector2.zero; // Stop the bird's movement when it collides with an obstacle
            restartMenu.SetActive(true); // Show the restart menu
            finalScore.text = score.ToString(); // Display the final score in the restart menu
        }
    }

    private void UpdateScoreText()
    {
        scoreText.text = score.ToString(); // Update the score text display with the current score
    }

    private void Jump()
    {
        rb.velocity = new Vector2(0f, jumpForce); // Apply a vertical velocity to the bird to make it jump
    }
}
