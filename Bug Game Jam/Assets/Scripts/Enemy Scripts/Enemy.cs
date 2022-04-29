using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int health;
    public int Maxhealth;
    public int damageDealt;
    private Rigidbody2D rb = null;
    public GameObject player;
    public GameObject lootDrop = null;
    public Player playerScript;
    public GameObject GM;
    public GameManager GMscript;
    public bool inTrigger;

    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>(); 
        player = GameObject.Find("Player");
        playerScript = player.GetComponent<Player>();
        health = Maxhealth;
        GM = GameObject.Find("Game Manager");
        GMscript = GM.GetComponent<GameManager>();
    }
    void Update () 
    {
        if(health <= 0)
        {
            if(lootDrop != null)
            {
                Instantiate(lootDrop, transform.position, Quaternion.identity);
            }         
            inTrigger = false;
            if(gameObject.tag == "Boss")
            {
                playerScript.health = 10;
                ++GMscript.bossesDefeated;
            }
            Destroy(gameObject);
        }
        else if(health > Maxhealth)
        {
            health = Maxhealth;
        }

    }
    
    void OnCollisionEnter2D(Collision2D other)
    {

        if(other.collider.tag == "Basic") 
        {
            health--;
            Destroy(other.gameObject);
        }
        else if(other.gameObject.tag == "Sniper")
        {
            health -= 5;
            Destroy(other.gameObject);
        }
        
        else if(other.gameObject.tag == "Shotgun")
        {
            health -= 2;
            Destroy(other.gameObject);
        }
        
        else if(other.gameObject.tag == "ExplosionRadius")
        {
            health -= 3;
        }

        else if(other.collider.tag == "Player" )
        {
            playerScript.TakeDamage(damageDealt);
            if(gameObject.tag != "Boss")
            {
                Destroy(gameObject);
            }   
        }  
        
    }
}

