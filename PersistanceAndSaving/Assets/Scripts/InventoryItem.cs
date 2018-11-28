using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class InventoryItem
{

    public int ID;
    public string Name;
    public string Description;
    public float value;
    public float weight;
    public int Quantity;
    public ItemRarity Rarity;
}

public enum ItemRarity
{
    Common,
    Rare,
    Exotic,
    Legendary
}

[Serializable]
public class InventoryList
{
    public List<InventoryItem> Items;
    public InventoryList()
    {
        Items = new List<InventoryItem>();
    }
}