using System.Net.Mime;
using Game.Scripts.Extra;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class WeaponManager : Singelton<WeaponManager>
{
    [SerializeField] private Image weaponIcon;
    [SerializeField] private TextMeshProUGUI weaponManaTMP;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    public void EquipWeapon(Weapon weapon)
    {
        weaponIcon.sprite = weapon.Icon;
        weaponIcon.gameObject.SetActive(true);
        weaponManaTMP.text = weapon.RequiredMana.ToString();
        weaponManaTMP.gameObject.SetActive(true);
        if (GameManager.Instance == null)
        {
            // Attempt to find it in the scene if not already initialized
            GameManager instance = FindObjectOfType<GameManager>();
            if (instance == null)
            {
                // Log an error if GameManager is not found
                Debug.LogError("GameManager not found in the scene!");
                return;
            }

            GameManager.Instance = instance; // Set the instance if found
        }

        // Proceed to equip the weapon on the player's attack script
        GameManager.Instance.Player.playerAttack.EquipWeapon(weapon);
    }
}