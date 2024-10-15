using System.Net.Mime;
using Game.Scripts.Extra;
using TMPro;
using UnityEngine;
using UnityEngine.UI;



public class WeaponManager : Singelton<WeaponManager>
{
    [SerializeField] private Image weaponIcon;
    [SerializeField] private TextMeshProUGUI weaponManaTMP;

    public void EquipWeapon(Weapon weapon)
    {
        weaponIcon.sprite = weapon.Icon;
        weaponIcon.gameObject.SetActive(true);
        weaponManaTMP.text = weapon.RequiredMana.ToString();
        weaponManaTMP.gameObject.SetActive(true);
        GameManager.Instance.Player.playerAttack.EquipWeapon(weapon);

    }

}
