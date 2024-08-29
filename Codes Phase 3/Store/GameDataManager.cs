using System.Collections.Generic;
using UnityEngine.TextCore.Text;

//Shop Data Holder
[System.Serializable]
public class ItemsShopData
{
    public List<int> purchasedItemsIndexes = new List<int>();
}

//Player Data Holder
[System.Serializable] 
public class PlayerData1
{
    public int coins = 20;
}

public static class GameDataManager
{
    static PlayerData1 playerData = new PlayerData1();
    static ItemsShopData itemsShopData = new ItemsShopData();

    static GameDataManager()
    {
        LoadPlayerData();
    }

    public static int GetCoins()
    {
        return playerData.coins;
    }

    public static void AddCoins(int amount)
    {
        playerData.coins += amount;
        SavePlayerData();
    }

    public static bool CanSpendCoins(int amount)
    {
        return (playerData.coins >= amount);
    }

    public static void SpendCoins(int amount)
    {
        playerData.coins -= amount;
        SavePlayerData();
    }

    static void LoadPlayerData()
    {
        playerData = BinarySerializer.Load<PlayerData1>("player-data.txt");
        UnityEngine.Debug.Log("[PlayerData] Loaded.");
    }

    static void SavePlayerData()
    {
        BinarySerializer.Save(playerData, "player-data.txt");
        UnityEngine.Debug.Log("[PlayerData] Saved.");
    }

    //Items Shop Data Methods -----------------------------------------------------------------------------
    public static void AddPurchasedItem(int itemIndex)
    {
        itemsShopData.purchasedItemsIndexes.Add(itemIndex);
        SaveItemsShopData();
    }

    public static List<int> GetAllPurchasedItems()
    {
        return itemsShopData.purchasedItemsIndexes;
    }

    public static int GetPurchasedItem(int index)
    {
        return itemsShopData.purchasedItemsIndexes[index];
    }

    static void LoadItemsShopData()
    {
        itemsShopData = BinarySerializer.Load<ItemsShopData>("itemss-shop-data.txt");
        UnityEngine.Debug.Log("[ItemsShopData] Loaded.");
    }

    static void SaveItemsShopData()
    {
        BinarySerializer.Save(itemsShopData, "items-shop-data.txt");
        UnityEngine.Debug.Log("[ItemsShopData] Saved");
    }
}