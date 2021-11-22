using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefab;
    public float bulletSpeed = 20f;
    public bool Basic = true;
    public bool Bouncy = false;
    public bool Piercing = false;
    public bool Shotgun = false;
    public bool Sniper = false;

    public GameObject[] bulletType = new GameObject[5];

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(firePoint.right * bulletSpeed, ForceMode2D.Impulse);
    }

    void Swap()
    {
          if(Basic == true)
            {
                bulletPrefab = bulletType[0];
            }
            else if(Bouncy == true)
            {
                bulletPrefab = bulletType[1];    
            }
            else if(Piercing == true)
            {
                bulletPrefab = bulletType[2];
            }
            else if(Shotgun == true)
            {
                bulletPrefab = bulletType[3];  
            }
            else if(Sniper == true)
            {
                bulletPrefab = bulletType[4];
            }
    }
}
