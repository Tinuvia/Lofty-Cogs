using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    private float spawnDelay = 2;
    private float spawnInterval = 1.5f;


    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnObjects", spawnDelay, spawnInterval);
    }

    // Spawn obstacles
    void SpawnObjects()
    {
        // If game is still active, spawn new object
        if (!GameManager.instance.isGameOver)
        {
            // Set random spawn location and random object index
            Vector3 spawnLocation = new Vector3(30, Random.Range(2, 8), 0);

            // Slump hazard or pickup and spawn object from pool
            int r = Random.Range(0, ObjectPooler.Instance.pools.Count);
            GameObject spawn = ObjectPooler.Instance.SpawnFromPool(ObjectPooler.Instance.pools[r].tag, spawnLocation, Quaternion.identity);
        }
    }
}
