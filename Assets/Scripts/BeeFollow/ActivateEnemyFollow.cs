using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateEnemyFollow : MonoBehaviour
{
    [SerializeField] private GameObject beeParent;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            beeParent.SetActive(true);
            this.gameObject.SetActive(false);
        }
    }
}
