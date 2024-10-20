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
    [SerializeField] private LayerMask waterLayer;  // Define which layer water belongs to
    [SerializeField] private float waterCheckRadius = 0.5f; // Radius for water check

    private Vector3 movePosition;
    private float Timer;

    public override void Act()
    {
        Timer -= Time.deltaTime;
        Vector3 moveDirection = (movePosition - transform.position).normalized;
        Vector3 movement = moveDirection * (speed * Time.deltaTime);

        if (Vector3.Distance(transform.position, movePosition) >= 0.5f)
        {
            transform.Translate(movement);
        }

        if (Timer <= 0f)
        {
            getNewDest();
            Timer = wanderTime;
        }
    }

    private void getNewDest()
    {
        bool foundSafeDest = false;

        while (!foundSafeDest)
        {
            // Generate a random destination within the move range
            float randomX = Random.Range(-moveRange.x, moveRange.x);
            float randomY = Random.Range(-moveRange.y, moveRange.y);
            movePosition = transform.position + new Vector3(randomX, randomY);

            // Check if the random destination is in water using an overlap circle
            Collider2D waterCheck = Physics2D.OverlapCircle(movePosition, waterCheckRadius, waterLayer);

            // If no water is detected, accept the new destination
            if (waterCheck == null)
            {
                foundSafeDest = true;
            }
            else
            {
                // Optionally log or handle if the destination was in water
                Debug.Log("Detected water at new destination. Picking a new one...");
            }
        }
    }

    private void OnDrawGizmosSelected()
    {
        if (moveRange != Vector2.zero)
        {
            Gizmos.color = Color.cyan;
            Gizmos.DrawWireCube(transform.position, moveRange * 2f);
            Gizmos.DrawLine(transform.position, movePosition);
        }
        
        // Draw the water check radius at the current move position
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(movePosition, waterCheckRadius);
    }
}
