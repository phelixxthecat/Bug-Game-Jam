using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int health;
    public int Maxhealth;
    public int damageDealt;
    public string type;
    private Rigidbody2D rb;


    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        health = Maxhealth;
    }
    void Update () 
    {
        if(health <= 0)
        {
            Destroy(gameObject);
        }
        else if(health > Maxhealth)
        {
            health = Maxhealth;
        }
        else
        {
            //Health bar UI here
        }
    }
    
}
