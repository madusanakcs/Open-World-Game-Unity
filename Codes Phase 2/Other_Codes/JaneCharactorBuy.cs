using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class JaneCharactorBuy : MonoBehaviour
{
    public int Coins;
    public bool isBought = false;
    public int CharacterPrice = 20;
    public Canvas NotEnoughCoins;
    public GameObject BuyButton;
    public GameObject SellButton;

    [Header("Item Buy Buttons")]
    public GameObject SmallAxeBuyButton;
    public GameObject SmallBowBuyButton;
    public GameObject SideQuiverBuyButton;
    private PlayerManager playerManager;
    private void WarningOff()
    {
        NotEnoughCoins.gameObject.SetActive(false);
    }

    private void Start()
    {
        GameObject obj = GameObject.Find("FETCH");

        playerManager = obj.GetComponent<PlayerManager>();
        Coins=playerManager.GetCoins();
   
    }
    public void Character_Buy()
    {
        if (Coins >= CharacterPrice && !isBought)
        {
            Coins -= CharacterPrice;
            playerManager.UpdateCoins(Coins);
            isBought = true;
            BuyButton.SetActive(false);
            SellButton.SetActive(true);
            SmallAxeBuyButton.SetActive(true);
            SmallBowBuyButton.SetActive(true);
            SideQuiverBuyButton.SetActive(true);


        }
        else
        {
            NotEnoughCoins.gameObject.SetActive(true);
            Invoke("WarningOff", 3);
        }
    }

    public void Character_Sell()
    {
        if (isBought)
        {
            Coins += CharacterPrice;
            playerManager.UpdateCoins(Coins);
            isBought = false;
            BuyButton.SetActive(true);
            SellButton.SetActive(false);
            SmallAxeBuyButton.SetActive(false);
            SmallBowBuyButton.SetActive(false);
            SideQuiverBuyButton.SetActive(false);

        }
    }
}
