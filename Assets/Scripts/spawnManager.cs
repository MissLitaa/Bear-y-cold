using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnManager : MonoBehaviour
{
    public GameObject[] girlScout;
    public GameObject[] snowProyectile;
    public GameObject player;

    private Vector3 girlScoutSpawnPos;
    private Vector3 snowProyectilePos;

    public int girlScoutIndex;
    public int snowProyectileIndex;

    
    void Start()
    {
        
        InvokeRepeating("SpawnGirlScout", time: 2, repeatRate: 1.5f);
    }

    public void SpawnGirlScout()
    {
        girlScoutSpawnPos = new Vector3(-11, 1, 0);

        girlScoutIndex = girlScout.Length;
        Instantiate(girlScout[girlScoutIndex], girlScoutSpawnPos, girlScout[girlScoutIndex].transform.rotation);
    }

    public void SpawnSnowProyectile()
    {
        snowProyectilePos = player.transform.position ++ ;

        girlScoutIndex = girlScout.Length;
        Instantiate(snowProyectile, transform.position, snowProyectile.transform.rotation);
    }
}
