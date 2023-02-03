using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuHandler : MonoBehaviour
{
    [SerializeField] private GameObject firstBtn;
    [SerializeField] private GameObject secondBtn;
    [SerializeField] private GameObject thirdBtn;

    private LevelsProgress levelsProgress;

    void Awake()
    {
        levelsProgress = SaveLevelSystem.LoadLevels();
    }

    private void Start()
    {
        Debug.Log(levelsProgress.isFirstLevel + "|" + levelsProgress.isSecondLevel + "|" + levelsProgress.isThirdLevel + "|");
        if (levelsProgress.isFirstLevel == false)
        {
            firstBtn.SetActive(false);
        }
        if (levelsProgress.isSecondLevel == false)
        {
            secondBtn.SetActive(false);
        }
        if (levelsProgress.isThirdLevel == false)
        {
            thirdBtn.SetActive(false);
        }
    }

    void Update()
    {
        
    }
}
