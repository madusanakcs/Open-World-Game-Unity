using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore.Text;
using UnityEngine.UI;
using DG.Tweening;
using TMPro;
using static UnityEditor.Progress;

public class ShopUI : MonoBehaviour
{

    [Header("Layout Settings")]
    [SerializeField] float itemSpacing = .5f;
    float itemWidth;

    [Header("UI Elements")]
    //[SerializeField] Transform shopMenu;
    [SerializeField] Transform shopItemsContainerVegetables;
    [SerializeField] Transform shopItemsContainerAnimals;
    [SerializeField] Transform shopItemsContainerWeapons;
    [SerializeField] GameObject itemPrefab;

    [Space(20)]
    [SerializeField] ItemsShopDatabase itemsDB;


    [Header("Shop Events")]
    [SerializeField] GameObject shopUI;
    [SerializeField] Button openShopButton;
    [SerializeField] Button closeShopButton;

    [Header("Category Buttons")]
    [SerializeField] Button vegetablesButton;
    [SerializeField] Button animalsButton;
    [SerializeField] Button weaponsButton;

    [Header("Category Panels")]
    [SerializeField] GameObject vegetablesPanel;
    [SerializeField] GameObject animalsPanel;
    [SerializeField] GameObject weaponsPanel;

    [Space(20)]
    [Header("Error messages")]
    [SerializeField] TMP_Text noEnoughCoinsText;

    // Start is called before the first frame update
    void Start()
    {
        AddShopEvents();
        GenerateShopItemsUI();
        AssignCategoryEvents();
        ShowCategoryPanel("vegetables");
    }

    private void Update()
    {
        for (int i = 0; i < itemsDB.ItemsCount; i++)
        {
            Item item = itemsDB.GetItem(i);

            ItemUI uiItem = GetItemUI(i);

            if (item.isPurchased)
            {
                uiItem.SetItemAsPurchased();
                uiItem.OnItemSell(i, OnItemSold);
            }
            else
            {
                uiItem.SetItemPrice(item.price);
                uiItem.OnItemPurchase(i, OnItemPurchased);
            }
        }
    }

    void GenerateShopItemsUI()
    {

        for (int i = 0; i < GameDataManager.GetAllPurchasedItems().Count; i++)
        {
            int purchasedItemIndex = GameDataManager.GetPurchasedItem(i);
            itemsDB.PurchaseItem(purchasedItemIndex);
        }

        //detele item template after calculating item width
        itemWidth = shopItemsContainerVegetables.GetChild(0).GetComponent<RectTransform>().sizeDelta.x; 
        itemSpacing = itemSpacing * itemWidth;
        Destroy(shopItemsContainerVegetables.GetChild(0).gameObject);
        shopItemsContainerVegetables.DetachChildren();

        //generate items 
        for (int i=0;i<itemsDB.ItemsCount; i++)
        {
            Item item = itemsDB.GetItem(i);

            Transform targetContainer = null;
            switch (item.category)
            {
                case ItemCategory.Vegetables:
                    targetContainer = shopItemsContainerVegetables;
                    break;
                case ItemCategory.Animals:
                    targetContainer = shopItemsContainerAnimals;
                    break;
                case ItemCategory.Weapons:
                    targetContainer = shopItemsContainerWeapons;
                    break;
                default:
                    Debug.LogError("Unknown category: " + item.category);
                    continue;
            }

            ItemUI uiItem = Instantiate(itemPrefab, targetContainer).GetComponent<ItemUI>();

            //move to the position
            //uiItem.SetItemPosition(Vector2.right*i*(itemWidth+itemSpacing));
            int itemCount = targetContainer.childCount - 1; 
            uiItem.SetItemPosition(Vector2.right * itemCount * (itemWidth + itemSpacing));

            //set item in hierachy
            uiItem.gameObject.name = "Item" + i + "-" + item.name;

            uiItem.SetItemName(item.name);
            uiItem.SetItemImage(item.image);
            uiItem.SetItemPrice(item.price);

            Image uiItemImage = uiItem.GetComponent<Image>();
            uiItemImage.enabled = true;

            Button uiItemButton = uiItem.GetComponent<Button>();
            uiItemButton.enabled = true;

            MonoBehaviour uiItemScript = uiItem.GetComponent<MonoBehaviour>();
            uiItemScript.enabled = true;

            if (item.isPurchased)
            {
                uiItem.SetItemAsPurchased();
                uiItem.OnItemSell(i, OnItemSold);
            }
            else
            {
                uiItem.SetItemPrice(item.price);
                uiItem.OnItemPurchase(i, OnItemPurchased);
            }

            //resize items container
            
            ResizeContainer(targetContainer);
        }
    }

    void ResizeContainer(Transform container)
    {
        int itemCount = container.childCount-2;
        container.GetComponent<RectTransform>().sizeDelta = Vector2.right * (itemWidth + itemSpacing) * itemCount;
    }


    int GetTotalItems(Transform container)
    {
        return container.childCount;
    }

    ItemUI GetItemUI(int index)
    {
        int vegetablesCount = GetTotalItems(shopItemsContainerVegetables);
        int animalsCount = GetTotalItems(shopItemsContainerAnimals);
        int weaponsCount = GetTotalItems(shopItemsContainerWeapons);

        if (index < vegetablesCount)
        {
            return shopItemsContainerVegetables.GetChild(index).GetComponent<ItemUI>();
        }
        index -= vegetablesCount;

        if (index < animalsCount)
        {
            return shopItemsContainerAnimals.GetChild(index).GetComponent<ItemUI>();
        }
        index -= animalsCount;

        if (index < weaponsCount)
        {
            return shopItemsContainerWeapons.GetChild(index).GetComponent<ItemUI>();
        }

        Debug.LogError("Index out of range");
        return null;
    }

    void OnItemPurchased(int index)
    {
        Item item = itemsDB.GetItem(index);

        if (GameDataManager.CanSpendCoins(item.price))
        {
            //Proceed with the purchase operation
            GameDataManager.SpendCoins(item.price);
            ItemUI uiItem = GetItemUI(index);

            //Update Coins UI text
            GameSharedUI.Instance.UpdateCoinsUIText();

            //Update DB's Data
            itemsDB.PurchaseItem(index);

            uiItem.SetItemAsPurchased();

            //Add purchased item to Shop Data
            GameDataManager.AddPurchasedItem(index);

        }
        else
        {
            Debug.Log("NO enough coins...");
            AnimateNoMoreCoinsText();
        }
    }

    void AnimateNoMoreCoinsText()
    {
        // Complete animations (if it's running)
        noEnoughCoinsText.transform.DOComplete();
        noEnoughCoinsText.DOComplete();

        noEnoughCoinsText.transform.DOShakePosition(3f, new Vector3(5f, 0f, 0f), 10, 0);
        noEnoughCoinsText.DOFade(1f, 3f).From(0f).OnComplete(() => {
            noEnoughCoinsText.DOFade(0f, 1f);
        });

    }


    void OnItemSold(int index)
    {
        Item item = itemsDB.GetItem(index);
        GameDataManager.AddCoins(item.price);
        ItemUI uiItem = GetItemUI(index);

        //Update Coins UI text
        GameSharedUI.Instance.UpdateCoinsUIText();

        //Update DB's Data
        itemsDB.SellItem(index);

        uiItem.SetItemAsSold();
    }


   


    void AssignCategoryEvents()
    {
        vegetablesButton.onClick.RemoveAllListeners();
        vegetablesButton.onClick.AddListener(() => ShowCategoryPanel("vegetables"));

        animalsButton.onClick.RemoveAllListeners();
        animalsButton.onClick.AddListener(() => ShowCategoryPanel("animals"));

        weaponsButton.onClick.RemoveAllListeners();
        weaponsButton.onClick.AddListener(() => ShowCategoryPanel("weapons"));
    }

    void ShowCategoryPanel(string category)
    {
        // Deactivate all panels
        vegetablesPanel.SetActive(false);
        animalsPanel.SetActive(false);
        weaponsPanel.SetActive(false);

        // Activate the selected panel
        switch (category)
        {
            case "vegetables":
                vegetablesPanel.SetActive(true);
                break;
            case "animals":
                animalsPanel.SetActive(true);
                break;
            case "weapons":
                weaponsPanel.SetActive(true);
                break;
        }
    }

    void AddShopEvents()
    {
        openShopButton.onClick.RemoveAllListeners();
        openShopButton.onClick.AddListener(OpenShop);

        closeShopButton.onClick.RemoveAllListeners();
        closeShopButton.onClick.AddListener(CloseShop);
    }

    void OpenShop()
    {
        shopUI.SetActive(true);
    }

    void CloseShop()
    {
        shopUI.SetActive(false);
    }


    

}
