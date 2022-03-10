using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class coinBehaviour : MonoBehaviour
{

    public TextMeshProUGUI coinCounter;
    public TextMeshProUGUI yesWin;
    public TextMeshProUGUI noContinue;
    public GameObject notEnoughMoneyText;
    private int baseCoins = 60;
    private int girlScoutDrop = 1;
    private int currentCoins;
    public int lossDrop = 3;

    //Audio
    public AudioSource buyIngrAS;
    public AudioSource lossCoinAS;
    public AudioClip buyIngrAC;
    public AudioClip lossCoinsAC;

    //Prices
    [SerializeField] private int milkInt = 30;
    [SerializeField] private int eggsInt = 25;
    [SerializeField] private int butterInt = 30;
    [SerializeField] private int flourInt = 25;
    [SerializeField] private int sugarInt = 25;

    //Are in inventory
    public bool milkBool;
    public bool eggsBool;
    public bool butterBool;
    public bool flourBool;
    public bool sugarBool;

    //Button disabling
    public Button milkDisableButton;
    public Button eggDisableButton;
    public Button butterDisableButton;
    public Button flourDisableButton;
    public Button sugarDisableButton;

    //Ticks
    public Image milkTick;
    public Image eggTick;
    public Image butterTick;
    public Image flourTick;
    public Image sugarTick;

    //Cross
    public Image milkCross;
    public Image eggCross;
    public Image butterCross;
    public Image flourCross;
    public Image sugarCross;

    //Game Over
    public GameObject sceneMan;

    void Start()
    {
        currentCoins = baseCoins;
        coinCounter.text = currentCoins.ToString();
        notEnoughMoneyText.gameObject.SetActive(false);
    }

    private void Update()
    {
        coinCounter.text = currentCoins.ToString();
        accessGameOver();
    }
    public void AddCoins()
    {
        currentCoins = currentCoins + girlScoutDrop;
        buyIngrAS.PlayOneShot(buyIngrAC, 1f);
    }

    public void SubstractCoins()
    {
        currentCoins = currentCoins - lossDrop;
        lossCoinAS.PlayOneShot(lossCoinsAC, 1f);
    }

    public void buyMilk()
    {
        if (currentCoins <= milkInt)
        {
            StartCoroutine(notEnoughMoney());
        }
        else
        {
            currentCoins = currentCoins - milkInt;
            milkBool = true;
            buyIngrAS.PlayOneShot(buyIngrAC, 1f);
            milkDisableButton.gameObject.SetActive(false);
            milkTick.gameObject.SetActive(true);
            Debug.Log("Player now has milk");
            milkCross.gameObject.SetActive(true);
        }
    }
    public void buyEggs()
    {
        if (currentCoins <= eggsInt)
        {
            StartCoroutine(notEnoughMoney());
        }
        else
        {
            currentCoins = currentCoins - eggsInt;
            eggsBool = true;
            buyIngrAS.PlayOneShot(buyIngrAC, 1f);
            eggDisableButton.gameObject.SetActive(false);
            eggTick.gameObject.SetActive(true);
            Debug.Log("Player now has eggs");
            eggCross.gameObject.SetActive(true);
        }
    }
    public void buyButter()
    {
        if (currentCoins <= butterInt)
        {
            StartCoroutine(notEnoughMoney());
        }
        else
        {
            currentCoins = currentCoins - butterInt;
            butterBool = true;
            buyIngrAS.PlayOneShot(buyIngrAC, 1f);
            butterDisableButton.gameObject.SetActive(false);
            butterTick.gameObject.SetActive(true);
            Debug.Log("Player now has butter");
            butterCross.gameObject.SetActive(true);
        }
    }
    public void buyFlour()
    {
        if (currentCoins <= flourInt)
        {
            StartCoroutine(notEnoughMoney());
        }
        else
        {
            currentCoins = currentCoins - flourInt;
            flourBool = true;
            buyIngrAS.PlayOneShot(buyIngrAC, 1f);
            flourDisableButton.gameObject.SetActive(false);
            flourTick.gameObject.SetActive(true);
            Debug.Log("Player now has flour");
            flourCross.gameObject.SetActive(true);
        }
       
    }
    public void buySugar()
    {
        if (currentCoins <= sugarInt)
        {
            StartCoroutine(notEnoughMoney());
        }
        
        else
        {
            currentCoins = currentCoins - sugarInt;
            sugarBool = true;
            buyIngrAS.PlayOneShot(buyIngrAC, 1f);
            sugarDisableButton.gameObject.SetActive(false);
            sugarTick.gameObject.SetActive(true);
            Debug.Log("Player now has sugar");
            sugarCross.gameObject.SetActive(true);
        }
    }

    public void accessGameOver()
    {
        if (currentCoins <= 0)
        {
            GetComponent<sceneManager>().levelTransitionEnd();
            GetComponent<sceneManager>().GameOver();
        }
    }

    public void endGame()
    {
        if (milkBool == true && eggsBool == true && butterBool == true && flourBool == true && sugarBool == true )
        {
            endGameTrue();
            GetComponent<sceneManager>().levelTransitionEnd();
            GetComponent<sceneManager>().MainMenu();
        }

        else
        {
            noContinue.gameObject.SetActive(true);
            noContinueText();
            noContinue.gameObject.SetActive(false);
        }
    }
    
    
    IEnumerator notEnoughMoney()
    {
        notEnoughMoneyText.gameObject.SetActive(true);
        yield return new WaitForSeconds(3);
        notEnoughMoneyText.gameObject.SetActive(false);
    }

    IEnumerator endGameTrue()
    {
        yesWin.gameObject.SetActive(true);
        yield return new WaitForSecondsRealtime(5);
        yesWin.gameObject.SetActive(false);
    }

    IEnumerator noContinueText()
    {
        noContinue.gameObject.SetActive(true);
        yield return new WaitForSecondsRealtime(3);
        noContinue.gameObject.SetActive(false);
    }

}
