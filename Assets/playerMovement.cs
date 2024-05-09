
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    [SerializeField]
    private float walkSpeed = 10f;

    private Animator animator;

    private float xAxis;
    private float yAxis;
    private Rigidbody2D rb2d;
    private bool isJumpPressed;
    private float jumpForce = 1850;
    private int groundMask;
    private bool isGrounded;
    private string currentAnimaton;
    private bool isAttackPressed;
    private bool isAttacking;

    [SerializeField]
    private float attackDelay = 0.3f;

    //Animation States
    const string PLAYER_IDLE = "playerIdle";
    const string PLAYER_RUN = "playerRun";
    const string PLAYER_JUMP = "playerJump";
    const string PLAYER_FALL = "playerFall";
    const string PLAYER_ATTACK = "playerSlash";
    const string PLAYER_ATTACK2 = "playerStab";

    //=====================================================
    // Start is called before the first frame update
    //=====================================================
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        groundMask = 1 << LayerMask.NameToLayer("Ground");

    }

    //=====================================================
    // Update is called once per frame
    //=====================================================
    void Update()
    {
        //Checking for inputs
        xAxis = Input.GetAxisRaw("Horizontal");

        //space jump key pressed?
        if (Input.GetKeyDown(KeyCode.Space))
        { 
            isJumpPressed = true;
            Debug.Log("Jump pressed");
        }

        //space Atatck key pressed?
        if (Input.GetKeyDown(KeyCode.RightControl))
        {
            isAttackPressed = true;
            Debug.Log("Attack pressed");
        }
    }

    //=====================================================
    // Physics based time step loop
    //=====================================================
    private void FixedUpdate()
    {
        //check if player is on the ground
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, 1.5f, groundMask);

        if (hit.collider != null)
        {
            isGrounded = true;
            Debug.Log("Grounded");
        }
        else
        {
            isGrounded = false;
        }

        //------------------------------------------

        //Check update movement based on input
        Vector2 vel = new Vector2(0, rb2d.velocity.y);

        if (xAxis < 0)
        {
            vel.x = -walkSpeed;
            transform.localScale = new Vector2(-1, 1);
        }
        else if (xAxis > 0)
        {
            vel.x = walkSpeed;
            transform.localScale = new Vector2(1, 1);
        }
        else
        {
            vel.x = 0;
        }

        if (isGrounded && !isAttacking)
        {
            if (xAxis != 0)
            {
                ChangeAnimationState(PLAYER_RUN);
            }
            else
            {
                ChangeAnimationState(PLAYER_IDLE);
            }
        }

        //------------------------------------------

        //Check if trying to jump 
        if (isJumpPressed && isGrounded)
        {
            rb2d.AddForce(new Vector2(0, jumpForce));
            isJumpPressed = false;
            ChangeAnimationState(PLAYER_JUMP);
            Debug.Log("jump animating?");
        }

        //assign the new velocity to the rigidbody
        rb2d.velocity = vel;


        //attack
        if (isAttackPressed)
        {
            isAttackPressed = false;

            if (!isAttacking)
            {
                isAttacking = true;

                if(isGrounded)
                {
                    ChangeAnimationState(PLAYER_ATTACK2);
                }
                else
                {
                    if (xAxis > 0)
                    {
                        transform.localScale = new Vector3(1,1,1);
                    }
                    else if(xAxis < 0)
                    {
                        transform.localScale = new Vector3(-1,1,1);
                    }
                    ChangeAnimationState(PLAYER_ATTACK);
                }
                Invoke("AttackComplete", attackDelay);
                Debug.Log("Force complete attack");

            }


        }

    }

    void AttackComplete()
    {
        isAttacking = false;
    }

    //=====================================================
    // mini animation manager
    //=====================================================
    void ChangeAnimationState(string newAnimation)
    {
        if (currentAnimaton == newAnimation) return;

        animator.Play(newAnimation);
        currentAnimaton = newAnimation;
    }

}
