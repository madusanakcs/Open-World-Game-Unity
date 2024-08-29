using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Events;

public class ItemUI : MonoBehaviour
{
    [SerializeField] Image itemImage;
    [SerializeField] TMP_Text itemName;
    [SerializeField] TMP_Text itemPrice;
    [SerializeField] Button itemPurchaseButton;
    [SerializeField] Button itemSellButton;

    [Space(20f)]
    [SerializeField] Button itemButton;


    public void SetItemPosition(Vector2 position)
    {
        GetComponent<RectTransform>().anchoredPosition += position;
    }

    public void SetItemImage(Sprite sprite)
    {
        itemImage.sprite = sprite;
        itemImage.enabled = true;
    }

    public void SetItemName(string name)
    {
        itemName.text = name;
        itemName.enabled = true;
    }

    public void SetItemPrice(int price)
    {
        itemPrice.text = price.ToString();
        itemPrice.enabled = true;
    }

    public void SetItemAsPurchased()
    {
        itemPurchaseButton.gameObject.SetActive(false);
        itemSellButton.gameObject.SetActive(true);
        Image itemSellButtonImage = itemSellButton.GetComponent<Image>();
        itemSellButtonImage.enabled = true;
        Button itemSellBButton = itemSellButton.GetComponent<Button>();
        itemSellBButton.enabled = true;
        itemSellButton.interactable = true;
       
    }

    public void OnItemPurchase(int itemIndex, UnityAction<int> action)
    {
        itemSellButton.gameObject.SetActive(false);
        itemPurchaseButton.onClick.RemoveAllListeners();
        itemPurchaseButton.onClick.AddListener(() => action.Invoke(itemIndex));
    }

    public void SetItemAsSold()
    {
        itemPurchaseButton.gameObject.SetActive(true);
        itemSellButton.gameObject.SetActive(false);
        Image itemPurchaseButtonImage = itemPurchaseButton.GetComponent<Image>();
        itemPurchaseButtonImage.enabled = true;
        Button itemPurchaseBButton = itemPurchaseButton.GetComponent<Button>();
        itemPurchaseBButton.enabled = true;
        itemPurchaseButton.interactable = true;

    }


    public void OnItemSell(int itemIndex, UnityAction<int> action)
    {
        itemPurchaseButton.gameObject.SetActive(false);
        itemSellButton.onClick.RemoveAllListeners();
        itemSellButton.onClick.AddListener(() => action.Invoke(itemIndex));
    }

    


}
