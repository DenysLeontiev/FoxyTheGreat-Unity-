using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class LevelsProgress
{
    public bool isFirstLevel;
    public bool isSecondLevel;
    public bool isThirdLevel;

    public LevelsProgress(bool isFirstLevel, bool isSecondLevel, bool isThirdLevel)
    {
        this.isFirstLevel = isFirstLevel;
        this.isSecondLevel = isSecondLevel;
        this.isThirdLevel = isThirdLevel;
    }
}
