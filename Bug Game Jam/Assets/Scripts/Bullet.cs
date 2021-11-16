using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float targetTime = 2.0f;
    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.collider.tag == "Collidables" || other.collider.tag == "Bullet" || targetTime <= 0.0f)
        {
            Destroy(gameObject);
        }
        else if(other.collider.tag == "Enemy")
        {
            Destroy(gameObject);
        }
    }
}
