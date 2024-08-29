using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class KevinBuyItem : MonoBehaviour
{
    public int Coins;

    public bool BigAxeIsBought = false;
    public bool LongbowIsBought = false;
    public bool QuiverIsBought = false;
    public bool SunglassesIsBought = false;
    public bool BarretIsBought = false;

    public int itemPrice = 10;
    public Canvas NotEnoughCoins;

    [Header("Item Prices")]
    public int BigAxePrice = 5;
    public int LongbowPrice = 4;
    public int QuiverPrice = 3;
    public int SunglassesPrice = 2;
    public int BarretPrice = 6;

    public GameObject CoinText;

    [Header("Item Buy Buttons")]
    public GameObject BigAxeBuyButton;
    public GameObject BigAxeSellButton;
    public GameObject LongbowBuyButton;
    public GameObject LongbowSellButton;
    public GameObject QuiverBuyButton;
    public GameObject QuiverSellButton;
    public GameObject SunglassesBuyButton;
    public GameObject SunglassesSellButton;
    public GameObject BarretBuyButton;
    public GameObject BarretSellButton;

    private PlayerManager playerManager;
    private void Start()
    {
        GameObject obj = GameObject.Find("FETCH");

        playerManager = obj.GetComponent<PlayerManager>();
        Coins = playerManager.GetCoins();
        UpdateCoins();
        
    }
    private void WarningOff()
    {
        NotEnoughCoins.gameObject.SetActive(false);
    }

    public void UpdateCoins()
    {
        CoinText.GetComponent<TextMeshProUGUI>().text = "Coins - " + Coins.ToString();
    }

    public void BuyBigAxe()
    {
        if (Coins >= BigAxePrice)
        {
            Coins -= BigAxePrice;
            BigAxeIsBought = true;
            playerManager.UpdateCoins(Coins);
            BigAxeBuyButton.SetActive(false);
            BigAxeSellButton.SetActive(true);
            UpdateCoins();
        }
        else
        {
            NotEnoughCoins.gameObject.SetActive(true);
            Invoke("WarningOff", 3);
        }
    }

    public void SellBigAxe()
    {
        if (BigAxeIsBought)
        {
            Coins += BigAxePrice;
            playerManager.UpdateCoins(Coins);
            BigAxeIsBought = false;
            BigAxeBuyButton.SetActive(true);
            BigAxeSellButton.SetActive(false);
            UpdateCoins();
        }
    }

    public void BuyLongbow()
    {
        if (Coins >= LongbowPrice)
        {
            Coins -= LongbowPrice;
            playerManager.UpdateCoins(Coins);
            LongbowIsBought = true;
            LongbowBuyButton.SetActive(false);
            LongbowSellButton.SetActive(true);
            UpdateCoins();
        }
        else
        {
            NotEnoughCoins.gameObject.SetActive(true);
            Invoke("WarningOff", 3);
        }
    }

    public void SellLongbow()
    {
        if (LongbowIsBought)
        {
            Coins += LongbowPrice;
            playerManager.UpdateCoins(Coins);
            LongbowIsBought = false;
            LongbowBuyButton.SetActive(true);
            LongbowSellButton.SetActive(false);
            UpdateCoins();
        }
    }

    public void BuyQuiver()
    {
        if (Coins >= QuiverPrice)
        {
            Coins -= QuiverPrice;
            playerManager.UpdateCoins(Coins);
            QuiverIsBought = true;
            QuiverBuyButton.SetActive(false);
            QuiverSellButton.SetActive(true);
            UpdateCoins();
        }
        else
        {
            NotEnoughCoins.gameObject.SetActive(true);
            Invoke("WarningOff", 3);
        }
    }

    public void SellQuiver()
    {
        if (QuiverIsBought)
        {
            Coins += QuiverPrice;
            playerManager.UpdateCoins(Coins);
            QuiverIsBought = false;
            QuiverBuyButton.SetActive(true);
            QuiverSellButton.SetActive(false);
            UpdateCoins();
        }
    }

    public void BuySunglasses()
    {
        if (Coins >= SunglassesPrice)
        {
            Coins -= SunglassesPrice;
            playerManager.UpdateCoins(Coins);
            SunglassesIsBought = true;
            SunglassesBuyButton.SetActive(false);
            SunglassesSellButton.SetActive(true);
            UpdateCoins();
        }
        else
        {
            NotEnoughCoins.gameObject.SetActive(true);
            Invoke("WarningOff", 3);
        }
    }

    public void SellSunglasses()
    {
        if (SunglassesIsBought)
        {
            Coins += SunglassesPrice;
            playerManager.UpdateCoins(Coins);
            SunglassesIsBought = false;
            SunglassesBuyButton.SetActive(true);
            SunglassesSellButton.SetActive(false);
            UpdateCoins();
        }
    }

    public void BuyBarret()
    {
        if (Coins >= BarretPrice)
        {
            Coins -= BarretPrice;
            playerManager.UpdateCoins(Coins);
            BarretIsBought = true;
            BarretBuyButton.SetActive(false);
            BarretSellButton.SetActive(true);
            UpdateCoins();
        }
        else
        {
            NotEnoughCoins.gameObject.SetActive(true);
            Invoke("WarningOff", 3);
        }
    }

    public void SellBarret()
    {
        if (BarretIsBought)
        {
            Coins += BarretPrice;
            playerManager.UpdateCoins(Coins);
            BarretIsBought = false;
            BarretBuyButton.SetActive(true);
            BarretSellButton.SetActive(false);
            UpdateCoins();
        }
    }
}
