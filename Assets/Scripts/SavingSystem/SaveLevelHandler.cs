using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveLevelHandler : MonoBehaviour
{
    [SerializeField] private bool isFirstLevel;
    [SerializeField] private bool isSecondLevel;
    [SerializeField] private bool isThirdLevel;
    [SerializeField] private bool isFourthLevel;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        SaveLevels();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        SaveLevels();
    }

    private void SaveLevels()
    {
        LevelsProgress levelsProgress = new LevelsProgress(isFirstLevel, isSecondLevel, isThirdLevel, isFourthLevel);
        SaveLevelSystem.SaveLevels(levelsProgress);
        Debug.Log("Saved " + isFirstLevel + "| " + isSecondLevel + "| " + isThirdLevel + "| ");
    }

    public void LoadLevels()
    {
        LevelsProgress levelsProgress = SaveLevelSystem.LoadLevels();
    }
}
