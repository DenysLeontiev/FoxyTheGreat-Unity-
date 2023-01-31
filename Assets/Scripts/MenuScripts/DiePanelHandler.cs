using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DiePanelHandler : MonoBehaviour
{
    [SerializeField] private GameObject panel;
    private Animator panelAnimator;

    private void Start()
    {
        panelAnimator = panel.GetComponent<Animator>();
    }

    private void Update()
    {
        
    }

    public void ContinueGame()
    {
        StartCoroutine(GameCoroutine(SceneManager.GetActiveScene().buildIndex));
    }

    public void GoToMenu()
    {
        StartCoroutine(GameCoroutine(1));
    }

    private IEnumerator GameCoroutine(int sceneIndex)
    {
        Time.timeScale = 1f;
        panelAnimator.SetTrigger("disappear");
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(sceneIndex);
        panel.SetActive(false);
    }
}
