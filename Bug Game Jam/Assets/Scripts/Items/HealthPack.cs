using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPack : MonoBehaviour
{
    GameObject player;
    Player playerScript;
    void OnTriggerEnter2D(Collider2D col)
    {
        player = GameObject.Find("Player");
        playerScript = player.GetComponent<Player>();
        playerScript.health += 2;
    }
}
