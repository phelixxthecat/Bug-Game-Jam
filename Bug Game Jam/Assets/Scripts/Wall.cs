using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void OnCollisionEnter2D(Collision2D col)
    {
        Debug.Log("hit");
        if(col.gameObject.tag == "Basic" || col.gameObject.tag == "EnemyBullet" ||col.gameObject.tag == "Full Auto" ||col.gameObject.tag == "Sniper" ||col.gameObject.tag == "Shotgun")
        {
            Destroy(col.gameObject);
            Debug.Log("Fuck u i guess");
        }
    }
}
