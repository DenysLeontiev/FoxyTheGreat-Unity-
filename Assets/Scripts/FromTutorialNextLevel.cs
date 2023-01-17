using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FromTutorialNextLevel : MonoBehaviour
{
    [SerializeField] GameObject fadeInBlackScreen;
    public void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            StartCoroutine(LoadNextLvl(other));
        }
    }

    private IEnumerator LoadNextLvl(Collider2D collider)
    {
        fadeInBlackScreen.SetActive(true);
        collider.GetComponent<PlayerController>().enabled = false;
        yield return new WaitForSeconds(1.5f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
