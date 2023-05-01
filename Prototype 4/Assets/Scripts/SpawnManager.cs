using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] enemyPrefabs;
    public GameObject powerupPrefab;
    private float spawnRange = 9;
    public int enemyCount;
    public int waveNumber;
    // Start is called before the first frame update
    void Start()
    {
        SpawnEnemyWave(waveNumber);
       
    }

    // Update is called once per frame
    void Update()
    {
        enemyCount = FindObjectsOfType<Enemy>().Length;

        if(enemyCount == 0)
        {
            waveNumber++;
            SpawnEnemyWave(waveNumber);
            Instantiate(powerupPrefab,GernerateSpawnPosition(),powerupPrefab.transform.rotation);
        }  
    }

    void SpawnEnemyWave(int enemiesToSpawn)
    {
        
        for(int i = 0; i < enemiesToSpawn; i++)
        {
            int index = Random.Range(0, enemyPrefabs.Length);
            Instantiate(enemyPrefabs[index], GernerateSpawnPosition(), enemyPrefabs[index].transform.rotation);
        } 
    }

    private Vector3 GernerateSpawnPosition()
    {
        float spawnPosX = Random.Range(-spawnRange, spawnRange);
        float spawnPosZ = Random.Range(-spawnRange, spawnRange);
        Vector3 randomPos = new Vector3(spawnPosX, 0, spawnPosZ);
        return randomPos;
    }
}
