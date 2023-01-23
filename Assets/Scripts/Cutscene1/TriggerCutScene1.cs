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
        Rigidbody2D playerRigidbody = other.GetComponent<Rigidbody2D>();
        if(other.tag == "Player")
        {
            player = other.GetComponent<PlayerController>();
            PigMove.playCutScene = true;
            PlayerController.canMove = false;
            playerRigidbody.constraints = RigidbodyConstraints2D.FreezePosition;
            Destroy(gameObject);
        }
    }

    private IEnumerator FreezePlayer(Collider2D collider)
    {
        PlayerController.canMove = false;
        // collider.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePosition;
        collider.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        yield return new WaitForSeconds(9f);
        // collider.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;
        collider.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeRotation;
    }
}
