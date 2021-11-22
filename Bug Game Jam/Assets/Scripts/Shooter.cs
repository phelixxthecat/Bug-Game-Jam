using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    public Transform firePoint;
    public float bulletSpeed = 20f;
    private int index;
    private bool basic = true;
    private bool bouncy = false;
    private bool piercing = false;
    private bool shotgun = false;
    private bool sniper = false;

    public GameObject[] bulletType = new GameObject[5];

    // Update is called once per frame
    private void Update()
    {
        Change();
        
        if(Input.GetKeyDown(KeyCode.Space))
        {
            Swap();
            Shoot();
        }
    }

    private void Shoot()
    {
        GameObject bullet = Instantiate(bulletType[index], firePoint.position, firePoint.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(firePoint.right * bulletSpeed, ForceMode2D.Impulse);
    }

    private void Change()
    {
        if(Input.GetKeyDown(KeyCode.Q))
        {
            if(basic == true)
            {
                False();
                sniper = true;
            }

            else if(bouncy == true)
            {
                False();
                basic = true;
            }

            else if(piercing == true)
            {
                False();
                bouncy = true;
            }

            else if(shotgun == true)
            {
                False();
                piercing = true;
            }
            
            else if(sniper == true)
            {
                False();
                shotgun = true;
            }
        }

        else if(Input.GetKeyDown(KeyCode.E))
        {
            if(basic == true)
            {
                False();
                bouncy = true;
            }

            else if(bouncy == true)
            {
                False();
                piercing = true;
            }

            else if(piercing == true)
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
    }

    private void Swap()
    {
        if(basic == true)
        {
            index = 0;
        }

        else if(bouncy == true)
        {
            index = 1;  
        }

        else if(piercing == true)
        {
            index = 2;
        }

        else if(shotgun == true)
        {
            index = 3; 
        }

        else if(sniper == true)
        {
            index = 4;
        }
    }

    private void False()
    {
        basic = false;
        bouncy = false;
        piercing = false;
        shotgun = false;
        sniper = false;
    }
}
