using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtObject : MonoBehaviour
{
    public GameObject objectToLook;

    void FixedUpdate()
    {
        this.Look();
    }

    private void Look()
    {

        Vector3 Look = transform.InverseTransformPoint(objectToLook.transform.position);
        float Angle = Mathf.Atan2(Look.y, Look.x) * Mathf.Rad2Deg - 90;
        transform.Rotate(0, 0, Angle);

        if(objectToLook == null)
        {
            Debug.Log(objectToLook);
            Destroy(gameObject);
        }
        //indicator.transform.LookAt(transform.position, new Vector3(0,0,1));
    }
}
