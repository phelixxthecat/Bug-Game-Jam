using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPointerFollow : MonoBehaviour
{
    public GameObject player;
    public GameObject enemyAttached;
    private Vector2 directionToPlayer;
    private Transform playerTransform;


    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        playerTransform = player.transform;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 relativePos = playerTransform.position - transform.position;
        transform.LookAt(player.transform,Vector3.back);
        //transform.RotateAround(enemyAttached.transform.position, Vector3.forward, 20 * Time.deltaTime);
    }

    void SpawnPointer()
    {
        
    }
}
