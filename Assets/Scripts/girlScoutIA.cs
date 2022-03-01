using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class girlScoutIA : MonoBehaviour
{
    public GameObject player;
    public GameObject coin;
    private NavMeshAgent navMesh;
   
    public void Start()
    {
        player = GameObject.Find("Player");
        navMesh = GetComponent<NavMeshAgent>();
        
    }

    
    void FixedUpdate()
    {
        navMesh.destination = player.transform.position;
    }

}
