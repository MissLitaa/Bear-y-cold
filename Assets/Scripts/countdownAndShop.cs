using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class countdownAndShop : MonoBehaviour
{
    public float currentTime = 0f;
    public float startingTime = 5f;
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
    private float playerIsInRange = 9f;

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
        if (distance <= playerIsInRange && timerIsRunning==false)
        {
            playerCanEnter = true;
            Debug.Log("Player in range of shop");
            if (Input.GetKeyDown(KeyCode.E))
            {
                if (!isInShop)
                {
                    openShop();
                }

                else
                {
                    closeShop();
                }
            }
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

        }

        while (timerIsRunning)
        {
            yield return null;
        }

    }

    public void openShop()
    {
            shopCanvasGEO.SetActive(true);
            Debug.Log("Player is in shop");
            isInShop = true;
    }

    public void closeShop()
    {
        shopCanvasGEO.SetActive(false);
        Debug.Log("Player leaves the shop");
        isInShop = false;
        spawnMan.spawnGirlScout(true);
        currentTime = startingTime;
        timerIsRunning = true;
        StartCoroutine(timerRoutine(1));
    }

    public void shopSystem()
    {

    }
}

