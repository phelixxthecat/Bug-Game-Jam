using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotgunAmmo : MonoBehaviour
{
    // Update is called once per frame
    void OnTriggerEnter2D(Collider2D col)
    {
        Shooter shooterScript = col.GetComponent<Shooter>();
        shooterScript.shotgun = true;
    }
}
