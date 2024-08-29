using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class JaneBuyItem : MonoBehaviour
{
    public int Coins;

    public bool SmallAxeIsBought = false;
    public bool SmallBowIsBought = false;
    public bool SideQuiverIsBought = false;

    public int itemPrice = 10;
    public Canvas NotEnoughCoins;

    [Header("Item Prices")]
    public int SmallAxePrice = 7;
    public int SmallBowPrice = 6;
    public int SideQuiverPrice = 4;

    public GameObject CoinText;

    [Header("Item Buy Buttons")]
    public GameObject SmallAxeBuyButton;
    public GameObject SmallAxeSellButton;
    public GameObject SmallBowBuyButton;
    public GameObject SmallBowSellButton;
    public GameObject SideQuiverBuyButton;
    public GameObject SideQuiverSellButton;

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

    public void BuySmallAxe()
    {
        if (Coins >= SmallAxePrice)
        {
            Coins -= SmallAxePrice;
            playerManager.UpdateCoins(Coins);
            SmallAxeIsBought = true;
            SmallAxeBuyButton.SetActive(false);
            SmallAxeSellButton.SetActive(true);
            UpdateCoins();
        }
        else
        {
            NotEnoughCoins.gameObject.SetActive(true);
            Invoke("WarningOff", 3);
        }
    }

    public void SellSmallAxe()
    {
        if (SmallAxeIsBought)
        {
            Coins += SmallAxePrice;
            playerManager.UpdateCoins(Coins);
            SmallAxeIsBought = false;
            SmallAxeBuyButton.SetActive(true);
            SmallAxeSellButton.SetActive(false);
            UpdateCoins();
        }
    }

    public void BuySmallBow()
    {
        if (Coins >= SmallBowPrice)
        {
            Coins -= SmallBowPrice;
            playerManager.UpdateCoins(Coins);
            SmallBowIsBought = true;
            SmallBowBuyButton.SetActive(false);
            SmallBowSellButton.SetActive(true);
            UpdateCoins();
        }
        else
        {
            NotEnoughCoins.gameObject.SetActive(true);
            Invoke("WarningOff", 3);
        }
    }

    public void SellSmallBow()
    {
        if (SmallBowIsBought)
        {
            Coins += SmallBowPrice;
            playerManager.UpdateCoins(Coins);
            SmallBowIsBought = false;
            SmallBowBuyButton.SetActive(true);
            SmallBowSellButton.SetActive(false);
            UpdateCoins();
        }
    }

    public void BuySideQuiver()
    {
        if (Coins >= SideQuiverPrice)
        {
            Coins -= SideQuiverPrice;
            playerManager.UpdateCoins(Coins);
            SideQuiverIsBought = true;
            SideQuiverBuyButton.SetActive(false);
            SideQuiverSellButton.SetActive(true);
            UpdateCoins();
        }
        else
        {
            NotEnoughCoins.gameObject.SetActive(true);
            Invoke("WarningOff", 3);
        }
    }

    public void SellSideQuiver()
    {
        if (SideQuiverIsBought)
        {
            Coins += SideQuiverPrice;
            playerManager.UpdateCoins(Coins);
            SideQuiverIsBought = false;
            SideQuiverBuyButton.SetActive(true);
            SideQuiverSellButton.SetActive(false);
            UpdateCoins();
        }
    }
}
