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

    //Animations
    public Animator scoutAnimator;
    public AnimationClip scoutRunningAnim;

    public void Start()
    {
        player = GameObject.Find("Player");
        navMesh = GetComponent<NavMeshAgent>();
        coinBeh = FindObjectOfType<coinBehaviour>();
    }

    
    void FixedUpdate()
    {
        scoutAnimator.SetBool("isMoving", true);
        navMesh.destination = player.transform.position;
    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            coinBeh.SubstractCoins();
            transform.localPosition -= 3 * Vector3.forward;
            collision.gameObject.GetComponent<PlayerController>().playerAS.PlayOneShot(collision.gameObject.GetComponent<PlayerController>().playerHurt, 1);

        }


    }

    private void OnDestroy()
    {
        scoutAnimator.SetBool("isMoving", false);

        
    }
}
