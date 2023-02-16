using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour //  this script is added to child(kill collider)
{
    [SerializeField] private float colorChangeSpeed = 1f;
    [SerializeField] private Color defaultColor;
    [SerializeField] private Color dietColor;
    private MoveObjects enemy;
    private Animator animator;
    private SpriteRenderer spriteRenderer;

    private void Start()
    {
        animator = GetComponentInParent<Animator>();
        enemy = GetComponentInParent<MoveObjects>();
        spriteRenderer = GetComponentInParent<SpriteRenderer>();
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.transform.tag == "Player")
        {
            Die();
        }
    }

    private void Die()
    {
        transform.GetComponent<BoxCollider2D>().enabled= false;
        animator.SetTrigger("die");
        enemy.speed = 0f;
        Destroy(transform.parent.transform.parent.gameObject, 1.1f);

    }
}
