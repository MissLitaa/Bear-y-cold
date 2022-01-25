using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnManager : MonoBehaviour
{
    public GameObject girlScout;
    void Start()
    {
        transform.position = new Vector3(-11, 1, 0);
        InvokeRepeating("SpawnGirlScout", time: 2, repeatRate: 1.5f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SpawnGirlScout()
    {

    }
}
