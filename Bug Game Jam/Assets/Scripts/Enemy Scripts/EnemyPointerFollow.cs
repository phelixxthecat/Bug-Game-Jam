using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPointerFollow : MonoBehaviour
{
    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        Look();
    }

    private void Look()
    {
        Vector3 Look = transform.InverseTransformPoint(player.transform.position);

        float Angle = Mathf.Atan2(Look.y, Look.x) * Mathf.Rad2Deg - 90;

        transform.Rotate(0, 0, Angle);
    }
}
