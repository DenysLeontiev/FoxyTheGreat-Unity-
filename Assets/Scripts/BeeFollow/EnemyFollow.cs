using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyFollow : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 2f;
    private Rigidbody2D enemyRigidbody;
    private Transform target;
    private Vector3 moveDirection;
    private bool canFollow = false;

    private void Start()
    {
        enemyRigidbody = GetComponent<Rigidbody2D>();
        target = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void Update()
    {
        if (Vector3.Distance(transform.position, target.position) < 10f)
        {
            this.gameObject.SetActive(true);
        }
        if (target != null)
        {
            Vector3 direction = (target.position - transform.position).normalized;
            float angel  = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            enemyRigidbody.rotation = angel;
            moveDirection = direction;
        }
    }

    private void FixedUpdate()
    {
            transform.localScale = new Vector2(1, -1);
            if (target != null)
            {
                enemyRigidbody.velocity = new Vector2(moveDirection.x, moveDirection.y) * moveSpeed;
            }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        FollowPlayer(collision);
    }

    private void FollowPlayer(Collision2D collision)
    {
        Vector3 newPos;
        if (collision.transform.tag != "Player")
        {
            if (transform.position.y <= target.position.y + 1f)
            {
                newPos = new Vector3(transform.position.x + Random.Range(4, 6), transform.position.y + Random.Range(4, 6));
            }
            else
            {
                newPos = new Vector3(transform.position.x + Random.Range(-4, -6), transform.position.y + Random.Range(-4, -6));
            }

            while (Vector3.Distance(transform.position, newPos) > 1f)
            {
                transform.position = Vector3.Lerp(transform.position, newPos, transform.position.x / newPos.x);
            }
        }
        if (collision.transform.tag == "Player")
        {
            StartCoroutine(target.GetComponent<PlayerHealth>().RemoveHeart());
        }
    }
}
