using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFollow : MonoBehaviour
{
    public GameObject player;
    private Rigidbody2D enemyRb;
    public float speed;
    public float targetTime = 2;
    public bool ableToDash = false;
    public float dashSpeed;
    public bool dash;
    private float dashTime = 1;
    private Vector3 directionToPlayer;

    // Start is called before the first frame update
    void Start()
    {
        enemyRb = GetComponent<Rigidbody2D>();
        player = GameObject.Find("Player");
        dashSpeed = speed;
    }

    // Update is called once per frame
    void Update()
    {
        if(ableToDash)
        {
            DashCheck();
        }
        directionToPlayer = (player.transform.position - transform.position).normalized;
        enemyRb.velocity = new Vector2(directionToPlayer.x, directionToPlayer.y) * dashSpeed;
    }

    private void DashCheck()
    {
        if (targetTime > 0)
        {
            targetTime -= Time.deltaTime;
            dashSpeed = speed;
        }
        else if(targetTime <= 0 && dashTime > 0)
        {
            dashTime -= Time.deltaTime;
            dashSpeed = speed * 2;
        }
        else
        {
            targetTime = 2;
        }
        
    }
}
