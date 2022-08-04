using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionDamage : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D col)
    {
        
        if(col.tag == "Enemy")
        {
            col.GetComponent<Enemy>().health--;
            Debug.Log(col.GetComponent<Enemy>().health);
            Debug.Log("Dmg taken E");
        }
        if(col.tag == "Player")
        {
            col.GetComponent<Player>().TakeDamage(1);
            Debug.Log(col.GetComponent<Player>().health);
            Debug.Log("Dmg taken P");
        }
    }
}
