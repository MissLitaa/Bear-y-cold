using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnManager : MonoBehaviour
{
    public GameObject girlScout;
    public GameObject snowProyectile;
    public GameObject player;

    private Vector3 girlScoutSpawnPos;
    private Vector3 snowProyectilePos;
    

    public int girlScoutIndex;
    public int snowProyectileIndex;

    
    void Start()
    {
        
        InvokeRepeating("SpawnGirlScout", time: 2, repeatRate: 1.5f);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Invoke("SpawnSnowProyectile", 0.5f);
        }
    }

    public void SpawnGirlScout()
    {
        girlScoutSpawnPos = new Vector3(-11, 1, 0);
        Instantiate(girlScout, girlScoutSpawnPos, girlScout.transform.rotation);
    }

    public void SpawnSnowProyectile()
    {
        Vector3 offset = new Vector3(0, 1.1f, 0);
        snowProyectilePos = player.transform.position;
        Vector3 proyectileOffset = snowProyectilePos + offset;
       
        Instantiate(snowProyectile, proyectileOffset, player.transform.rotation);
    }
}
