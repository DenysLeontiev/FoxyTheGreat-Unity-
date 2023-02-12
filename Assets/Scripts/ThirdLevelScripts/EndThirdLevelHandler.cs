using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EndThirdLevelHandler : MonoBehaviour
{
    [SerializeField] private GameObject winPanel;
    [SerializeField] private GameObject[] objectsToDeactivate; // Move Buttons, Joystick, Menu, Rain Panel 
    private bool isPanelShowed = false;

    private void Update()
    {
        if(PlayerController.scoreText >= 1 && !isPanelShowed)
        {
            ShowWinPanel();
        }
    }

    private void ShowWinPanel()
    {
        Time.timeScale = 0f;
        isPanelShowed = true;
        winPanel.SetActive(true);
        foreach (GameObject obj in objectsToDeactivate)
        {
            obj.SetActive(false);
        }
    }

    public void GoToMenuButton()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
    }
}
