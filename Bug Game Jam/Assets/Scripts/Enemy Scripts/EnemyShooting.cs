using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooting : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefab;
    public float bulletSpeed = 1f;
    public float targetTime = 2.0f;
    private float timer;
    private Vector3 directionToPlayer;
    public GameObject player;

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if(timer > targetTime)
        {
            Shoot();
            timer = 0;
        }
    }

    void Shoot()
    {
        directionToPlayer = (player.transform.position - firePoint.position).normalized;
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(directionToPlayer * bulletSpeed, ForceMode2D.Impulse);
    }
}
