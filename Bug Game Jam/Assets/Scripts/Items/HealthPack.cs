using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPack : MonoBehaviour
{
    GameObject player;
    private HealthBar healthbar;
    GameObject healthBarSlider;
    Player playerScript;
    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.tag == "Player")
        {
            playerScript = col.GetComponent<Player>();
            healthBarSlider = GameObject.Find("Health Bar");
            healthbar = healthBarSlider.GetComponent<HealthBar>();
            playerScript.health += 2;
            healthbar.SetHealth(playerScript.health);
            Destroy(gameObject);
        }   
    }
}
