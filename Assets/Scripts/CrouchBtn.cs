using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CrouchBtn : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    private PlayerController playerController;

    void Start()
    {
        playerController = FindObjectOfType<PlayerController>();
    }

    void Update()
    {
        if(isPressed)
        {
            PlayerController.isCrouching = true;
            playerController.GetComponent<Animator>().SetBool("crouch", true);
        }
        else
        {
            playerController.GetComponent<Animator>().SetBool("crouch", false);
            PlayerController.isCrouching = false;
        }
    }

    bool isPressed = false;
    public void OnPointerDown(PointerEventData eventData)
    {
        isPressed = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        isPressed = false;
    }
}
