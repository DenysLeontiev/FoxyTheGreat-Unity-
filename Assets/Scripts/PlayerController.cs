using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public static bool canMove = true;

    [SerializeField] Joystick joystick;
    [Header("Move Props")]
    [SerializeField] private float moveSpeed = 6f;
    [SerializeField] private float crouchSpeed = 3f;
    [SerializeField] private float jumpPower = 1f;

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

        if(canMove)
        {
            HandleFallAnimation();
            MovePlayerJoystik();
            FlipSprite();
            Jump();
        }
    }

    public void Fall() // Event anim
    {
        canFall = true;
    }

    private void HandleFallAnimation()
    {
        if (!IsGrounded() && canFall)
        {
            animator.Play("PlayerFall");
        }
        if (IsGrounded())
        {
            animator.SetTrigger("goToIdle");
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
        if(Input.GetButtonDown("Jump") && jumpCounter > 0)
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
        if(IsGrounded())
        {
            jumpCounter = startJumpCounter;
        }
        if(jumpCounter > 0)
        {
            if(IsGrounded())
            {
                animator.SetTrigger("jump");
            }
            jumpCounter--;
            myRigidbody.velocity += new Vector2(0f, jumpPower);
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
        return myCapsuleCollider.IsTouchingLayers(LayerMask.GetMask("Ground"));
    }
}
