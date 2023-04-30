using UnityEngine;
using UnityEngine.SceneManagement;

public class Butterfly_controler : MonoBehaviour {

    #region Variables
    public float speed;

    private Rigidbody2D rb;
    private bool moving;

    public float timeBetweenMove;
    private float timeBetweenMoveCount;
	// The amount of time moving
    public float moveTime;
    private float moveTimeCount;

    private Vector3 moveDirection;

    public float waitToReload;
    private bool reloading;

    private GameObject thePlayer;

    #endregion

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        // Random time between movement count
        timeBetweenMoveCount = Random.Range(timeBetweenMove * .5f, timeBetweenMove * 2f);
        moveTimeCount = Random.Range(moveTime * .5f, moveTime * 2f);
    }

    void Update ()
    {
		if (moving)
        {
            moveTimeCount -= Time.deltaTime;
            rb.velocity = moveDirection;

            if (moveTimeCount < 0)
            {
                moving = false;
                timeBetweenMoveCount = Random.Range(timeBetweenMove * .5f, timeBetweenMove * 2f);

            }
        }
        else
        {
			// will count down to zero
            timeBetweenMoveCount -= Time.deltaTime;
            rb.velocity = Vector2.zero;

            if (timeBetweenMoveCount < 0f)
            {
                moving = true;
                moveTimeCount = Random.Range(moveTime * .5f, moveTime * 2f);

                moveDirection = new Vector3(Random.Range(-1f, 1f) * speed, Random.Range(-1f, 1f) * speed,0f);
            }

        }

        if(reloading)
        {
            waitToReload -= Time.deltaTime;
            if(waitToReload < 0)
            {
                //SceneManager.LoadScene(" ");
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
                thePlayer.gameObject.SetActive(true);
            }
        }
	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.name == "Kori")
        {
            //Destroy(collision.gameObject);
            collision.gameObject.SetActive(false);
            reloading = true;
            thePlayer = collision.gameObject;
        }
    }
}
