using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class countdownTimer : MonoBehaviour
{
    [HideInInspector] public float currentTime = 0f;
    [HideInInspector] public float startingTime = 30f;
    [HideInInspector] public TextMeshPro timeDisplay;
    [HideInInspector] public bool timerIsRunning;
    [HideInInspector] public bool restartTimer;

    public ParticleSystem confettiParticles;
    public AudioSource confettiAudio;

    public GameObject shopGEO;
    public GameObject player;
    [HideInInspector] public bool isShopOpen;
    [HideInInspector] public bool isInShop;
    [HideInInspector] public Vector3 shopPosition;
    [HideInInspector] public Vector3 playerPosition;
    [HideInInspector] public int playerIsInRange = 2;

    [HideInInspector] public int methodIsRunning = 0;

    void Start()
    {
        currentTime = startingTime;
        timerIsRunning = true;
        shopPosition = shopGEO.transform.position;
    }

    IEnumerator timerRoutine()
    {
        playerPosition = player.transform.position;
        currentTime -= 1 * Time.deltaTime;
        timeDisplay.text = currentTime.ToString("0");

        if (currentTime <= 0)
        {
            currentTime = 0;
            timerIsRunning = false;
            //stop enemy spawn here

            if (methodIsRunning == 0 && timerIsRunning == false)
            {
                methodIsRunning++;
                openShop();
            }

            //particles confetti here

            //confetti sound here


        }

        while (timerIsRunning)
        {
            isShopOpen = false;
            isInShop = false;
            yield return null;
        }
    }


    public void openShop()
    {
        isShopOpen = true;
        float distance = Vector3.Distance(playerPosition, shopPosition);

        if (distance < playerIsInRange)
        {
            if (Input.GetButtonDown("E"))
            {
                isInShop = true;
                //call shop system here. (scenemode.additive, el canvas de la hud de la tienda)
                //update inventory if necessary.
            }

            else if (Input.GetButtonDown("E") && isInShop == true)
                {
                //close shop system first
                isInShop = false;
                isShopOpen = false;
            }
        }
    }
}

