using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyIndicator : MonoBehaviour
{
    public GameObject indicator;
    private GameObject player;
    private Renderer rd;

    // Start is called before the first frame update
    void Start()
    {
        rd = GetComponent<Renderer>();
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(rd.isVisible);
        if(rd.isVisible == false)
        {
            if(indicator.activeSelf == false)
            {
                Debug.Log("Indicator set to true");
                indicator.SetActive(true);
            }

            Vector2 direction = player.transform.position;
            Debug.Log(direction);
            RaycastHit2D ray = Physics2D.Raycast(transform.position, direction, 10f, 7);

            if(ray.collider != null)
            {
                indicator.transform.position = ray.point;
                Debug.Log(indicator.transform.position);
            }
        }
        else
        {
            if(indicator.activeSelf == true)
            {
                Debug.Log("indicator set false");
                indicator.SetActive(false);
            }
        }
    }
}
