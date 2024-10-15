using System;
using Game.Scripts.Extra;
using UnityEngine;

public class ShopManager : Singelton<ShopManager>
{

    [Header("Config")]
    [SerializeField] private ShopCard ShopCardPrefab;
    [SerializeField] private Transform shopContainer;

    [Header("Items")]
    [SerializeField] private ShopItem[] _items;

    private void Start()
    {
        LoadShop();
    }


    private void LoadShop()
    {

        for (int i = 0; i < _items.Length; i++)
        {
            ShopCard card = Instantiate(ShopCardPrefab, shopContainer);
            card.ConfigShopCard(_items[i]);
        }
        
        
    }

}
