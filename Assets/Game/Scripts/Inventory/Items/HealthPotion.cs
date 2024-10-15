using UnityEngine;

namespace Game.Scripts.Inventory.Items
{
    [CreateAssetMenu(fileName = "ItemHealthPotion", menuName = "Items/Health Potion")]
    public class HealthPotion : InventoryItem
    {

        [Header("Config")]
        public float HealthValue;

        public override bool UseItem()
        {
            if (GameManager.Instance.Player.playerHealth.CanRestoreHealth())
            {
                GameManager.Instance.Player.playerHealth.RestoreHealth(HealthValue);
                return true;
            }

            return false;

        }

    }
}