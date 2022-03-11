using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnManager : MonoBehaviour
{
    public GameObject girlScout;
    public GameObject snowProyectile;
    public GameObject proyOffset;
    public GameObject school;

    public Animator playerAnimator;
    public Animation doorOpening;

    public Vector3 girlScoutSpawnPos;
    private Vector3 snowProyectilePos;
    public Vector3 girlScoutCurrentPos;

    public int girlScoutIndex;
    public int snowProyectileIndex;
    public bool isAttacking;
    public bool isAttackPressed;

    public countdownAndShop counter;
    public bool checkTimer_;

    public proyectileForward proyFor;
        
    public void Start()
    {
        StartCoroutine(spawnGirlScout(true));
    }

    void Update()
    {
        checkTimer_ = counter.checkTimer;

        if (Input.GetKeyDown(KeyCode.Space))
        {
            playerAnimator.SetBool("isShooting", true);
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
        snowProyectilePos = proyOffset.transform.position;
        Instantiate(snowProyectile, proyOffset.transform.position, proyOffset.transform.rotation);
        playerAnimator.SetBool("isShooting", false);
    }

}