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
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Player") 
        {
            playerScript.TakeDamage(damageDealt);
            Destroy(gameObject);
        }
        else if(targetTime <= 0.0f || other.gameObject.tag == "Collidables")
        {
            Destroy(gameObject);
        }
    }
}
