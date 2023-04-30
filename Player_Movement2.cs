using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*public enum PlayerState
{
    idle, walk, attack, interact
}*/
//=====================================================================================
public class Player_Movement2 : MonoBehaviour
{
    #region Variables
    [SerializeField]
    GameObject playerHitboxR, playerHitboxL;

    bool isWalking = false;
    bool isAttacking = false;
    // Reference to PlayerState enum

    // public PlayerState currentState;

    // Speed for player movement.
    public float speed;
    private Rigidbody2D myRigidbody;
    // Variable for how much we want the players position to change.
    private Vector2 changeMovement;
    // Reference to animator
    private Animator animator;
    // nested gameobject of player
    public Transform hitbox;
   

    SpriteRenderer flipSprite;
   

    // Animation States
    private string caterpillarMoveLeftRight = "CP_Monarch_left_right";
    private string caterpillarIdle = "CP_Monarch_idle";
    private string caterpillarStand = "CP_Monarch_Stand";
    //private string caterpillarSit = "CP_Monarch_Sit";
    #endregion
    private void Start()
    {
        //currentState = PlayerState.walk;

        animator = GetComponent<Animator>();
        myRigidbody = GetComponent<Rigidbody2D>();
        flipSprite = GetComponent<SpriteRenderer>();

        // sets the players hitbox to inactive.
        playerHitboxR.SetActive(false);
        playerHitboxL.SetActive(false);

        // Start the player in the idle facing down animation.

    }
    void Update()
    {
        // Every frame we will reset the change in movement to zero.
        changeMovement = Vector2.zero;
        // Getting input axial data from the player on the x and y axis.
        // changeMovement.x = Input.GetAxisRaw(""); Use this if you dont want
        // it to interpolate between 0 and 1.
        changeMovement.x = Input.GetAxis("Horizontal");
        changeMovement.y = Input.GetAxis("Vertical");

        //--------------------------------------------------------------------------------
        // Attacking:
        if (Input.GetButtonDown("eat") && !isAttacking)
        {
            // If the attack button in the project settings was pressed
            // and the current state is not the player is not attacking
            // we will start the coroutine.
            StartCoroutine(AttackCo());

        }
        //--------------------------------------------------------------------------------
    }

    private void FixedUpdate()
    {
        MoveAnimation();
    }

    void MoveAnimation()
    {
        // Normalizes diagonal movement.
        changeMovement.Normalize();
        // Gets the position of the player and adds the change in movement multiplied 
        // by the speed multiplied by how much time has passed in the previous frame.
        myRigidbody.MovePosition(myRigidbody.position + changeMovement * speed * Time.fixedDeltaTime);

        // If player is moving
        if (changeMovement != Vector2.zero)
        {

            if (changeMovement.x > 0 && !isAttacking)
            {
                animator.Play(caterpillarMoveLeftRight);
                // flips the gameobject to face right on the x axis
                // transform.localScale = new Vector3(1, 1, 1);
                flipSprite.flipX = false;
            }
            else if (changeMovement.x < 0 && !isAttacking)
            {
                animator.Play(caterpillarMoveLeftRight);
                // flips the gameobject to face left on the x axis
                // Caterpillar_hiCaterpillar_hitboxtransform.localScale = new Vector3(-1, 1, 1);
                flipSprite.flipX = true;
            }
            // Sets the animator boolean value "moving" to true.
            isWalking = true;

        }
        // If player is not moving
        else if (changeMovement.x == 0 && !isAttacking)
        {
            // Sets the animator boolean value "moving" to false.
            isWalking = false;
            animator.Play(caterpillarIdle);

        }
    }
    /*private void OnTriggerEnter2D(Collider2D collision)
    {
        // If the attached gameObject collides with the hitbox of the caterpillar
        // destroy the game object attached to this script
        if (collision.gameObject.tag == "Water")
        {
            Debug.Log("yo");
            animator.Play(caterpillarStand);
            //Destroy(gameObject,1f);
        }

    }*/

    // Coroutine - Is a method that allows you to add values for it
    // to wait off to the side. It runs parallel to the main
    // process and allows you to build in specif delays.
    private IEnumerator AttackCo()
    {

        isAttacking = true;
        if (isAttacking)
        {
            animator.Play(caterpillarStand);
            // Will enable the apropriate hitbox depending on which way the player is facing.

            if (flipSprite.flipX == false)
            {
                playerHitboxR.SetActive(true);
            }
            else if (flipSprite.flipX == true)
            {
                playerHitboxL.SetActive(true);
            }
            // Wait one frame
            yield return null;
            // Wait about a third of a second
            yield return new WaitForSeconds(1f);
            // Then reset current state.
        }
        isAttacking = false;
        // disable hitboxes
        playerHitboxR.SetActive(false);
        playerHitboxL.SetActive(false);

    }
    
}