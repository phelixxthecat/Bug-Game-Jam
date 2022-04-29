using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    public GameObject explosionRadius;
    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.tag == "Enemy" || col.tag == "Boss")
        {
            Instantiate(explosionRadius, gameObject.transform);
        }
    }
}
