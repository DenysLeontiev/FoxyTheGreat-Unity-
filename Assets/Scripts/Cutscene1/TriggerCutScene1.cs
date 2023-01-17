using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TriggerCutScene1 : MonoBehaviour
{
    [SerializeField] Transform bear;
    private PlayerController player;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            player = other.GetComponent<PlayerController>();
            PigMove.playCutScene = true;
            StartCoroutine(FreePlayer(other));
            Destroy(gameObject, 3.1f);
        }
    }

    private IEnumerator FreePlayer(Collider2D collider)
    {
        collider.GetComponent<PlayerController>().canMove = false;
        collider.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePosition;
        collider.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        yield return new WaitForSeconds(3f);
        collider.GetComponent<PlayerController>().canMove = true;
        collider.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;
        collider.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeRotation;
    }
}
