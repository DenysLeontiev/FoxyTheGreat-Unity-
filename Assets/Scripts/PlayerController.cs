using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Move Props")]
    [SerializeField] private float moveSpeed = 6f;
    [SerializeField] private float jumpPower = 1f;

    private SpriteRenderer spriteRenderer;
    private Animator animator;
    private Rigidbody2D myRigidbody;
    private CapsuleCollider2D myCapsuleCollider;

    [Header("Jump Props")]
    [SerializeField] int jumpCounter = 1;
    private int startJumpCounter;

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
        MovePlayer();
        FlipSprite();
        Jump();
    }

    private void MovePlayer()
    {
        var horizontalInnput = Input.GetAxisRaw("Horizontal");
        myRigidbody.velocity = new Vector2(horizontalInnput * moveSpeed, myRigidbody.velocity.y);

        if(Mathf.Abs(myRigidbody.velocity.x) > 0)
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
            jumpCounter--;
            myRigidbody.velocity += new Vector2(0f, jumpPower);
        }
    }

    private bool IsGrounded()
    {
        return myCapsuleCollider.IsTouchingLayers(LayerMask.GetMask("Ground"));
    }
}
