using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore.Text;

[CreateAssetMenu(fileName ="ItemsShopDatabase",menuName = "Shopping/Items shop databse")]
public class ItemsShopDatabase : ScriptableObject
{
    public Item[] items;

    public int ItemsCount
    {
        get
        {
            return items.Length;
        }
    }

    public Item GetItem(int index)
    {
        return items[index];
    }


    public void PurchaseItem(int index)
    {
        items[index].isPurchased = true;
    }

    public void SellItem(int index)
    {
        items[index].isPurchased=false;
    }
}
