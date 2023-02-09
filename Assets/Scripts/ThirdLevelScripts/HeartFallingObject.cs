using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HeartFallingObject : MonoBehaviour
{
    private void Start()
    {
        
    }

    void Update()
    {
        if(transform.position.y <= -10f)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
    }
}
