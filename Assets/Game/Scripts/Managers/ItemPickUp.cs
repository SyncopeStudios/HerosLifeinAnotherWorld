using System;
using Game.Scripts;
using UnityEngine;

public class ItemPickUp : MonoBehaviour
{

    [SerializeField] private InventoryItem _item;

    public int Quantity;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            CoinManager.Instance.AddCoins(Quantity);
            Destroy(gameObject);
        }
    }
}
