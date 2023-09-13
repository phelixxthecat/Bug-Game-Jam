using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class LookAtEnemy : MonoBehaviour
{
    public GameObject enemy;
    private GameObject player;

    void Start()
    {
        player = GameObject.Find("Player");
    }
    void FixedUpdate()
    {
        this.Look();
    }

    private void Look()
    {

        Vector3 Look = transform.InverseTransformPoint(enemy.transform.position);
        float Angle = Mathf.Atan2(Look.y, Look.x) * Mathf.Rad2Deg - 90;
        
        transform.Rotate(0, 0, Angle);

        //indicator.transform.LookAt(transform.position, new Vector3(0,0,1));
    }
}
