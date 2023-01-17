using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PigMove : MonoBehaviour
{
    [SerializeField] Transform targetHoney;
    [SerializeField] Transform pigRunAwayPoint;
    [SerializeField] float speed = 0.02f;

    private bool hasStolenHoney = false;

    public static bool playCutScene = false;
    void Start()
    {

    }

    void Update()
    {
        if (playCutScene)
        {
            PlayCutScene();
        }
    }

    private void PlayCutScene()
    {
        if (hasStolenHoney == false)
        {
            Vector2 moveDestination = new Vector2(targetHoney.position.x, transform.position.y);
            transform.position = Vector2.MoveTowards(transform.position, moveDestination, speed);
        }

        float distanceBentween = Vector2.Distance(transform.position, targetHoney.position);
        if (distanceBentween <= 1f && hasStolenHoney == false)
        {
            // Destroy(targetHoney.gameObject);
            targetHoney.transform.gameObject.SetActive(false);
            transform.localScale = new Vector2(-1, 1);
            hasStolenHoney = true;
        }

        if (hasStolenHoney)
        {
            Vector2 runPoint = new Vector2(pigRunAwayPoint.position.x, transform.position.y);
            transform.position = Vector2.MoveTowards(transform.position, runPoint, speed);
            Destroy(gameObject, 3f);
            BearMove.activateBear = true;
        }
    }
}
