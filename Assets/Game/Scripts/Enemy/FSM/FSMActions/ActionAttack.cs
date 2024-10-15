using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class ActionAttack : FSMAction
{
    [Header("config")] 
    [SerializeField] private float damage;

    [SerializeField] private float attackTime;

    private EnemyBrain _enemyBrain;
    private float timer;

    private void Awake()
    {
        _enemyBrain = GetComponent<EnemyBrain>();
    }

    public override void Act()
    {
         AttackPlayer();
    }

    private void AttackPlayer()
    {
        
        if(_enemyBrain.player == null) return;

        timer -= Time.deltaTime;
        if (timer <= 0f)
        {
            IDamagable player = _enemyBrain.player.GetComponent<IDamagable>();
            player.TakeDamage(damage);
            timer = attackTime;
        }

    }

}

