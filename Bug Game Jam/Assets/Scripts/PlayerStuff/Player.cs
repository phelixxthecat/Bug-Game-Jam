using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Start is called before the first frame update
    public Rigidbody2D playerRb;
    public GameObject player;
    public Transform firePoint;
    Vector2 movement;
    public float speed = 5;
    public float activeSpeed;
    public float dashSpeed = 10;
    public bool dash = false;
    public int health;
    public int Maxhealth;
    public float dashCount = 0;
    private float dashDelay = 2;


    void Start()
    {
        playerRb = GetComponent<Rigidbody2D>();
        activeSpeed = speed;

    }
    

    // Update is called once per frame
    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical"); 
        if(health <= 0)
        {
            Destroy(player);
        }
    }

    void FixedUpdate()
    {
        if(dash && Input.GetKeyDown(KeyCode.F))
        {
            activeSpeed = dashSpeed;
            dashCount = dashDelay;
            dash = false;
            Debug.Log("dashing");
        }
        else if(!dash && dashCount > 0)
        {
            Debug.Log("not dashing");
            activeSpeed = speed;
        }

 
        if(dashCount > 0)
        {
            Debug.Log("dashing timer");
            dashCount -= Time.deltaTime;
        }
        playerRb.velocity = new Vector2(movement.x * activeSpeed, movement.y * activeSpeed);
        

    }
}
