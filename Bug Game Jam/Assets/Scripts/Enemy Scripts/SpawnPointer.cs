using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPointer : MonoBehaviour
{
    public GameObject pointer;
    private Vector3 position;
    private Transform parent;
    
    // Start is called before the first frame update
    void Start()
    {
        position = transform.parent.position - new Vector3(0, -5, 0);
        parent = Transform.this;
        Spawn();
    }

    void Spawn()
    {
        pointer.transform.SetParent(parent);
        Instantiate(pointer, position, Quaternion.identity);
    }
}
