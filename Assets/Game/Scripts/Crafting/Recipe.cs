using System;
using UnityEngine;

[Serializable]
public class Recipe
{

    public string Name;
    [Header("Item 1")]
    public InventoryItem item1;
    public int item1Amount;

    [Header("Item 2")]
    public InventoryItem item2;
    public int item2Amount;

    [Header("Item fianl")]
    public InventoryItem itemfinal;
    public int itemfinalAmount;
}
