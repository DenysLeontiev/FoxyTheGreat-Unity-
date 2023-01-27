using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpawn : MonoBehaviour
{
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private Transform spawnPoint;
    [SerializeField] private float spawnTime = 1f;
    private float currentSpawnTime = 0f;

    private void Update()
    {
        SpawnBullets();
    }

    private void SpawnBullets()
    {
        currentSpawnTime += Time.deltaTime;
        if(currentSpawnTime > spawnTime)
        {
            currentSpawnTime = 0;
            GameObject bullet = Instantiate(bulletPrefab, spawnPoint.position, Quaternion.identity);
        }
    }
}
