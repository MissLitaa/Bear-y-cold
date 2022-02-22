using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class girlScoutIA : MonoBehaviour
{
    public GameObject player;
    private NavMeshAgent navMesh;
    public ParticleSystem snowBlowPS;
    public ParticleSystem snowWalkPS;
    
    private bool isPlaying = false;
   
    void Start()
    {
        navMesh = GetComponent<NavMeshAgent>();
        snowBlowPS = GetComponent<ParticleSystem>();
        snowWalkPS = GetComponent<ParticleSystem>();
    }

    
    void Update()
    {
        navMesh.destination = player.transform.position;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Time.timeScale = 0;
            //Game over goes here.
        }
       



        if (collision.gameObject.tag == "SnowProyectile")
        {
            snowWalkPS.Stop();
            snowBlowPS.Play();
            //Animation girl scout death here.
            Destroy(gameObject);
            //Generate coins. Call to coin script here.
        }
    }
}
