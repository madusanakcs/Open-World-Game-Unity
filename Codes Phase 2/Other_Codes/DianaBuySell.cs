using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DianaBuyItem : MonoBehaviour
{
    public int Coins = 100;

    public bool AxeIsBought = false;
    public bool BowIsBought = false;
    public bool QuiverIsBought = false;
    public bool JacketIsBought = false;
    public bool GlovesIsBought = false;
    public bool ShoesIsBought = false;
    public bool DressIsBought = false;








    public int itemPrice = 10;
    public Canvas NotEnoughCoins;


    [Header("Item Prices")]
    public int AxePrice=5;
    public int BowPrice=4;
    public int QuiverPrice=3;
    public int JacketPrice=3;
    public int GlovesPrice=1;
    public int ShoesPrice=1;
    public int DressPrice=3;

    public GameObject CoinText;


    [Header("item Buy Buttons")]
    public GameObject AxeBuyButton;
    public GameObject AxeSellButton;
    public GameObject BowBuyButton;
    public GameObject BowSellButton;
    public GameObject QuiverBuyButton;
    public GameObject QuiverSellButton;
    public GameObject JacketBuyButton;
    public GameObject JacketSellButton;
    public GameObject GlovesBuyButton;
    public GameObject GlovesSellButton;
    public GameObject ShoesBuyButton;
    public GameObject ShoesSellButton;
    public GameObject DressBuyButton;
    public GameObject DressSellButton;



    private void WarningOff()
    {
        NotEnoughCoins.gameObject.SetActive(false);
        // Pannel Canvas Disable for  3 seconds

    }

    public void UpdateCoins()
    {
        CoinText.GetComponent<TextMeshProUGUI>().text = "Coins - " + Coins.ToString();
    }

//////////////////////////////////////////////////////////////////////////////////////////////////////



    public void BuyAxe()
    {
          
        if (Coins >= AxePrice)
        {
            Coins -= AxePrice;
            AxeIsBought = true;
            AxeBuyButton.SetActive(false);
            AxeSellButton.SetActive(true);
            UpdateCoins();
        }
        else
        {
            NotEnoughCoins.gameObject.SetActive(true);
            // after 3 seconds the warning will disappear
            Invoke("WarningOff", 3);
        }
    }

    public void SellAxe()
    {
        if (AxeIsBought)
        {
            Coins += AxePrice;
            AxeIsBought = false;
            AxeBuyButton.SetActive(true);
            AxeSellButton.SetActive(false);
            UpdateCoins();
        }
    }


    public void BuyBow()
    {
         
        if (Coins >= BowPrice)
        {
            Coins -= BowPrice;
            BowIsBought = true;
            BowBuyButton.SetActive(false);
            BowSellButton.SetActive(true);
            UpdateCoins();
        }
        else
        {
            NotEnoughCoins.gameObject.SetActive(true);
            // after 3 seconds the warning will disappear
            Invoke("WarningOff", 3);
        }
    }

    public void SellBow()
    {
        if (BowIsBought)
        {
            Coins += BowPrice;
            BowIsBought = false;
            BowBuyButton.SetActive(true);
            BowSellButton.SetActive(false);
            UpdateCoins();
        }
    }

    public void BuyQuiver()
    {
         
        if (Coins >= QuiverPrice)
        {
            Coins -= QuiverPrice;
            QuiverIsBought = true;
            QuiverBuyButton.SetActive(false);
            QuiverSellButton.SetActive(true);
            UpdateCoins();
        }
        else
        {
            NotEnoughCoins.gameObject.SetActive(true);
            // after 3 seconds the warning will disappear
            Invoke("WarningOff", 3);
        }
    }

    public void SellQuiver()
    {
        if (QuiverIsBought)
        {
            Coins += QuiverPrice;
            QuiverIsBought = false;
            QuiverBuyButton.SetActive(true);
            QuiverSellButton.SetActive(false);
            UpdateCoins();
        }
    }

    public void BuyJacket()
    {
         
        if (Coins >= JacketPrice)
        {
            Coins -= JacketPrice;
            JacketIsBought = true;
            JacketBuyButton.SetActive(false);
            JacketSellButton.SetActive(true);
            UpdateCoins();
        }
        else
        {
            NotEnoughCoins.gameObject.SetActive(true);
            // after 3 seconds the warning will disappear
            Invoke("WarningOff", 3);
        }
    }

    public void SellJacket()
    {
        if (JacketIsBought)
        {
            Coins += JacketPrice;
            JacketIsBought = false;
            JacketBuyButton.SetActive(true);
            JacketSellButton.SetActive(false);
            UpdateCoins();
        }
    }

    public void BuyGloves()
    {
        
        if (Coins >= GlovesPrice)
        {
            Coins -= GlovesPrice;
            GlovesIsBought = true;
            GlovesBuyButton.SetActive(false);
            GlovesSellButton.SetActive(true);
            UpdateCoins();
        }
        else
        {
            NotEnoughCoins.gameObject.SetActive(true);
            // after 3 seconds the warning will disappear
            Invoke("WarningOff", 3);
        }
    }

    public void SellGloves()
    {
        if (GlovesIsBought)
        {
            Coins += GlovesPrice;
            GlovesIsBought = false;
            GlovesBuyButton.SetActive(true);
            GlovesSellButton.SetActive(false);
            UpdateCoins();
        }
    }

    public void BuyShoes()
    {
         
        if (Coins >= ShoesPrice)
        {
            Coins -= ShoesPrice;
            ShoesIsBought = true;
            ShoesBuyButton.SetActive(false);
            ShoesSellButton.SetActive(true);
            UpdateCoins();
        }
        else
        {
            NotEnoughCoins.gameObject.SetActive(true);
            // after 3 seconds the warning will disappear
            Invoke("WarningOff", 3);
        }
    }

    public void SellShoes()
    {
        if (ShoesIsBought)
        {
            Coins += ShoesPrice;
            ShoesIsBought = false;
            ShoesBuyButton.SetActive(true);
            ShoesSellButton.SetActive(false);
            UpdateCoins();
        }
    }

    public void BuyDress()
    {
         
        if (Coins >= DressPrice)
        {
            Coins -= DressPrice;
            DressIsBought = true;
            DressBuyButton.SetActive(false);
            DressSellButton.SetActive(true);
            UpdateCoins();
        }
        else
        {
            NotEnoughCoins.gameObject.SetActive(true);
            // after 3 seconds the warning will disappear
            Invoke("WarningOff", 3);
        }
    }

    public void SellDress()
    {
        if (DressIsBought)
        {
            Coins += DressPrice;
            DressIsBought = false;
            DressBuyButton.SetActive(true);
            DressSellButton.SetActive(false);
            UpdateCoins();
        }
    }



}
