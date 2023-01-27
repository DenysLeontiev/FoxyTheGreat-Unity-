using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonEvent : MonoBehaviour
{
    public static bool isCrankActivated = false;

    public void ActivateCrank()
    {
        isCrankActivated = true;
    }
}
