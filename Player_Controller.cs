using UnityEngine;

public class Player_Controller : MonoBehaviour
{

	#region Variables

	public float speed = 100f;
	private float X, Y;

	public Rigidbody2D rb;

	private Animator anim;

	public bool playerMove;
	private static bool playerExists;

	public Vector2 lastMove;

	#endregion

	private void Start()
	{
		rb = gameObject.GetComponent<Rigidbody2D>();
		anim = gameObject.GetComponent<Animator>();

		if (!playerExists)
		{
			playerExists = true;
			DontDestroyOnLoad(transform.gameObject);
		}
		else
		{
			Destroy(gameObject);
		}
	}

	private void Update()
	{

		playerMove = false;

		// Moves right
		if (Input.GetKey("d"))
		{
			rb.velocity = new Vector2(speed * Time.deltaTime, 0);
			X = 1;

			playerMove = true;

			lastMove = new Vector2(1, 0);
		}
		// Move Left
		else if (Input.GetKey("a"))
		{
			rb.velocity = new Vector2(-speed * Time.deltaTime, 0);
			X = -1;

			playerMove = true;

			lastMove = new Vector2(-1, 0);
		}
		// Move Up
		else if (Input.GetKey("w"))
		{
			rb.velocity = new Vector2(0, speed * Time.deltaTime);
			Y = 1;

			playerMove = true;

			lastMove = new Vector2(0, 1);
		}
		// Move Down
		else if (Input.GetKey("s"))
		{
			rb.velocity = new Vector2(0, -speed * Time.deltaTime);
			Y = -1;

			playerMove = true;

			lastMove = new Vector2(0, -1);
		}
		else
		{
			rb.velocity = new Vector2(0, 0);
			X = 0;
			Y = 0;
		}

		anim.SetFloat("MoveX", X);
		anim.SetFloat("MoveY", Y);
		anim.SetBool("PlayerMoving", playerMove);
		anim.SetFloat("LastMoveX", lastMove.x);
		anim.SetFloat("LastMoveY", lastMove.y);

	}
}