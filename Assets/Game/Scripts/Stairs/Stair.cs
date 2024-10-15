using UnityEngine;

public class Stair : MonoBehaviour
{
    public float stairSpeedMultiplier = 1.5f; // Adjust speed while on stairs
    private float defaultSpeed;
    
    private PlayerMovement playerMovement; // Reference to the player's movement script

    void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the player enters the stairs
        if (other.CompareTag("Player"))
        {
            playerMovement = other.GetComponent<PlayerMovement>();
            if (playerMovement != null)
            {
                defaultSpeed = playerMovement.speed;
                playerMovement.speed *= stairSpeedMultiplier; // Increase speed
            }
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        // Reset speed when the player leaves the stairs
        if (other.CompareTag("Player") && playerMovement != null)
        {
            playerMovement.speed = defaultSpeed;
        }
    }
}
