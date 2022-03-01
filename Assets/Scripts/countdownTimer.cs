using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class countdownTimer : MonoBehaviour
{
    [HideInInspector] public float currentTime = 0f;
    [HideInInspector] public float startingTime = 30f;
    [HideInInspector] public bool timerIsRunning;
    [HideInInspector] public bool restartTimer;
    public TextMeshProUGUI timeDisplay;

    [HideInInspector] sceneManager sceneMan;
    public spawnManager spawnMan;

    public Canvas shopCanvas;
    public GameObject shopCanvasGEO;

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

    private void FixedUpdate()
    {
        StartCoroutine(timerRoutine(1));
    }

    public IEnumerator timerRoutine(int run)
    {
        playerPosition = player.transform.position;
        timeDisplay.text = currentTime.ToString("00:00");

        if (currentTime > 0 )
        {
            currentTime -= 1 * Time.deltaTime;
        }

        else if(currentTime <= 0)
        {
            StopCoroutine(timerRoutine(0));
            currentTime = 0;
            timerIsRunning = false;
            Debug.Log("Timer is not running");
            spawnMan.StopScoutFromRunning(true);

            if (timerIsRunning == false)
            {
                openShop();
                Debug.Log("Shop is now open");
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
                shopCanvasGEO.SetActive(true);
                shopCanvas.renderMode = RenderMode.ScreenSpaceOverlay;
                isInShop = true;
            }

            else if (Input.GetButtonDown("E") && isInShop == true)
            {
                shopCanvasGEO.SetActive(false);
                isInShop = false;
                isShopOpen = false;
                spawnMan.spawnGirlScout(true);
                currentTime = startingTime;
            }
        }
    }

    
}

