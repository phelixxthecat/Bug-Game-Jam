using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    public Transform firePoint;
    public float bulletSpeed = 20f;
    private int bulletCount;
    private int index;
    private bool basic = true;
    private bool shotgun = false;
    private bool sniper = false;
    private bool fullAuto = false;
    private bool bouncy = false;
    private double NextShot = 0;
    public GameObject[] bulletType = new GameObject[5];
    public GameObject currentBullet = null;

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
        if(basic && currentBullet == bulletType[0]) 
        {
            BulletSpawning(.25f, bulletSpeed);
        }

        else if(shotgun && currentBullet == bulletType[1])
        { 
            for(int i = 0; i < 4; i++)
            {
                GameObject bullet = Instantiate(bulletType[index], firePoint.position, firePoint.rotation);
                Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
                rb.AddForce(new Vector3(firePoint.right.x + Random.Range(-.5f, .5f), firePoint.right.y + Random.Range(-.5f, .5f), firePoint.right.z) * bulletSpeed * .5f, ForceMode2D.Impulse);
            }
            NextShot = Time.time + .5; 
        }

        else if(sniper && currentBullet == bulletType[2])
        {
            BulletSpawning(1.5f, bulletSpeed * 2);
        }
        
        else if(fullAuto && currentBullet == bulletType[3])
        {
            while(Input.GetKeyDown(KeyCode.Space) && bulletCount > 0)
            {
                BulletSpawning(.1f, bulletSpeed);
            }
            
        }
        else if(bouncy && currentBullet == bulletType[4])
        {
            BulletSpawning(.1f, bulletSpeed); 
        }
    }

    private void Change()
    {
        if(Input.GetKeyDown(KeyCode.Alpha1) && basic){
            Equip(0);
        }
        else if(Input.GetKeyDown(KeyCode.Alpha2) && shotgun){
            Equip(1);
        }
        else if(Input.GetKeyDown(KeyCode.Alpha3) && sniper){
            Equip(2);
        }
        else if(Input.GetKeyDown(KeyCode.Alpha3) && fullAuto){
            Equip(3);
        }
        else if(Input.GetKeyDown(KeyCode.Alpha3) && bouncy){
            Equip(4);
        }
    }

    private void BulletSpawning(float bulletTime, float bulletSpeed)
    {
        GameObject bullet = Instantiate(bulletType[index], firePoint.position, firePoint.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(firePoint.right * bulletSpeed, ForceMode2D.Impulse);
        NextShot = Time.time + bulletTime; 
    }

    private void Equip(int bullet)
    {
        currentBullet = bulletType[bullet];
    }


}
