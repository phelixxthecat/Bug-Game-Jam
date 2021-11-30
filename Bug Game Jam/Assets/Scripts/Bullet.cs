using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float targetTime = 1.0f;
    public int damage = 1;

    void Update()
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
    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.collider.tag == "Collidables" || other.collider.tag == "Bullet")
        {
            Destroy(gameObject);
        }
        else if(other.collider.tag == "Enemy")
        {
            Destroy(gameObject);
        }
    }
    
}
