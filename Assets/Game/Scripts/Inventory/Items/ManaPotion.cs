using UnityEngine;

namespace Game.Scripts.Inventory.Items
{
    [CreateAssetMenu(fileName = "ItemManaPotion", menuName = "Items/Mana Potion")]
    public class ManaPotion : InventoryItem
    {
        
        [Header("Config")]
        public float manaValue;

        public override bool UseItem()
        {

            if (GameManager.Instance.Player.mana.CanRecoverMana())
            {
                GameManager.Instance.Player.mana.RecoverMana(manaValue);
                return true;
            }

            return false;

        }

    }
}