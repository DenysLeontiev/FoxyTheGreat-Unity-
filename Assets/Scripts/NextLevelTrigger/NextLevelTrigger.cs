using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevelTrigger : MonoBehaviour
{
    [SerializeField] private GameObject fadeInScreen;
    [SerializeField] private int levelIndex;
    
    void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.tag == "Player")
        {
            StartCoroutine(NextLevel());
        }
    }

    private IEnumerator NextLevel()
    {
        fadeInScreen.SetActive(true);
        yield return new WaitForSeconds(1.3f);
        SceneManager.LoadScene(levelIndex);
    }
}
