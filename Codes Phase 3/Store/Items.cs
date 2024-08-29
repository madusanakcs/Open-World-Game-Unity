using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct Item
{
    public Sprite image;
    public string name;
    public int price;
    public bool isPurchased;
    public ItemCategory category;
}

public enum ItemCategory
{
    Vegetables,
    Animals,
    Weapons
}