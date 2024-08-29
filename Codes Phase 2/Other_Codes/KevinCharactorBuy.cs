using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KevinCharacterBuy : MonoBehaviour
{
    public int Coins;
    public bool isBought = false;
    public int ChractorPrice = 10;
    public Canvas NotEnoughCoins;
    public GameObject BuyButton;
    public GameObject SellButton;

    [Header("Item Buy Buttons")]
    public GameObject BigAxeBuyButton;
    public GameObject LongbowBuyButton;
    public GameObject QuiverBuyButton;
    public GameObject SunglassesBuyButton;
    public GameObject BarretBuyButton;

    private PlayerManager playerManager;

    private void Start()
    {
        GameObject obj = GameObject.Find("FETCH");

        playerManager = obj.GetComponent<PlayerManager>();
        Coins=playerManager.GetCoins();
    }

    public void Character_Buy()
    {
        if (Coins >= ChractorPrice)
        {
            Coins -= ChractorPrice;
            playerManager.UpdateCoins(Coins);
            isBought = true;
            BuyButton.SetActive(false);
            SellButton.SetActive(true);

            // All item buy buttons will be enabled
            BigAxeBuyButton.SetActive(true);
            LongbowBuyButton.SetActive(true);
            QuiverBuyButton.SetActive(true);
            SunglassesBuyButton.SetActive(true);
            BarretBuyButton.SetActive(true);

        }
        else
        {
            NotEnoughCoins.gameObject.SetActive(true);
            // After 3 seconds, the warning will disappear
            Invoke("WarningOff", 3);
        }
    }

    public void Character_Sell()
    {
        if (isBought)
        {
            Coins += ChractorPrice;
            playerManager.UpdateCoins(Coins);
            isBought = false;
            BuyButton.SetActive(true);
            SellButton.SetActive(false);

            // All item buy buttons will be disabled
            BigAxeBuyButton.SetActive(false);
            LongbowBuyButton.SetActive(false);
            QuiverBuyButton.SetActive(false);
            SunglassesBuyButton.SetActive(false);
            BarretBuyButton.SetActive(false);
        }
    }

    private void WarningOff()
    {
        NotEnoughCoins.gameObject.SetActive(false);
    }
}
