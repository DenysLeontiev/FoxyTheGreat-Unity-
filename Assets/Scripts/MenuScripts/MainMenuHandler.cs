using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuHandler : MonoBehaviour
{
    [SerializeField] private GameObject firstBtn;
    [SerializeField] private GameObject secondBtn;
    [SerializeField] private GameObject thirdBtn;
    [SerializeField] private GameObject fourthBtn;

    private LevelsProgress levelsProgress;

    void Awake()
    {
        levelsProgress = SaveLevelSystem.LoadLevels();
    }

    private void Start()
    {
        HandleLevelButtons();
    }

    private void HandleLevelButtons()
    {
        firstBtn.SetActive(levelsProgress.isFirstLevel);
        secondBtn.SetActive(levelsProgress.isSecondLevel);
        thirdBtn.SetActive(levelsProgress.isThirdLevel);
        fourthBtn.SetActive(levelsProgress.isFourthLevel);
    }

    public void BackToMainMenu()
    {
        SceneManager.LoadScene(0);
    }
}
