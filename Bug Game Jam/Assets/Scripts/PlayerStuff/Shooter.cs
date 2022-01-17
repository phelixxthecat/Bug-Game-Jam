using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    public Transform firePoint;
    public float bulletSpeed = 20f;
    private int index;
    private bool basic = true;
    private bool shotgun = false;
    private bool sniper = false;
    private double NextShot = 0;
    public GameObject[] bulletType = new GameObject[5];

    // Update is called once per frame
    private void Update()
    {
        Change();
        
        if(Input.GetKeyDown(KeyCode.Space) && Time.time > NextShot)
        {
            Swap();
            Shoot();
        }
    }

    private void Shoot()
    {
        if(basic == true)
        {
            GameObject bullet = Instantiate(bulletType[index], firePoint.position, firePoint.rotation);
            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
            rb.AddForce(firePoint.right * bulletSpeed, ForceMode2D.Impulse);
            NextShot = Time.time + .25; 
        }

        else if(shotgun == true)
        {
            GameObject bullet = Instantiate(bulletType[index], firePoint.position, firePoint.rotation);
            GameObject bullet2 = Instantiate(bulletType[index], firePoint.position, firePoint.rotation);
            GameObject bullet3 = Instantiate(bulletType[index], firePoint.position, firePoint.rotation);
            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
            Rigidbody2D rb2 = bullet2.GetComponent<Rigidbody2D>();
            Rigidbody2D rb3 = bullet3.GetComponent<Rigidbody2D>();
            rb.AddForce(new Vector3(firePoint.right.x - Random.Range(0, .5f), firePoint.right.y + Random.Range(0, .5f), firePoint.right.z) * bulletSpeed * .5f, ForceMode2D.Impulse);
            rb2.AddForce(firePoint.right * bulletSpeed, ForceMode2D.Impulse);
            rb3.AddForce(new Vector3(firePoint.right.x + Random.Range(0, .5f), firePoint.right.y - Random.Range(0, .5f), firePoint.right.z) * bulletSpeed * .5f, ForceMode2D.Impulse);
            NextShot = Time.time + .5; 
        }

        else if(sniper == true)
        {
            GameObject bullet = Instantiate(bulletType[index], firePoint.position, firePoint.rotation);
            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
            rb.AddForce(firePoint.right * bulletSpeed * 2, ForceMode2D.Impulse);
            NextShot = Time.time + 1; 
        }
    }

    private void Change()
    {
        if(Input.GetKeyDown(KeyCode.Q))
        {
            if(basic == true)
            {
                False();
                shotgun = true;
            }

            else if(shotgun == true)
            {
                False();
                sniper = true;
            }

            else if(sniper == true)
            {
                False();
                basic = true;
            }
        }
        else if(Input.GetKeyDown(KeyCode.E))
        {
            if(basic == true)
            {
                False();
                sniper = true;
            }

            else if(sniper == true)
            {
                False();
                shotgun = true;
            }

            else if(shotgun == true)
            {
                False();
                basic = true;
            }
        }
    }

    private void Swap()
    {
        if(basic == true)
        {
            index = 0;
        }

        else if(shotgun == true)
        {
            index = 1;  
        }

        else if(sniper == true)
        {
            index = 2;
        }
    }

    private void False()
    {
        basic = false;
        shotgun = false;
        sniper = false;
    }
}
