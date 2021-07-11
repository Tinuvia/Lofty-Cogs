using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    private float spawnDelay = 2;
    private float spawnInterval = 1.5f;
    public string objectTag;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnObjects", spawnDelay, spawnInterval);
    }

    // Spawn obstacles
    void SpawnObjects()
    {
        // Set random spawn location and random object index
        Vector3 spawnLocation = new Vector3(30, Random.Range(5, 15), 0);

        // If game is still active, spawn new object
        if (!GameManager.instance.isGameOver)
        {
            // Get an object object from the pool
            GameObject pooledProjectile = ObjectPooler.Instance.SpawnFromPool(objectTag, spawnLocation, Quaternion.identity);
        }
    }
}
