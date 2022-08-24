using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    public GameObject explosionRadius;
    public float timeRemaining = 3;
    private Rigidbody2D rb;
    public bool explode = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        Timer();
    }

        
    void Timer()
    {
        if (timeRemaining > 0)
        {
            timeRemaining -= Time.deltaTime;
        }
        else if(!explode)
        {
            rb.velocity = new Vector2(0,0);
            Instantiate(explosionRadius, gameObject.transform);
            gameObject.GetComponent<SpriteRenderer>().sortingOrder--;
            Destroy(GetComponent<Collider2D>());
            explode = true;
        }
    }

}
