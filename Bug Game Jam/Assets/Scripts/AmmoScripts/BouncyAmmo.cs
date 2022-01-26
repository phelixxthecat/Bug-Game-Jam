using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BouncyAmmo : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D col)
    {
        Shooter shooterScript = col.GetComponent<Shooter>();
        shooterScript.bouncy = true;
    }
}

