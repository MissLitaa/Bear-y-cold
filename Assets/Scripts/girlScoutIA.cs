using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class girlScoutIA : MonoBehaviour
{
    public GameObject player;
    private NavMeshAgent navMesh;
   
    void Start()
    {
        navMesh = GetComponent<NavMeshAgent>();
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

        if (collision.gameObject.tag == "SnowProjectile")
        {
            //Particles go here.
            //Animation girl scout death here.
            //Destroy game object here.
            //Generate coins. Call to coin script here.
        }
    }
}
