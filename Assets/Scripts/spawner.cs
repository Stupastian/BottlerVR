using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawner : MonoBehaviour
{
    public Transform spawnerLocation;
    public GameObject bottle;
    
    [SerializeField] float timer = 1f;
    [SerializeField] float startTime = 3f;
    bool running = true;
    private void Start()
    {
        InvokeRepeating("SpawnBottle", startTime, timer);
    }
    // Update is called once per frame
    void Update()
    {
    }

    void SpawnBottle()
    {
        Instantiate(bottle, spawnerLocation.position, spawnerLocation.rotation);
        
    }
}
