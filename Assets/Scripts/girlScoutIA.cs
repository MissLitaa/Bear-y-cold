using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class girlScoutIA : MonoBehaviour
{
    public GameObject player;
    public GameObject coin;
    private NavMeshAgent navMesh;
    public coinBehaviour coinBeh;
    private BoxCollider collider;

    //Animations
    public Animator scoutAnimator;
    public AnimationClip scoutRunningAnim;

    public float idleTime = 4f;

    public void Start()
    { 
        player = GameObject.Find("Player");
        navMesh = GetComponent<NavMeshAgent>();
        coinBeh = FindObjectOfType<coinBehaviour>();
        collider = GetComponent<BoxCollider>();
        scoutAnimator.SetBool("isMoving", true);

    }


    void FixedUpdate()
    {
        if(scoutAnimator.GetBool("isMoving")==true)
            navMesh.destination = player.transform.position;
    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            
            coinBeh.SubstractCoins();
            collision.gameObject.GetComponent<PlayerController>().playerAS.PlayOneShot(collision.gameObject.GetComponent<PlayerController>().playerHurt, 1);
            StartCoroutine(StayStill());
            
        }

    }

    IEnumerator StayStill()
{
        scoutAnimator.SetBool("isMoving", false);
        collider.enabled = false;
        yield return new WaitForSeconds(idleTime);
        collider.enabled = true;
        scoutAnimator.SetBool("isMoving", true);
    }

}
