using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuButtons : MonoBehaviour
{
    public void Play()
    {
        SceneManager.LoadScene(2);
    }

    public void GoToLevels()
    {
        SceneManager.LoadScene(1);
    }

    public void Quit()
    {
        Application.Quit(); 
    }
}
