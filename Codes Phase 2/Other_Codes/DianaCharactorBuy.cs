using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DianaCharactorBuy : MonoBehaviour
{
    public int Coins = 100;
    public bool isBought = false;
    public int ChractorPrice = 10;
    public Canvas NotEnoughCoins;
    public GameObject BuyButton;
    public GameObject SellButton;

    [Header("item Buy Buttons")]
    public GameObject AxeBuyButton;
    public GameObject BowBuyButton;
    public GameObject QuiverBuyButton;
    public GameObject JacketBuyButton;
    public GameObject GlovesBuyButton;
    public GameObject ShoesBuyButton;
    public GameObject DressBuyButton;


    public void Charactor_Buy()
    {
        if (Coins >= ChractorPrice)
        {
            Coins -= ChractorPrice;
            isBought = true;
            BuyButton.SetActive(false);
            SellButton.SetActive(true);

            // all item buy buttons will be enabels
            AxeBuyButton.SetActive(true);
            BowBuyButton.SetActive(true);
            QuiverBuyButton.SetActive(true);
            JacketBuyButton.SetActive(true);
            GlovesBuyButton.SetActive(true);
            ShoesBuyButton.SetActive(true);
            DressBuyButton.SetActive(true);

        }
        else
        {
            NotEnoughCoins.gameObject.SetActive(true);
            // after 3 seconds the warning will disappear
            Invoke("WarningOff", 3);
        }
    }

    public void Charactor_Sell()
    {
        if (isBought)
        {
            Coins += ChractorPrice;
            isBought = false;
            BuyButton.SetActive(true);
            SellButton.SetActive(false);

            // all item buy buttons will be disabels
            AxeBuyButton.SetActive(false);
            BowBuyButton.SetActive(false);
            QuiverBuyButton.SetActive(false);
            JacketBuyButton.SetActive(false);
            GlovesBuyButton.SetActive(false);
            ShoesBuyButton.SetActive(false);
            DressBuyButton.SetActive(false);
            
        }
    }

    private void WarningOff()
    {
        NotEnoughCoins.gameObject.SetActive(false);
    }
}
