using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class countdownAndShop : MonoBehaviour
{
    public float currentTime = 0f;
    public float startingTime = 30f;
    public bool timerIsRunning;
    public bool restartTimer;
    public bool checkTimer;

    public TextMeshProUGUI timeDisplay;
    public TextMeshProUGUI money;

    [HideInInspector] sceneManager sceneMan;
    public GameObject spawnMan;

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
        StartCoroutine(timerRoutine(true));
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

    public IEnumerator timerRoutine(bool run)
    {
       
        playerPosition = player.transform.position;
        timeDisplay.text = currentTime.ToString("00:00");

        if (currentTime > 0)
        {
            currentTime -= 1 * Time.deltaTime;
            timerIsRunning = true;

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
        timerIsRunning = false;
    }

    public void closeShop()
    {
        currentTime = startingTime;
        shopCanvasGEO.SetActive(false);
        Debug.Log("Player leaves the shop");
        isInShop = false;
        StartCoroutine(timerRoutine(true));
        StartCoroutine(spawnMan.GetComponent<spawnManager>().spawnGirlScout(true));
    }

}

