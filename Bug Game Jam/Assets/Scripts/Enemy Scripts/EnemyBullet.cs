using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    public float targetTime = 2.0f;
    public int damageDealt;
    public float speed;
    private Rigidbody2D rigidBody;
    public GameObject player;
    public Player playerScript;
    private Vector2 moveDirection;

    void Start()
    {        
        player = GameObject.Find("Player");
        playerScript = player.GetComponent<Player>();
        rigidBody = GetComponent<Rigidbody2D>();
        moveDirection = (player.transform.position - transform.position).normalized * speed;
        rigidBody.velocity = new Vector2(moveDirection.x, moveDirection.y);


    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.collider.tag == "Player") 
        {
            playerScript.health -= damageDealt;
            Destroy(gameObject);
        }
        else if(targetTime <= 0.0f || other.collider.tag == "Collidables" || other.collider.tag == "Enemy")
        {
            Destroy(gameObject);
        }
    }
}
