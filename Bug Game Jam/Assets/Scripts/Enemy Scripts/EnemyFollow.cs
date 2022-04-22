using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFollow : MonoBehaviour
{
    public GameObject player;
    private Rigidbody2D enemyRb;
    public float speed;
    public bool teleporter = false;
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
        directionToPlayer = (player.transform.position - transform.position).normalized;
        enemyRb.velocity = new Vector2(directionToPlayer.x, directionToPlayer.y) * speed;
    }
}
