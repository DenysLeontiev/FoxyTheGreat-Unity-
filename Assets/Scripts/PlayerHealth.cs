using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private int startingHealthPoints = 3;
    [SerializeField] private GameObject heartPrefab;
    [SerializeField] private int currentHealthPoints;
    [SerializeField] private float xOffset = 120f;
    [SerializeField] private float yOffset = 1000f;
    [SerializeField] private Transform parent;

    private List<GameObject> hearts;
    private Animator animator;
    private float xOff = 150f;

    public bool testUpdate = false;
    public bool testRemove = false;
    public bool testAdd = false;

    private void Start()
    {
        currentHealthPoints = startingHealthPoints;
        hearts = new List<GameObject>();
        animator = GetComponent<Animator>();
        InstantiateHealthPrefab();
        UpdateHealth();
    }

    private void Update()
    {
        print(currentHealthPoints);
        if (testUpdate == true)
        {
            UpdateHealth();
        }

        if (testRemove)
        {
            RemoveHeart();
            testRemove = false;
        }

        if (testAdd)
        {
            AddHeart();
            testAdd = false;
        }
    }

    private void InstantiateHealthPrefab()
    {
        for (int i = 0; i < startingHealthPoints; i++)
        {
            Vector2 offsetPostion = new Vector2(transform.position.x + xOff, transform.position.y + yOffset);
            var obj = Instantiate(heartPrefab, offsetPostion, Quaternion.identity, parent);
            obj.SetActive(false);
            hearts.Add(obj);
            xOff += xOffset;
        }
    }

    private void UpdateHealth()
    {
        for (int i = 0; i < currentHealthPoints; i++)
        {
            hearts[i].SetActive(true);
        }
    }

    public IEnumerator RemoveHeart()
    {
        animator.SetTrigger("hurt");
        currentHealthPoints--;
        if (currentHealthPoints < 0)
        {
            currentHealthPoints = 0;
        }
        hearts[currentHealthPoints].SetActive(false);
        UpdateHealth();
        yield return new WaitForSeconds(1f);
    }

    public void AddHeart()
    {
        if (currentHealthPoints >= startingHealthPoints)
        {
            Mathf.Clamp(currentHealthPoints, 0, startingHealthPoints - 1);
        }
        try
        {
            hearts[currentHealthPoints].SetActive(true);
        }
        catch (IndexOutOfRangeException error)
        {
            print(error.Message);
        }
        currentHealthPoints++;
        UpdateHealth();
    }
}
