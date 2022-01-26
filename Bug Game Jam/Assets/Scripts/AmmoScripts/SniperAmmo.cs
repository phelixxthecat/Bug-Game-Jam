using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SniperAmmo : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D col)
    {
        Shooter shooterScript = col.GetComponent<Shooter>();
        shooterScript.sniper = true; 
    }
}
