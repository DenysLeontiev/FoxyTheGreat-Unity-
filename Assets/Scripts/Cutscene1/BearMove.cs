using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BearMove : MonoBehaviour
{
    [SerializeField] private Transform goAwayPoint;
    [SerializeField] private float bearSpeed = 0.02f;

    public static bool activateBear = false;
    public static bool isDialogueFinished = false;

    private PlayerController player;
    private Animator animator;
    private bool hasReachedPlayer = false;

    private void Start()
    {
        player = FindObjectOfType<PlayerController>();
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if(DialogueManager.hasDisplayedLastLine)
        {
            BearGoAway();
        }
        if(activateBear && hasReachedPlayer == false)
        {
            Vector2 playerPos = new Vector2(player.transform.position.x, transform.position.y);
            transform.position = Vector2.MoveTowards(transform.position, playerPos, 0.02f);
            animator.SetBool("run", true);
            transform.localScale = new Vector2(-1, 1);


            float distncBtwn = Vector2.Distance(transform.position, player.transform.position);
            if(distncBtwn < 2f)
            {
                hasReachedPlayer = true;
                animator.SetBool("run", false);
                animator.SetTrigger("right");
                DialogueManager.displayDialogue = true;
            }
        }
    }

    private void BearGoAway()
    {
        animator.SetTrigger("runLeft");
        Rigidbody2D playerRigidbody = player.GetComponent<Rigidbody2D>();

        Vector2 destination = new Vector2(goAwayPoint.position.x, transform.position.y);
        transform.position = Vector2.MoveTowards(transform.position, destination, bearSpeed);

        if(Vector2.Distance(transform.position, destination) < 2f)
        {
            PlayerController.canMove = true;
            playerRigidbody.constraints = RigidbodyConstraints2D.None;
            playerRigidbody.constraints = RigidbodyConstraints2D.FreezeRotation;
            Destroy(gameObject);
        }
    }
}
