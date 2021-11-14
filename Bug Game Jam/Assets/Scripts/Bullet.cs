using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    private void OnCollisionEnter2D(Collision2D other)
    {
        Debug.Log("hit");
        if((other.collider.tag == "Collidables") || (other.collider.tag == "Enemy"))
        {
            Destroy(gameObject);
        }
    }
}
