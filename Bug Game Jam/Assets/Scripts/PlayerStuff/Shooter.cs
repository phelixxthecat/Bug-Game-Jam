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
            for(int i = 0; i < 4; i++)
            {
                GameObject bullet = Instantiate(bulletType[index], firePoint.position, firePoint.rotation);
                Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
                rb.AddForce(new Vector3(firePoint.right.x + Random.Range(-.5f, .5f), firePoint.right.y + Random.Range(-.5f, .5f), firePoint.right.z) * bulletSpeed * .5f, ForceMode2D.Impulse);
            }
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
        if(Input.GetKey(keyCode))
        {
            switch(KeyCode)
            {

            }
        }
        
    }


}
