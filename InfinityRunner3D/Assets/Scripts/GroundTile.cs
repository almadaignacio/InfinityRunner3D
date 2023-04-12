using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundTile : MonoBehaviour
{
    GroundSpawner groundSpawner;

    // Start is called before the first frame update
    private void Start()
    {
        groundSpawner = GameObject.FindObjectOfType<GroundSpawner>();
        SpawnObstacle();
        SpawnCoins();
    }

    private void OnTriggerExit(Collider other)
    {
        groundSpawner.SpawnTile();
        Destroy(gameObject, 2);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public GameObject ObstaclePrefab;

    void SpawnObstacle()
    {
        int obstacleSpawnIndex = Random.Range(2, 5);
        Transform spawnPoint = transform.GetChild(obstacleSpawnIndex).transform;

        Instantiate(ObstaclePrefab, spawnPoint.position, Quaternion.identity);
    }

    public GameObject coinPrefab;

    void SpawnCoins()
    {
        int coinsToSpawn = Random.Range(2, 5);
        Transform spawnCoinPoint = transform.GetChild(coinsToSpawn).transform;

        Instantiate(coinPrefab, spawnCoinPoint.position, Quaternion.identity);

        /*
        for (int i = 0; i < coinsToSpawn; i++)
        {
            Instantiate(coinPrefab)
        }
        */
    }

    
}
