using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float targetTime = 1.0f;

    void Start()
    {

        Vector3 Look = Input.mousePosition - transform.position;

        float Angle = Mathf.Atan2(Look.y, Look.x) * Mathf.Rad2Deg - 90;

        transform.Rotate(0,0,Angle);
    }

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
        if(other.collider.tag == "Collidables" && gameObject.tag != "Bouncy")
        {
            if(gameObject.name != "Bouncy")
            {
                Destroy(gameObject);
            }
        }
    }
    
}
