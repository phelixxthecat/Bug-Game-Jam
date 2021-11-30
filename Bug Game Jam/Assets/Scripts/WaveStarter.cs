using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveStarter : MonoBehaviour
{   
    public int enemiesMax; 
    public int waveWaitTime;
    private int RandomSpawnPos;
    private int enemyPrefabNum;
    public Transform[] SpawnPoints;
    public GameObject[] enemyPrefabs;
    

    public void Spawning()
    {   
        Debug.Log("Starts Battle");
        RandomSpawnPos = Random.Range(0,SpawnPoints.Length);
        enemyPrefabNum = Random.Range(0, enemyPrefabs.Length);
        if(enemiesMax > 0)
        {
            Instantiate(enemyPrefabs[enemyPrefabNum], SpawnPoints[RandomSpawnPos].transform.position, Quaternion.identity); 
        }  
        --enemiesMax;
    }
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.name == "Player")
        {
            Debug.Log("Player starting battle");
            InvokeRepeating("Spawning", 0f,3.0f);
        }
    }
}
