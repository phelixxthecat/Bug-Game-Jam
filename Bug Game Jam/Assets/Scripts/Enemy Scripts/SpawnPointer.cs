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
        Spawn();
    }

    void Spawn()
    {
        Instantiate(pointer, transform, true);
    }
}
