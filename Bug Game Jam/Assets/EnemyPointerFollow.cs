using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPointerFollow : MonoBehaviour
{
    public GameObject player;
    public GameObject enemyAttached;
    private Rigidbody2D enemyRb;
    private Vector3 directionToPlayer;


    // Start is called before the first frame update
    void Start()
    {
        enemyRb = GetComponent<Rigidbody2D>();
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        
        transform.RotateAround(enemyAttached.transform.position, Vector3.forward, 20 * Time.deltaTime);
        enemyRb.position = new Vector2(player.transform.position.x, player.transform.position.y);
    }
}
