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
    private Vector3 roomSize;
    public GameObject[] enemyPrefabs;
    public GameObject[] doors;
    public GameObject room;
    private Enemy enemy;
    private BoxCollider2D collider;
    private float xMin;
    private float xMax;
    private float yMin;
    private float yMax;

    
    
    private void Start()
    {
        room = this.gameObject;
        roomDimensions(room, out yMax, out yMin, out xMax, out xMin);
    }

    public void Spawning()
    {   
        if(enemiesMax > 0)
        {
            float RandomSpawnPosX = Random.Range(xMin,xMax);
            float RandomSpawnPosY = Random.Range(yMin,yMax);
            enemyPrefabNum = Random.Range(0, enemyPrefabs.Length);
            Instantiate(enemyPrefabs[enemyPrefabNum], new Vector2(RandomSpawnPosX, RandomSpawnPosY), Quaternion.identity); 
            doors[0].SetActive(true);
            doors[1].SetActive(true);
            enemiesMax--;
            enemiesAlive++;
        }
        else if(enemiesAlive <= 0 && enemiesMax <= 0)
        {
            Destroy(doors[0]);
            Destroy(doors[1]);
        }
        else
        {
            return;
        }
  
    }

    public void roomDimensions(GameObject room, out float topLen, out float botLen, out float rightLen, out float leftLen)
    {
        collider = room.GetComponent<BoxCollider2D>();
        roomSize = collider.size;
        Vector2 worldPos = room.transform.TransformPoint(collider.offset);

        topLen = worldPos.y + (roomSize.y / 2);
        botLen = worldPos.y - (roomSize.y / 2);
        rightLen = worldPos.x + (roomSize.x / 2);
        leftLen = worldPos.x - (roomSize.x / 2);
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.name == "Player")
        {
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

}
