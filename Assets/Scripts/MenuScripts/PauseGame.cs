using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseGame : MonoBehaviour
{
    [SerializeField] private GameObject pausePanel;
    [SerializeField] private GameObject pauseButton;
    [SerializeField] private GameObject upMovementBtn;
    [SerializeField] private GameObject downMovementBtn;

    private Animator panelAnimator;

    private void Start()
    {
        panelAnimator = pausePanel.GetComponent<Animator>();
    }

    private void Update()
    {

    }

    public void ActivatePauseMenu()
    {
        pausePanel.SetActive(true);
        pauseButton.SetActive(false);
        upMovementBtn.SetActive(false);
        downMovementBtn.SetActive(false);
        Time.timeScale = 0f;
    }

    public void DeactivatePauseMenu()
    {
        StartCoroutine(ActivateGameCoroutine());
    }

    private IEnumerator ActivateGameCoroutine()
    {
        Time.timeScale = 1f;
        panelAnimator.SetTrigger("continue");
        yield return new WaitForSeconds(1f);
        pauseButton.SetActive(true);
        upMovementBtn.SetActive(true);
        downMovementBtn.SetActive(true);
        pausePanel.SetActive(false);
    }
}
