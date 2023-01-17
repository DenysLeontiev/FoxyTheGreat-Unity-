using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BearMove : MonoBehaviour
{
    public static bool activateBear = false;
    public static bool isDialogueFinished = false;

    private PlayerController player;
    private Animator animator;
    private bool hasReachedPlayer = false;

    void Start()
    {
        player = FindObjectOfType<PlayerController>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if(activateBear && hasReachedPlayer == false)
        {
            transform.localScale = new Vector2(-1, 1);
            Vector2 playerPos = new Vector2(player.transform.position.x, transform.position.y);
            transform.position = Vector2.MoveTowards(transform.position, playerPos, 0.02f);
            animator.SetBool("run", true);


            float distncBtwn = Vector2.Distance(transform.position, player.transform.position);
            if(distncBtwn < 2f)
            {
                hasReachedPlayer = true;
                animator.SetBool("run", false);
            }
            print(distncBtwn);
        }
    }
}
