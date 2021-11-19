using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    public float targetTime = 2.0f;
    public int damageDealt;
    public GameObject player;
    public Player playerScript;

    void Start()
    {        
        player = GameObject.Find("Player");
        playerScript = player.GetComponent<Player>();
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.collider.tag == "Player") 
        {
            playerScript.health -= damageDealt;
            Destroy(gameObject);
        }
        else if(targetTime <= 0.0f || other.collider.tag == "Collidables")
        {
            Destroy(gameObject);
        }
    }
}
