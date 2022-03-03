using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class coinBehaviour : MonoBehaviour
{
    public TextMeshProUGUI coinCounter;
    public int startCoins;
    public int baseCoins = 60;
    public int girlScoutDrop = 5;
    public int lossDrop = 3;
    public int currentCoins;
    public int milk = 20;
    public int eggs = 10;
    public int butter = 20;
    public int flour = 15;
    public int sugar = 15;

    void Start()
    {
        startCoins = baseCoins + currentCoins;
        coinCounter.text = startCoins.ToString();
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
        currentCoins = currentCoins - milk;

        //add object to inventory
        //make it impossible to buy again.
        /* if (in inventory)
         {
          can't click
         }*/
    }
    public void buyEggs()
    {
        currentCoins = currentCoins - eggs;
        //add object to inventory
    }
    public void buyButter()
    {
        currentCoins = currentCoins - butter;
        //add object to inventory
    }
    public void buyFlour()
    {
        currentCoins = currentCoins - flour;
        //add object to inventory
    }
    public void buySugar()
    {
        currentCoins = currentCoins - sugar;
        //add object to inventory
    }
}
