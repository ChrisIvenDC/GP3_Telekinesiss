using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject objectPrefab; 
    public float spawnInterval = 2f; 
    public float spawnRadius = 5f; 

    private float timer;

    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= spawnInterval)
        {
            timer = 0f;

            SpawnObject();
        }
    }

    void SpawnObject()
    {

        Vector3 spawnPosition = transform.position + Random.insideUnitSphere * spawnRadius;
        spawnPosition.y = 0f; 

        GameObject spawnedObject = Instantiate(objectPrefab, spawnPosition, Quaternion.identity);
    }
}
