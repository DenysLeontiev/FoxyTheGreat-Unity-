using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuHandler : MonoBehaviour
{
    [SerializeField] private GameObject firstBtn;
    [SerializeField] private GameObject secondBtn;
    [SerializeField] private GameObject thirdBtn;
    [SerializeField] private GameObject fourthBtn;

    [SerializeField] private GameObject lockImage;
    [SerializeField] private Vector3 lockImageCoordinates = Vector3.zero;

    [SerializeField] private GameObject lockedLevelPanel;

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
        ActivateButton(firstBtn, levelsProgress.isFirstLevel);
        ActivateButton(secondBtn, levelsProgress.isSecondLevel);
        ActivateButton(thirdBtn, levelsProgress.isThirdLevel);
        ActivateButton(fourthBtn, levelsProgress.isFourthLevel);
    }

    private void ActivateButton(GameObject buttonObj, bool isActive)
    {
        if (isActive == false)
        {
            HandleButtonActivation(buttonObj);
            buttonObj.GetComponent<Button>().enabled = false;
        }
        //buttonObj.GetComponent<Button>().onClick.AddListener(delegate { OnClickBtn(isActive); });
    }

    private void HandleButtonActivation(GameObject buttonObject)
    {
        Instantiate(lockImage, buttonObject.transform.position + lockImageCoordinates, Quaternion.identity, buttonObject.transform);
        buttonObject.GetComponent<Image>().color = new Color(255, 255, 255, 0.6f);
    }

    private void OnClickBtn(bool isActive)
    {   
        if(!isActive)
        {
            StartCoroutine(ShowLockPanel());
        }
    }

    private IEnumerator ShowLockPanel()
    {
        lockedLevelPanel.SetActive(true);
        yield return new WaitForSeconds(2.5f);
        lockedLevelPanel.SetActive(false);
    }

    public void BackToMainMenu()
    {
        SceneManager.LoadScene(0);
    }

    private void GoToLevelByIndex(int levelIndex)
    {
        SceneManager.LoadScene(levelIndex);
    }
}
