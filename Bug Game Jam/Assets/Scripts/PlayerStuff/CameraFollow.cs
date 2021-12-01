using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    private Camera camera;
    private Vector3 lerpedPosition;
    // Start is called before the first frame update

    void FixedUpdate()
    {
       lerpedPosition = Vector3.Lerp(transform.position, target.position, Time.deltaTime * 10f);
       lerpedPosition.z = -10f;
    }

    void LateUpdate()
    {
        transform.position = lerpedPosition;
    }
}
