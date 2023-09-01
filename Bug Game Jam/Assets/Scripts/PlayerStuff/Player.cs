using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Start is called before the first frame update
    public Rigidbody2D playerRb;
    public GameObject player;
    public GameObject OptionsMenu;
    public GameObject DashGUI;
    public Transform firePoint;
    Vector2 movement;
    public HealthBar healthBar;
    private Collision2D other;
    public float targetTime = 3.0f;
    public float speed = 5;
    public float activeSpeed;
    public float dashSpeed = 10;
    public bool dash = false;
    public int health;
    public int maxHealth;
    public float dashCount = 0;

    void Start()
    {
        playerRb = GetComponent<Rigidbody2D>();
        activeSpeed = speed;
        healthBar.SetMaxHealth(maxHealth);
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

        if (targetTime > 0)
        {
            targetTime -= Time.deltaTime;
        }
        else if(!dash && targetTime <= 0)
        {
            dash = true;
            DashGUI.SetActive(true);
        }
    }

    void FixedUpdate()
    {
        if(dash && Input.GetKeyDown(KeyCode.F))
        {
            activeSpeed = dashSpeed;
            targetTime = 2.0f;
            
            dash = false;
            DashGUI.SetActive(false);
        }
        else if (dash == false && targetTime < 1.5f)
        {
            activeSpeed = speed;
            Physics2D.IgnoreCollision(other.collider.GetComponent<Collider2D>(),GetComponent<Collider2D>(), false);
        }
        else if(Input.GetKeyDown(KeyCode.Escape))
        {
            OptionsMenu.SetActive(true);
        }
        
        playerRb.velocity = new Vector2(movement.x * activeSpeed, movement.y * activeSpeed);

    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        healthBar.SetHealth(health);
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        other = col;
        if(activeSpeed == 10 && (col.collider.tag == "Enemy" || col.collider.tag == "Boss" || col.collider.tag == "EnemyBullet"))
        {
            Physics2D.IgnoreCollision(col.collider.GetComponent<Collider2D>(),GetComponent<Collider2D>());
        }
    }

    void OnCollisionStay2D(Collision2D col)
    {
        if(activeSpeed == 10 && (col.collider.tag == "Enemy" || col.collider.tag == "Boss" || col.collider.tag == "EnemyBullet"))
        {
            Physics2D.IgnoreCollision(col.collider.GetComponent<Collider2D>(),GetComponent<Collider2D>());
        }
    }
}
