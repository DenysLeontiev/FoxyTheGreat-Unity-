using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float speed = 1f;
    private Rigidbody2D myRigidbody;
    private Transform player;

    void Awake()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
        player = FindObjectOfType<PlayerHealth>().transform;
    }

    void Update()
    {
        myRigidbody.AddForce(new Vector2(speed, 0f));
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.transform.tag == "Player")
        {
            StartCoroutine(player.GetComponent<PlayerHealth>().RemoveHeart());
        }

        Destroy(gameObject);
    }
}
