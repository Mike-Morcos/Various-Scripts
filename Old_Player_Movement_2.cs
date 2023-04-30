using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Old_Player_Movement_2 : MonoBehaviour
{
  ////The PlayerControl class is responsible for handling all player input, making
  //  //the character move left and right and jump.

  //  //• To achieve player movement, a reference to the RigidBody2D component is
  //  //retained in the ThisBody variable, which is retrieved in the Awake function.
  //  //The movement and motion of the player is set using the RigidBody2D.
  //  //Velocity variable.
  //  //More information on this variable can be found online at
  //  //http://docs.unity3d.com/ScriptReference/
  //  //Rigidbody2D-velocity.html.

  //  //• The FlipDirection function is used to invert the horizontal scale of the
  //  //sprite, turning it to face left or right as needed (reversing the image direction,
  //  //for example, 1 and -1). From Unity 5.3 onward, the Flip property of the
  //  //SpriteRenderer component can be used instead.

  //  //• The FixedUpdate function is used instead of Update to update
  //  //the movement of the player character because we're working with
  //  //RigidBody2D—a physics-based component.All physics functionality should
  //  //be updated in FixedUpdate that is invoked at a fixed interval each second as
  //  //opposed to every frame.
  //  //--------------------------------
  //  //Which direction is the player facing - left or right?
  //  public enum FACEDIRECTION { FACELEFT = -1, FACERIGHT = 1 };
  //  public enum BUTTONS { RIGHT, LEFT, UP, DOWN, IDLE, SHOOT };
  //  public FACEDIRECTION Facing = FACEDIRECTION.FACERIGHT;
  //  //Which objects are tagged as ground
  //  //public LayerMask GroundLayer;
  //  //Reference to rigidbody
  //  private Rigidbody2D ThisBody = null;
  //  //Reference to transform
  //  private Transform ThisTransform = null;
  //  // Reference to the turret which is a child of the game object.
  //  public Transform turret;

  //  ////+++++++++++++++++++++++++++++++++++++++++++++++++++++++
  //  ////Reference to feet collider
  //  //public CircleCollider2D FeetCollider = null;
  //  //  
  //  ////Are we touching the ground?
  //  //public bool isGrounded = false;
  //  ////+++++++++++++++++++++++++++++++++++++++++++++++++++++++
  //  //What are the main input axes
  //  public string HorzAxis = "Horizontal";
  //  public string VertAxis = "Vertical";

  //  public int horz = 0;
  //  public int vert = 0;

  //  //Speed variables
  //  public float MaxSpeed = 50f;

  //  //Can we control player?
  //  public bool CanControl = true;
  //  public static Player_Movement_2 PlayerInstance = null;
  //  //+++++++++++++++++++++++++++++++++++++++++++++++++++++++
  //  private Animator animator;
  //  // reference to animations
  //  private string fly = "Bee";
  //  //private string idle = "idle";
  //  //+++++++++++++++++++++++++++++++++++++++++++++++++++++++
  //  //&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&

  //  int mobileDirection = 0;
  //  //&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&

  //  //****************************************************************
  //  public string FireAxis = "Fire1";
  //  public float ReloadDelay = 0.1f;
  //  public bool CanFire = true;
  //  public Transform[] TurretTransforms;
  //  //****************************************************************
  //  //--------------------------------
  //  public static float Health
  //  {
  //      get
  //      {
  //          return _Health;
  //      }
  //      set
  //      {
  //          _Health = value;
  //          //If we are dead, then end game
  //          if (_Health <= 0)
  //          {
  //              Die();
  //          }
  //      }
  //  }
  //  [SerializeField]
  //  private static float _Health = 100f;
  //  //--------------------------------
  //  // Use this for initialization
  //  void Awake()
  //  {
  //      //Get transform and rigid body
  //      ThisBody = GetComponent<Rigidbody2D>();
  //      ThisTransform = GetComponent<Transform>();
  //      animator = GetComponent<Animator>();
  //      //Set static instance
  //      PlayerInstance = this;
  //  }
  //  //--------------------------------
  //  //Returns bool - is player on ground?
  //  //private bool GetGrounded()
  //  //{
  //  //    //Check ground

  //  //    //  The GetGrounded function detects where any CircleCollider intersects
  //  //    //and overlaps with any other collider in the scene on a specific layer. In short,
  //  //    //this function indicates whether the player character is touching the ground at
  //  //    //the position of the feet.If so, the player is able to jump; otherwise, the player
  //  //    //cannot jump as they are already airborne.
  //  //    //+++++++++++++++++++++++++++++++++++++++++++++++++++++++
  //  //    Vector2 CircleCenter = new Vector2(ThisTransform.position.x,
  //  //    ThisTransform.position.y) + FeetCollider.offset;
  //  //    Collider2D[] HitColliders =
  //  //    Physics2D.OverlapCircleAll(CircleCenter,
  //  //    FeetCollider.radius, GroundLayer);
  //  //    if (HitColliders.Length > 0) return true;
  //  //    return false;
  //  //    //+++++++++++++++++++++++++++++++++++++++++++++++++++++++

  //  //}
  //  //--------------------------------

  //  //Flips character direction
  //  private void FlipDirection()
  //  {
  //      Facing = (FACEDIRECTION)((int)Facing * -1f);
  //      ThisTransform.Rotate(0f, 180f, 0f);
  //      //Vector2 LocalScale = ThisTransform.localScale;
  //      //LocalScale.x *= -1f;
  //      //ThisTransform.localScale = LocalScale;
  //  }


  //  // Update is called once per frame
  //  void FixedUpdate()
  //  {
  //      //If we cannot control character, then exit
  //      if (!CanControl || Health <= 0f)
  //      {
  //          return;
  //      }
  //      ////+++++++++++++++++++++++++++++++++++++++++++++++++++++++
  //      //// Checks if the player is grounded
  //      //isGrounded = GetGrounded();
  //      ////+++++++++++++++++++++++++++++++++++++++++++++++++++++++


  //      //float Horz = Input.GetAxisRaw(HorzAxis);
  //      //float Vert = Input.GetAxisRaw(VertAxis);
  //      // Move the player and jump
  //      animator.Play(fly);
  //      //--------------------------------------------------------------------
  //      ThisBody.AddForce(Vector2.right * horz * MaxSpeed);
  //      ThisBody.AddForce(Vector2.up * vert * MaxSpeed);
  //      // right
  //      if (mobileDirection == 1)
  //      {
  //          horz = 1;
  //          //ThisBody.AddForce(Vector2.right * Horz * MaxSpeed);
  //      }
  //      // left      
  //      else if (mobileDirection == 2)
  //      {
  //          horz = -1;
  //          //ThisBody.AddForce(Vector2.up * Vert * MaxSpeed);
  //      }
  //      // Down
  //      else if (mobileDirection == 3)
  //      {
  //          vert = -1;
  //          // ThisBody.AddForce(Vector2.up * Vert * MaxSpeed);
  //      }
  //      // Up
  //      else if (mobileDirection == 4)
  //      {
  //          vert = 1;
  //          //ThisBody.AddForce(Vector2.up * Vert * MaxSpeed);
  //      }
  //      else if (mobileDirection == 0)
  //      {
  //          vert = 0;
  //          horz = 0;
  //          //ThisBody.AddForce(Vector2.up * Vert * MaxSpeed);
  //      }

  //      //--------------------------------------------------------------------
  //      //****************************************************************
  //      //Check fire control
  //      //if (Input.GetButton(FireAxis) && CanFire)
  //      //{
  //      //    foreach (Transform T in TurretTransforms)
  //      //        Ammo_Manager.SpawnAmmo(T.position, T.rotation);
  //      //    CanFire = false;
  //      //    Invoke("EnableFire", ReloadDelay);
  //      //}

  //      //****************************************************************



  //      //&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&

  //      //if (Input.GetButton(JumpButton) && CanJump)
  //      //    StartCoroutine(Jump());
  //      //if (mobileDirection == 1 && CanJump)
  //      //{
  //      //    StartCoroutine(Jump());
  //      //    ThisBody.AddForce(Vector2.right * 8 * MaxSpeed);
  //      //}
  //      //else if (mobileDirection == -1 && CanJump)
  //      //{
  //      //    StartCoroutine(Jump());
  //      //    ThisBody.AddForce(Vector2.right * -8 * MaxSpeed);
  //      //}
  //      if (mobileDirection == 5 && CanFire)
  //      {
  //          foreach (Transform T in TurretTransforms)
  //              Ammo_Manager.SpawnAmmo(T.position, T.rotation);
  //          CanFire = false;
  //          Invoke("EnableFire", ReloadDelay);
  //      }
  //      //&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&


  //      // Clamps the speed within a specified range.
  //      ThisBody.velocity = new Vector2
  //      (
  //          Mathf.Clamp(ThisBody.velocity.x, -MaxSpeed, MaxSpeed),
  //          Mathf.Clamp(ThisBody.velocity.y, -MaxSpeed, MaxSpeed)
  //      );
  //      //---------------------------------------------------------------
  //      //Flip direction if required
  //      if ((horz < 0f && Facing != FACEDIRECTION.FACELEFT) ||
  //      (horz > 0f && Facing != FACEDIRECTION.FACERIGHT))
  //          FlipDirection();
  //      //---------------------------------------------------------------
  //      //&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&
  //      //flip direction if required

  //      //if ((mobileDirection < 0f && Facing != FACEDIRECTION.FACELEFT) ||
  //      //(mobileDirection > 0f && Facing != FACEDIRECTION.FACERIGHT))
  //      //        FlipDirection();

  //      //&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&
  //  }
  //  //--------------------------------
  //  void EnableFire()
  //  {
  //      CanFire = true;
  //  }
  //  void OnDestroy()
  //  {
  //      PlayerInstance = null;
  //  }
  //  //--------------------------------
  //  //Function to kill player
  //  static void Die()
  //  {
  //      Debug.Log("dead");
  //      //Destroy(Player_Movement.PlayerInstance.gameObject);
  //      //SceneManager.LoadScene("Menu");
  //  }
  //  //--------------------------------
  //  //Resets player back to defaults
  //  public static void Reset()
  //  {
  //      Health = 100f;
  //  }
  //  //--------------------------------
  //  //&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&

  //  public void MoveRight()
  //  {
  //      mobileDirection = 1;
  //  }
  //  public void MoveLeft()
  //  {
  //      mobileDirection = 2;
  //  }
  //  public void MoveDown()
  //  {
  //      mobileDirection = 3;
  //  }
  //  public void MoveUp()
  //  {
  //      mobileDirection = 4;
  //  }

  //  public void shootBullet()
  //  {
  //      mobileDirection = 5;
  //  }
  //  public void MoveNone()
  //  {
  //      mobileDirection = 0;
  //  }
    //&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&
}
