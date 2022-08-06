using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    public GameObject explosionRadius;
    public float timeRemaining = 3;
    public bool explode = false;

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
            Instantiate(explosionRadius, gameObject.transform);
            gameObject.GetComponent<SpriteRenderer>().sortingOrder--;
            Destroy(GetComponent<Collider2D>());
            explode = true;
        }
    }
}
