using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPointerFollow : MonoBehaviour
{
    public GameObject player;
    public GameObject enemyAttached;
    private Vector2 directionToPlayer;
    private Transform playerTransform;


    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        playerTransform = player.transform;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 relativePos = playerTransform.position - transform.position;
        Look();
        //transform.RotateAround(enemyAttached.transform.position, Vector3.forward, 20 * Time.deltaTime);
    }

    private void Look()
    {
        Vector3 Look = transform.InverseTransformPoint(player.transform.position);

        float Angle = Mathf.Atan2(Look.y, Look.x) * Mathf.Rad2Deg - 90;

        transform.Rotate(0, 0, Angle);
    }
}
