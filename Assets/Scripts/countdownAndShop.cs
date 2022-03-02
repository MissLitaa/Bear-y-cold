using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class countdownAndShop : MonoBehaviour
{
    [HideInInspector] public float currentTime = 0f;
    [HideInInspector] public float startingTime = 5f;
    [HideInInspector] public bool timerIsRunning;
    [HideInInspector] public bool restartTimer;
    public bool checkTimer;

    public TextMeshProUGUI timeDisplay;
    public TextMeshProUGUI money;

    [HideInInspector] sceneManager sceneMan;
    public spawnManager spawnMan;

    public Canvas shopCanvas;
    public GameObject shopCanvasGEO;

    public ParticleSystem confettiParticles;
    public AudioSource confettiAudio;

    public GameObject shopGEO;
    public GameObject player;
    [HideInInspector] public bool isInShop;
    [HideInInspector] public Vector3 shopPosition;
    [HideInInspector] public Vector3 playerPosition;
    [HideInInspector] public float playerIsInRange = 7f;

    public float distance;
    public bool playerCanEnter;
    
    public void Start()
    {
        currentTime = startingTime;
        timerIsRunning = true;
        shopPosition = shopGEO.transform.localPosition;
    }

    public void FixedUpdate()
    {
        StartCoroutine(timerRoutine(1));
        checkTimer = timerIsRunning;
        Debug.Log($"Timer is updating to {timerIsRunning}");
        distance = Vector3.Distance(playerPosition, shopPosition);

        if (distance <= playerIsInRange)
        {
            playerCanEnter = true;
            Debug.Log("Player in range of shop");
        }

    }

    public IEnumerator timerRoutine(int run)
    {
        playerPosition = player.transform.position;
        timeDisplay.text = currentTime.ToString("00:00");

        if (currentTime > 0)
        {
            currentTime -= 1 * Time.deltaTime;
        }
        else if (currentTime <= 0)
        {
            currentTime = 0;
            timerIsRunning = false;

            Debug.Log("Timer is not running");

            if (timerIsRunning == false)
            {
                playerCanEnter = true;
                Debug.Log("Shop is now open");
                openShop();
            }
        }

        while (timerIsRunning)
        {
            yield return null;
        }

    }

    public void openShop()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            shopCanvasGEO.SetActive(true);
            Debug.Log("Player is in shop");
            isInShop = true;
        }

        else if (Input.GetKeyDown(KeyCode.Q) && isInShop == true)
        {
            shopCanvasGEO.SetActive(false);
            Debug.Log("Player leaves the shop");
            isInShop = false;
            new WaitForSecondsRealtime(2);
            spawnMan.spawnGirlScout(true);
            currentTime = startingTime;
            StartCoroutine(timerRoutine(1));
        }
    }

    public void shopSystem()
    {

    }
}

