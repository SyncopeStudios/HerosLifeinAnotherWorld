using UnityEngine;

[CreateAssetMenu(menuName = "Items/Weapon", fileName = "ItemWeapon" )]
public class ItemWeapon : InventoryItem
{
    [Header("Weapon")] 
    public Weapon weapon;
    
    public override void EquipItem()
    {
        WeaponManager.Instance.EquipWeapon(weapon);
    }
}
