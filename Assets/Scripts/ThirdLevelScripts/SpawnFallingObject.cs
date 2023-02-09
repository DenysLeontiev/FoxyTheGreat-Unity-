using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnFallingObject : MonoBehaviour
{
    [SerializeField] private GameObject rainPanel;

    [SerializeField] private GameObject spawningObject;
    [SerializeField] private float firstPosX;
    [SerializeField] private float SecondPosX;
    [SerializeField] private float spawnTime;
    [SerializeField] private float heavyRainInterval = 10f;
    private float rainInterfal = 0f;
    [SerializeField] private bool isSpike = false;

    [Range(0f, 1f)]
    [SerializeField] private float frequency = 0.7f;

    private float currentSpawnTime = 0f;
    private float startingFrequency = 0f;

    private bool callRain = false;

    private void Start()
    {
        startingFrequency = frequency;
    }

    private void Update()
    {
        SpawnObject();
        if(isSpike && !callRain)
        {
            StartCoroutine(StartHeavyRain());
        }
        print(callRain);
    }


    private void SpawnObject()
    {   
        currentSpawnTime+= Time.deltaTime;
        if(currentSpawnTime >= spawnTime * frequency)
        {
            currentSpawnTime= 0f;
            Instantiate(spawningObject, new Vector2(Random.Range(firstPosX, SecondPosX), transform.position.y), Quaternion.identity);
        }
    }

    private IEnumerator StartHeavyRain()
    {
        callRain= true;
        int range = Random.Range(1, 100);
        if (range < 26)
        {
            frequency = 0.008f;
            rainPanel.GetComponent<Animator>().SetBool("appear", true);
        }
        yield return new WaitForSeconds(5f);
        frequency = startingFrequency;
        callRain= false;
        rainPanel.GetComponent<Animator>().SetBool("appear", false);
    }
}
