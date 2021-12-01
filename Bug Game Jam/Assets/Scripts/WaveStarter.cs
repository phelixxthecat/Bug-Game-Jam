using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveStarter : MonoBehaviour
{   
    public int enemiesMax;
    public int enemiesAlive = 0;
    public int waveWaitTime;
    private int RandomSpawnPos;
    private int enemyPrefabNum;
    public Transform[] SpawnPoints;
    public GameObject[] enemyPrefabs;
    public GameObject doorOne;
    public Enemy enemy;
    
    
    private void Start()
    {

    }

    public void Spawning()
    {   
        if(enemiesMax > 0)
        {
            RandomSpawnPos = Random.Range(0,SpawnPoints.Length);
            enemyPrefabNum = Random.Range(0, enemyPrefabs.Length);
            Instantiate(enemyPrefabs[enemyPrefabNum], SpawnPoints[RandomSpawnPos].transform.position, Quaternion.identity); 
            enemiesMax--;
            enemiesAlive++;
        } 
        if(enemiesAlive <= 0 && enemiesMax <= 0)
        {
            Destroy(doorOne);
        }
        else
        {
            return;
        }
  
    }
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.name == "Player")
        {
            Debug.Log("Player starting battle");
            InvokeRepeating("Spawning", 0f,3.0f);
        }
        else if(collider.tag == "Enemy" || collider.tag == "Boss")
        {
            enemy = collider.GetComponent<Enemy>();
            enemy.inTrigger = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collider)
    {
        if(collider.tag == "Enemy")
        {
            --enemiesAlive;
        }
        else if(collider.tag == "Boss")
        {
            --enemiesAlive;
        }
    }

    private void OnTriggerStay2D(Collider2D collider)
    {
        if(collider.tag == "Enemy" || collider.tag == "Boss")
        {
            enemy = collider.GetComponent<Enemy>();
            enemy.inTrigger = true;
        }
    }
    
}
