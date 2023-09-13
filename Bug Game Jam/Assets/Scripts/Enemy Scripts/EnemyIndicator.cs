using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyIndicator : MonoBehaviour
{
    public GameObject indicator;
    private LookAtEnemy indicatorLook;
    private GameObject player;
    private Renderer rd;

    // Start is called before the first frame update
    void Start()
    {
        rd = GetComponent<Renderer>();
        player = GameObject.Find("Player");
        indicatorLook = indicator.GetComponent<LookAtEnemy>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(rd.isVisible == false)
        {
            if(indicator.activeSelf == false)
            {
                indicator.SetActive(true);
            }

            Vector2 direction = player.transform.position;

            RaycastHit2D ray = Physics2D.Raycast(direction, transform.position);

            if(ray.collider != null)
            {
                indicator.transform.parent = player.transform;
                indicator.transform.position = ray.point;
            }
        }
        else
        {
            if(indicator.activeSelf == true)
            {
                indicator.SetActive(false);
            }
        }
    }

}
