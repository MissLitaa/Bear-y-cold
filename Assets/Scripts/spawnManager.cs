using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnManager : MonoBehaviour
{
    public GameObject girlScout;
    public GameObject snowProyectile;
    public GameObject player;
    public GameObject school;

    public Animation doorOpening;

    private Vector3 girlScoutSpawnPos;
    private Vector3 snowProyectilePos;

    public int girlScoutIndex;
    public int snowProyectileIndex;

    void Start()
    {
        StartCoroutine(spawnGirlScoutt(1));
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Invoke("SpawnSnowProyectile", 0.5f);
        }
    }

    IEnumerator spawnGirlScoutt(int spawn)
    {
        
        doorOpening.Play();
        yield return new WaitForSecondsRealtime(2);
        girlScoutSpawnPos = new Vector3(-13, 1, 0);
        Instantiate(girlScout, girlScoutSpawnPos, girlScout.transform.rotation);
    }

    public void SpawnSnowProyectile()
    {
        Vector3 offset = new Vector3(0, 1.1f, 0);
        snowProyectilePos = player.transform.position;
        Vector3 proyectileOffset = snowProyectilePos + offset;
       
        Instantiate(snowProyectile, proyectileOffset, player.transform.rotation);
    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Time.timeScale = 0;
            //Game over goes here.
        }

    }

}
