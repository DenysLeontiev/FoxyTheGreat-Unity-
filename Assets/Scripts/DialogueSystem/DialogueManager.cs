using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class DialogueManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI textMesh;
    [SerializeField] private TextMeshProUGUI nameText;
    [SerializeField] private GameObject box;
    [TextArea]
    [SerializeField] private string[] sentences;
    [SerializeField] private string[] names;
    [SerializeField] private float charSpeed = 0.002f;

    public static bool displayDialogue = false;

    private int index = 0;
    private bool canClick = true;

    void Start()
    {
        box.SetActive(false);
    }

    void Update()
    {
        if (displayDialogue)
        {
            box.SetActive(displayDialogue);
            index = Mathf.Clamp(index, 0, sentences.Length - 1);
            if (Input.touchCount > 0)
            {
                Touch touch = Input.GetTouch(0);
                if (touch.phase == TouchPhase.Began && canClick)
                {
                    canClick = false;
                    StartCoroutine(StartLine());
                }
            }
        }
    }

    public static bool hasDisplayedLastLine = false;
    private IEnumerator StartLine()
    {
        textMesh.text = string.Empty;

        if (index == sentences.Length - 1)
        {
            nameText.text = names[1];
        }
        else
        {
            nameText.text = names[0];
        }

        if (index <= sentences.Length - 1 && hasDisplayedLastLine == false)
        {
            foreach (char c in sentences[index].ToCharArray())
            {
                textMesh.text += c;
                yield return new WaitForSeconds(charSpeed);
            }
            index++;
        }

        if (index > sentences.Length - 1)
        {
            hasDisplayedLastLine = true;
            yield return new WaitForSeconds(3f);
            box.GetComponent<Animator>().SetTrigger("disappear");
        }

        canClick = true;
    }
}

