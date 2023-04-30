using TMPro;
using UnityEngine;


public class EnemyFollow : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI finalScore;
    public static bool stopScore;
    public static bool stopTimer;
    [SerializeField] Transform target;
    float currentYpos;
    float speed = 2.5f;
    [SerializeField] GameObject restartMenu;

    [SerializeField] Animator anim;

    bool setTimer;
    float timer;
    private void Start()
    {
        stopTimer = true;
        timer = 6f;
        currentYpos = transform.position.y;
        setTimer = false;
    }
    void Update()
    {
        if(setTimer)
        {
            
            timer -= Time.fixedDeltaTime;

            if (timer < 0)
            {
                restartMenu.SetActive(true);
            }
        }
        //***********************************************************************
        if (Ui_Manager.trackSpeed > 5 && Ui_Manager.trackSpeed < 7)
        {
            anim.speed = 1.3f;
        }
        else if (Ui_Manager.trackSpeed > 7.5)
        {
            anim.speed = 1.6f;
        }
        //***********************************************************************

        if (Player_Movement.enemyMove == false)
        {
            transform.position = Vector2.MoveTowards(transform.position, new Vector2(target.position.x, transform.position.y), speed * Time.deltaTime);
            
        }
        else if (Player_Movement.enemyMove == true)
        {
            
            if (currentYpos < transform.position.y - 2f)
            {
                transform.position = Vector2.MoveTowards(transform.position, new Vector2(target.position.x, target.position.y), speed * Time.deltaTime);
            }
            else
            {
                Player_Movement.enemyMove = false;
                currentYpos -= 2f;
            }

        }

        if(transform.position.y < target.position.y)
        {
            transform.position = Vector2.MoveTowards(transform.position, new Vector2(target.position.x, target.position.y), speed * Time.deltaTime);
        }


    }

    private void OnTriggerEnter2D(Collider2D collision)
    {   
        if (collision.tag == "Obstacle")
        {
            Audio_Manager.instance.PlaySFX(0);
            anim.Play("JackJump");
        }
        if (collision.tag == "Player" /*|| transform.position == target.position*/)
        {
            Ui_Manager.trackSpeed = 0f;
            collision.gameObject.SetActive(false);
            anim.Play("JackEat");
            //Player_Movement.enemyMove = false;

            finalScore.text = Ui_Manager.finalScoreText;
            setTimer = true;
            stopScore = true;
            Ui_Manager.finalScoreText = finalScore.text;

            stopTimer = false;
            
        }
    }
}
