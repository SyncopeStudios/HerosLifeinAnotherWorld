using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class ActionWander : FSMAction
{
    [Header("config")]
    [SerializeField] private float speed;
    [SerializeField] private float wanderTime;
    [SerializeField] private Vector2 moveRange;

    private Vector3 movePosition;
    private float Timer;
    
    public override void Act()
    {
        Timer -= Time.deltaTime;
        Vector3 moveDirecton = (movePosition - transform.position).normalized;
        Vector3 movement = moveDirecton * (speed * Time.deltaTime);

        if (Vector3.Distance(transform.position, movePosition) >= 0.5f)
        {
            transform.Translate(movement);
        }

        if (Timer<= 0f)
        {
            getNewDest();
            Timer = wanderTime;
        }

    }

    private void getNewDest()
    {

        float randomX = Random.Range(-moveRange.x, moveRange.x);
        float randomY = Random.Range(-moveRange.y, moveRange.y);

        movePosition = transform.position + new Vector3(randomX, randomY);
    }

    private void OnDrawGizmosSelected()
    {
        if (moveRange!=Vector2.zero)
        {
            
            Gizmos.color = Color.cyan;
            Gizmos.DrawWireCube(transform.position,moveRange * 2f);
            Gizmos.DrawLine(transform.position, movePosition);
            
        }
    }
}
