using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraCutScene1 : MonoBehaviour
{
    [SerializeField] private GameObject mainPlayerCamera;
    [SerializeField] private GameObject playerCutSceneCamera;

    public static bool activateCutsceneCam = false;
    private bool hasAlreadyPlayed = false;


    void Update()
    {
        if(activateCutsceneCam && !hasAlreadyPlayed)
        {
            StartCoroutine(StartCutscene());
        }
    }

    private IEnumerator StartCutscene()
    {
        hasAlreadyPlayed = true;
        mainPlayerCamera.SetActive(false);
        playerCutSceneCamera.SetActive(true);
        yield return new WaitForSeconds(2f);
        playerCutSceneCamera.SetActive(false);
        mainPlayerCamera.SetActive(true);
    }
    
}
