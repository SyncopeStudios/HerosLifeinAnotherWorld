using System;
using UnityEngine;

public class FishingRod : MonoBehaviour
{
  [SerializeField] private PlayerMovement playerMovement; // Reference to the PlayerMovement script
    [SerializeField] private Transform playerTransform; // Reference to the player's Transform
    [SerializeField] private Vector3 offset = new Vector3(0.5f, 0, 0); // Adjust the offset for positioning

    private Vector3 originalScale;

    private void Start()
    {
        originalScale = transform.localScale; // Store the original scale
    }

    void Update()
    {
        AdjustFishingRodDirectionAndPosition();
    }

    private void AdjustFishingRodDirectionAndPosition()
    {
        Vector2 moveDirection = playerMovement.MoveDirection;

        if (moveDirection == Vector2.zero)
        {
            return; // No movement, do nothing
        }

        
        // Adjust local position based on movement direction
        Vector3 localPosition = Vector3.zero;

        if (moveDirection.x > 0) // Right
        {
            transform.localScale = new Vector3(originalScale.x, originalScale.y, originalScale.z); // Normal scale
            transform.rotation = Quaternion.Euler(0, 0, 0); // Face right
            localPosition = new Vector3(0.5f, 0, 0); // Position rod on the right side
        }
        else if (moveDirection.x < 0) // Left
        {
            transform.localScale = new Vector3(-originalScale.x, originalScale.y, originalScale.z); // Flip horizontally
            transform.rotation = Quaternion.Euler(0, 0, 0); // Face left
            localPosition = playerTransform.position + new Vector3(-0.5f, 0, 0); // Position rod on the left side
        }
        else if (moveDirection.y > 0) // Up
        {
            transform.localScale = originalScale; // Normal scale
            transform.rotation = Quaternion.Euler(0, 0, 90); // Face up
            localPosition = new Vector3(0, 0.5f, 0); // Position rod above the player
        }
        else if (moveDirection.y < 0) // Down
        {
            transform.localScale = originalScale; // Normal scale
            transform.rotation = Quaternion.Euler(0, 0, -90); // Face down
            localPosition = new Vector3(0, -0.5f, 0); // Position rod below the player
        }

        // Update the local position of the rod relative to the player
        transform.localPosition = localPosition;
    }
}
