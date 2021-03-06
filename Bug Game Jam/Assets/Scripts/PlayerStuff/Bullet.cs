using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float targetTime = 1.0f;

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
        if(other.collider.tag == "Collidables")
        {
            if(gameObject.name != "Bouncy")
            {
                Destroy(gameObject);
            }
        }
    }
    
}
