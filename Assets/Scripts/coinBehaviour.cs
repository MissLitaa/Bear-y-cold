using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class coinBehaviour : MonoBehaviour
{

    public TextMeshProUGUI coinCounter;
    private int baseCoins = 60;
    private int girlScoutDrop = 5;
    private int currentCoins;
    public int lossDrop = 3;

    //Prices
    public int milkInt = 20;
    public int eggsInt = 10;
    public int butterInt = 20;
    public int flourInt = 15;
    public int sugarInt = 15;

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

    void Start()
    {
        currentCoins = baseCoins;
        coinCounter.text = currentCoins.ToString();
        new WaitForSecondsRealtime(3);

    }

    private void Update()
    {
        coinCounter.text = currentCoins.ToString();
    }
    public void AddCoins()
    {
        currentCoins = currentCoins + girlScoutDrop;
    }

    public void SubstractCoins()
    {
        currentCoins = currentCoins - lossDrop;
    }

    public void buyMilk()
    {
        currentCoins = currentCoins - milkInt;
        milkBool = true;
        milkDisableButton.gameObject.SetActive(false);
        milkTick.gameObject.SetActive(true);
        Debug.Log("I have Mommy Milky!");
    }
    public void buyEggs()
    {
        currentCoins = currentCoins - eggsInt;
        eggsBool = true;
        eggDisableButton.gameObject.SetActive(false);
        eggTick.gameObject.SetActive(true);
    }
    public void buyButter()
    {
        currentCoins = currentCoins - butterInt;
        butterBool = true;
        butterDisableButton.gameObject.SetActive(false);
        butterTick.gameObject.SetActive(true);
    }
    public void buyFlour()
    {
        currentCoins = currentCoins - flourInt;
        flourBool = true;

        flourDisableButton.gameObject.SetActive(false);
        flourTick.gameObject.SetActive(true);
    }
    public void buySugar()
    {
        currentCoins = currentCoins - sugarInt;
        sugarBool = true;
        sugarDisableButton.gameObject.SetActive(false);
        sugarTick.gameObject.SetActive(true);
    }

    public void GameOver()
    {
        //if our coins reach 0 we call scenemanager, gameover.
    }
}
