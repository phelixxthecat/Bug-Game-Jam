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
        Look();
    }

    void Update()
    {
        Timer();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Player" && playerScript.activeSpeed < 10) 
        {
            playerScript.TakeDamage(damageDealt);
            Destroy(gameObject);
        }
        else if(targetTime <= 0.0f || other.tag == "Collidables")
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.collider.tag == "Enemy" || other.collider.tag == "Boss")
        {
            Physics2D.IgnoreCollision(other.collider.GetComponent<Collider2D>(),GetComponent<Collider2D>());        
        }
    }

    private void Timer()
    {
        if (targetTime > 0)
        {
            targetTime -= Time.deltaTime;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Look()
    {
        Vector3 Look = transform.InverseTransformPoint(player.transform.position);

        float Angle = Mathf.Atan2(Look.y, Look.x) * Mathf.Rad2Deg - 90;

        transform.Rotate(0,0,Angle);
    }

}
