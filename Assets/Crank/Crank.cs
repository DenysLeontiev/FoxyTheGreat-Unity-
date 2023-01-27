using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crank : MonoBehaviour
{
    [SerializeField] private float triggerDistance;
    [SerializeField] private GameObject activateButton;
    [SerializeField] private float delayTime = 1f;

    private Transform player;
    private Animator animator;

    private void Start()
    {
        player = GameObject.FindWithTag("Player").transform;
        animator = GetComponent<Animator>();
        activateButton.SetActive(false);
    }

    private void Update()
    {
        HandleActivation();

        if(ButtonEvent.isCrankActivated)
        {
            animator.SetTrigger("activate");
            StartCoroutine(ButtonDisapper());
            CameraCutScene1.activateCutsceneCam = true;
        }
    }

    private void HandleActivation()
    {
        float distanceBentween = Vector2.Distance(transform.position, player.position);

        if (distanceBentween < triggerDistance)
        {
            activateButton.SetActive(true);
            activateButton.GetComponent<Animator>().SetBool("dis", false);
        }
        else if(distanceBentween >= triggerDistance && ButtonEvent.isCrankActivated)
        {
            StartCoroutine(ButtonDisapper());
        }
    }

    private IEnumerator ButtonDisapper()
    {
        activateButton.GetComponent<Animator>().SetBool("dis", true);
        yield return new WaitForSeconds(delayTime);
        activateButton.SetActive(false);
    }
}
