using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI textMesh;
    private int scoreText = 0;
    [SerializeField] private Button jumpBtn;

    public static bool canMove = true;
    public static bool isOnLadder = false;

    [SerializeField] Joystick joystick;
    [Header("Move Props")]
    [SerializeField] private float moveSpeed = 6f;
    [SerializeField] private float crouchSpeed = 3f;
    [SerializeField] private float jumpPower = 1f;

    [SerializeField] private float climbLadderSpeed = 0.1f;

    private SpriteRenderer spriteRenderer;
    private Animator animator;
    private Rigidbody2D myRigidbody;
    private CapsuleCollider2D myCapsuleCollider;

    [Header("Jump Props")]
    [SerializeField] int jumpCounter = 1;
    private int startJumpCounter;

    private bool canFall = false;

    public static bool isCrouching;

    void Start()
    {
        startJumpCounter = jumpCounter;
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        myRigidbody = GetComponent<Rigidbody2D>();
        myCapsuleCollider = GetComponent<CapsuleCollider2D>();
    }

    void Update()
    {
        if(transform.position.y < -10f)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        ClimbLadder();
        if (canMove)
        {
            HandleFallAnimation();
            MovePlayerJoystik();
            FlipSprite();
            if (isOnLadder == false)
            {
                Jump();
            }

        }
    }

    public void Fall() // Event anim
    {
        if(isOnLadder == false)
        {
            canFall = true;
        }
    }

    private void HandleFallAnimation()
    {
        if(isOnLadder) { return; }
        if (!IsGrounded() && canFall)
        {
            animator.Play("PlayerFall");
        }
        if (IsGrounded())
        {
            animator.SetTrigger("goToIdle");
            isOnLadder = false;
        }
    }

    private void MovePlayerJoystik()
    {
        // var horizontalInnput = Input.GetAxisRaw("Horizontal");
        var horizontalInnput = joystick.Horizontal;
        myRigidbody.velocity = new Vector2(horizontalInnput * moveSpeed, myRigidbody.velocity.y);

        if(Mathf.Abs(myRigidbody.velocity.x) > 0 && IsGrounded())
        {
            animator.SetBool("run", true);
        }
        else
        {
            animator.SetBool("run", false);
        }
    }

    private void MovePlayer()
    {
        var horizontalInnput = Input.GetAxisRaw("Horizontal");
        // var horizontalInnput = joystick.Horizontal;
        myRigidbody.velocity = new Vector2(horizontalInnput * (isCrouching ? crouchSpeed : moveSpeed), myRigidbody.velocity.y);

        if(Mathf.Abs(myRigidbody.velocity.x) > 0 && IsGrounded())
        {
            animator.SetBool("run", true);
        }
        else
        {
            animator.SetBool("run", false);
        }
    }

    private void FlipSprite()
    {
        bool playerHasHorizontalSpeed = Mathf.Abs(myRigidbody.velocity.x) > Mathf.Epsilon;

        if(playerHasHorizontalSpeed)
        {
            transform.localScale = new Vector2(Mathf.Sign(myRigidbody.velocity.x), 1f);
        }
    }

    private void Jump()
    {
        if(IsGrounded())
        {
            jumpCounter = startJumpCounter;
        }
        if(Input.GetButtonDown("Jump") && jumpCounter > 0 && !isOnLadder)
        {
            if(IsGrounded())
            {
                animator.SetTrigger("jump");
            }
            jumpCounter--;
            Vector2 t = transform.up;
            myRigidbody.velocity += new Vector2(0f, jumpPower * t.y);
        }
    }

    public void JumpButton()
    {
        if(!isOnLadder)
        {
            if (IsGrounded())
            {
                jumpCounter = startJumpCounter;
            }
            if (jumpCounter > 0)
            {
                if (IsGrounded())
                {
                    animator.SetTrigger("jump");
                }
                jumpCounter--;
                myRigidbody.velocity += new Vector2(0f, jumpPower);
            }
        }
    }

    public void CrouchButtonUp()
    {
        if(IsGrounded())
        {
            animator.SetBool("crouch", true);
        }
    }

    public void CrouchButtonDown()
    {
        animator.SetBool("crouch", false);
    }

    private bool IsGrounded()
    {
        return myCapsuleCollider.IsTouchingLayers(LayerMask.GetMask("Ground")) || myCapsuleCollider.IsTouchingLayers(LayerMask.GetMask("Spikes"));
    }

    private void ClimbLadder()
    {
        if(isOnLadder && ClimbLadderBtn.isClimpLadderButtonPressed)
        {
            myRigidbody.gravityScale = 0f;
            animator.SetBool("climb", true);
            myRigidbody.velocity += new Vector2(myRigidbody.velocity.x, climbLadderSpeed);   
        }
        else
        {
            myRigidbody.gravityScale = 1f;
            animator.SetBool("climb", false);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Ladder"))
        {
            isOnLadder = true;
            canFall = false;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Ladder"))
        {
            isOnLadder = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.tag == "Heart")
        {
            scoreText++;
            textMesh.text = $"{scoreText}/100";
        }
    }
}
