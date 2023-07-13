using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooting : MonoBehaviour
{
    public GameObject bulletPrefab;
    public float bulletSpeed = 1f;
    public float targetTime = 2.0f;
    public float fireRate;
    public float nextFire;
    private Vector3 directionToPlayer;
    public GameObject player;
    
    void Start()
    {
        player = GameObject.Find("Player");
        nextFire = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        Shoot();
    }

    void Shoot()
    {
        if(Time.time > nextFire)
        {
            Instantiate(bulletPrefab, transform.position, Quaternion.identity);
            nextFire = Time.time + fireRate;
        }
    }
}
