using System;
using System.Collections;
using System.Collections.Generic;
using Game.Scripts;
using UnityEngine;

public class PlayerHealth : MonoBehaviour, IDamagable
{

    [Header("Config")]
    [SerializeField] private PlayerStats stats;

    private PlayerAnimations playerAnimations;

    private void Awake()
    {
        playerAnimations = GetComponent<PlayerAnimations>();
    }

    private void Update()
    {
        if (stats.Health<=0f)
        {
            PlayerDead();
        }
    }


    public void TakeDamage(float amount)
    {
        if (stats.Health <= 0 ) return;
        stats.Health -= amount;
        DmgManager.Instance.ShowDamageText(amount,transform);
        if (stats.Health <= 0f)
        {
            PlayerDead();
        }
    }

    public void RestoreHealth(float amount)
    {

        stats.Health += amount;
        if (stats.Health > stats.MaxHealth)
        {
            stats.Health = stats.MaxHealth;
        }
        

    }

    public bool CanRestoreHealth()
    {
        return stats.Health > 0 && stats.Health < stats.MaxHealth;
    }

    private void PlayerDead()
    {
        playerAnimations.SetDeadAnimation();
    }
}
