using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

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
        //disable button but not the tick (easy way)
    }
    public void buyEggs()
    {
        currentCoins = currentCoins - eggsInt;
        eggsBool = true;
    }
    public void buyButter()
    {
        currentCoins = currentCoins - butterInt;
        butterBool = true;
    }
    public void buyFlour()
    {
        currentCoins = currentCoins - flourInt;
        flourBool = true;
    }
    public void buySugar()
    {
        currentCoins = currentCoins - sugarInt;
        sugarBool = true;
    }

    public void disableButton()
    {
    }

    public void GameOver()
    {
        //if our coins reach 0 we call scenemanager, gameover.
    }
}
