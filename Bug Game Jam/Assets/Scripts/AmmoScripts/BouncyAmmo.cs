using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BouncyAmmo : MonoBehaviour
{
    private Rigidbody2D rb = null;
    public GameObject player;
    public Player playerScript;

    void start()
    {
        rb = this.GetComponent<Rigidbody2D>(); 
        player = GameObject.Find("Player");
        playerScript = player.GetComponent<Player>();
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if(col == player)
        {
            Shooter shooterScript = col.GetComponent<Shooter>();
            shooterScript.bouncy = true; 
        }
    }
}

