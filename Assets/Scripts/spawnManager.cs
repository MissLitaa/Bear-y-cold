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

    public ParticleSystem snowBlowPS;

    public Vector3 girlScoutSpawnPos;
    private Vector3 snowProyectilePos;

    public int girlScoutIndex;
    public int snowProyectileIndex;


    public void Start()
    {
        snowBlowPS = snowProyectile.GetComponent<ParticleSystem>();
        StartCoroutine(spawnGirlScout(true));
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Invoke("SpawnSnowProyectile", 0.5f);
        }

    }       


    public IEnumerator spawnGirlScout(bool run)
    {
        yield return new WaitForSecondsRealtime(5);
        doorOpening.Play();
        yield return new WaitForSecondsRealtime(1);
        girlScoutSpawnPos = new Vector3(-13, 1, 0);
        Instantiate(girlScout, girlScoutSpawnPos, girlScout.transform.rotation);
        Debug.Log("One girl scout has spawned");
        yield return spawnGirlScout(true);
        
    }

    public void StopScoutFromRunning(bool stopRun)
    {
        //Ponemos el stopcoroutine en una función para poder llamarla desde otro script.
        
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
            
        }


    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            snowBlowPS.Play();
            //Animation girl scout death here.
            Destroy(gameObject);
            //Generate coins. Call to coin script here.
        }
    }
}