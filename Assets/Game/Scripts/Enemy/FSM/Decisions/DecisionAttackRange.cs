using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DecisionAttackRange : FSMDecision
{
    [Header("Config")]
    [SerializeField] private float range;
    [SerializeField] private LayerMask playerMask;


    private EnemyBrain enemy;

    private void Awake()
    {
        enemy = GetComponent<EnemyBrain>();
    }
    public override bool Decide()
    {
        return PlayerInAttackRange();
    }

    private bool PlayerInAttackRange()
    {

        if (enemy.player==null)
        {
            return false;
        }
        Collider2D playerCollider = Physics2D.OverlapCircle(enemy.transform.position, range, playerMask);
        if (playerCollider!= null)
        {
            return true;
        }

        return false;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, range);
        
    }
}
