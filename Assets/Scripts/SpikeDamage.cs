using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeDamage : MonoBehaviour
{
    private PlayerHealth player;

    private void Start()
    {
       player = FindObjectOfType<PlayerHealth>();
    }

    private void Update()
    {
        if(player != null)
        {
            if(player.GetComponent<CapsuleCollider2D>().IsTouchingLayers(LayerMask.GetMask("Spikes")))
            {
                StartCoroutine(player.RemoveHeart());
            }
        }
    }

}
