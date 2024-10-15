using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionChase : FSMAction
{

    [Header("config")]
    [SerializeField] private float chaseSpeed;

    private EnemyBrain _enemyBrain;

    private void Awake()
    {
        _enemyBrain = GetComponent<EnemyBrain>();
    }

    public override void Act()
    {
        chasePlayer();
    }

    private void chasePlayer()
    {
        
        if(_enemyBrain.player == null) return;

        Vector3 dirToPlayer = _enemyBrain.player.position - transform.position;
        if (dirToPlayer.magnitude >= 1.3f )
        {
            transform.Translate(dirToPlayer.normalized * (chaseSpeed * Time.deltaTime));
            
        }

    }
}
