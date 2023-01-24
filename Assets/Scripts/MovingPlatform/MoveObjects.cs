using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MoveObjects : MonoBehaviour
{
    [SerializeField] private Transform[] points; // 0 - starting | 1 - ending
    [SerializeField] private float speed = 1f;
    [SerializeField] private bool isEnemy = false;

    private Transform player;
    [SerializeField] private float distanceToActivatePlatform = 40f;
    private int currentIndex = 0;

    private void Start()
    {
        player = FindObjectOfType<PlayerController>().transform;
    }

    private void Update()
    {
        // if(Vector2.Distance(transform.position, player.position) < distanceToActivatePlatform)
        // {
            MoveBetweenPoints();
        // }
    }

    private void MoveBetweenPoints()
    {
        if(currentIndex >= points.Length)
        {
            currentIndex = 0;
        }

        transform.position = Vector2.MoveTowards(transform.position, points[currentIndex].position, speed * Time.deltaTime);
        float distanceBetween = Vector3.Distance(transform.position, points[currentIndex].position);

        if (distanceBetween < 1f)
        {
            currentIndex++;
        }

        if(isEnemy && distanceBetween < 1f)
        {
            transform.localScale = new Vector2(transform.localScale.x * (-1), transform.localScale.y);
        }
    }

    private void OnCollisionEnter2D(Collision2D other) // make it parent because we want the player to move with the platform
    {
        if(isEnemy == false)
        {
            other.transform.parent = transform;
        }
        else
        {
            if(other.transform.tag == "Player")
            {
                StartCoroutine(player.GetComponent<PlayerHealth>().RemoveHeart());
            }
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if(isEnemy == false)
        {
            other.transform.parent = null;
        }
        else
        {
            
        }
    }
}
