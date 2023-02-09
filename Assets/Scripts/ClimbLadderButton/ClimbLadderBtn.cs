using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ClimbLadderBtn : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public static bool isClimpLadderButtonPressed = false;

    private void Update()
    {
        print(isClimpLadderButtonPressed);
    }


    public void OnPointerDown(PointerEventData eventData)
    {
        if (!PlayerController.isOnLadder) return;
        isClimpLadderButtonPressed = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        if (PlayerController.isOnLadder) return;
        isClimpLadderButtonPressed = false;
    }
}
