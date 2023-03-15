using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    // enemy object prefab for collision
    public GameObject enemyPrefab;
    // powerup prefab for trigger
    public GameObject powerupPrefab;
    // variable for random position
    private float spawnRange = 9f;
    // active enemy object count
    public int enemyCount;
    // number of enemies to come
    public int waveNumber = 1;

    // Start is called before the first frame update
    void Start()
    {
        // create a clone of powerup preafab in random position
        Instantiate(powerupPrefab, GenerateSpawnPosition(), powerupPrefab.transform.rotation);
        // create enemy prefabs clone
        SpawnEnemyWave(waveNumber);
    }

    // Update is called once per frame
    void Update()
    {
        // get number of enemies in scene
        enemyCount = FindObjectsOfType<Enemy>().Length;
        if (enemyCount == 0)
        {
            // increase number of enemies
            waveNumber++;
            // create new enemies
            SpawnEnemyWave(waveNumber);
            // create new powerup
            Instantiate(powerupPrefab, GenerateSpawnPosition(), powerupPrefab.transform.rotation);
        }

    }

    // generating random position for prefabs
    private Vector3 GenerateSpawnPosition()
    {
        float spawnPosX = Random.Range(-spawnRange, spawnRange);
        float spawnPosZ = Random.Range(-spawnRange, spawnRange);
        Vector3 randomPos = new Vector3(spawnPosX, 0, spawnPosZ);
        return randomPos;
    }

    // creating enemy prefabs 
    void SpawnEnemyWave(int enemiesToSpawn)
    {
        for (int i = 0; i < enemiesToSpawn; i++)
        {
            Instantiate(enemyPrefab, GenerateSpawnPosition(), enemyPrefab.transform.rotation);
        }
    }
}
