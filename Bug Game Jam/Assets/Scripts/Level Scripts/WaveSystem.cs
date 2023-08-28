using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSystem : MonoBehaviour
{

    [SerializeField] private WaveStarter waveStarter;
    // Start is called before the first frame update
    private void Start()
    {
        
    }

    private void WaveStart()
    {
        Debug.Log("WaveStarter on trigger active");
        Invoke("Spawning", 3.0f);
    }


    
}
