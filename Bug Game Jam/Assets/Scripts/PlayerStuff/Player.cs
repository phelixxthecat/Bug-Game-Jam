using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Start is called before the first frame update
    public Rigidbody2D playerRb;
    Vector2 movement;
    public Shooter shooterScript;
    public float speed;
    public int health;
    public int Maxhealth;
    public string ammoType = "Basic";
    


    void Start()
    {
        playerRb = GetComponent<Rigidbody2D>();
    }
    

    // Update is called once per frame
    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical"); 
    }

    void FixedUpdate()
    {
        playerRb.velocity = new Vector2(movement.x * speed, movement.y * speed);
    }
}