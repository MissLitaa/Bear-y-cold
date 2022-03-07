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

    public Vector3 girlScoutSpawnPos;
    private Vector3 snowProyectilePos;

    public int girlScoutIndex;
    public int snowProyectileIndex;

    public countdownAndShop counter;
    public bool checkTimer_;
    public Coroutine stopGirlScout = null;

    public void Awake()
    {
        //StartCoroutine(spawnGirlScout(true));
    }

    void Update()
    {
        checkTimer_ = counter.checkTimer;

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Invoke("SpawnSnowProyectile", 0.5f);
        }

        if (checkTimer_ == false)
        {
            StopAllCoroutines();
            Debug.Log("Routine");
        }

    }


    public IEnumerator spawnGirlScout(bool run)
    {
        do
        {
            yield return new WaitForSecondsRealtime(5);
            doorOpening.Play();
            yield return new WaitForSecondsRealtime(1);
            girlScoutSpawnPos = new Vector3(-13, 1, 0);
            Instantiate(girlScout, girlScoutSpawnPos, girlScout.transform.rotation);
            Debug.Log("One girl scout has spawned");
            yield return spawnGirlScout(true);
        }
        while (run == true);
        
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
            //call coin substraction here
        }


    }

}