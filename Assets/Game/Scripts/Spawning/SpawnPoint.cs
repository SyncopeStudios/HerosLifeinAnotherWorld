using UnityEngine;


    public class SpawnPoint : MonoBehaviour
    {
        [SerializeField] private bool isActive = true;

        // You could store a reference to the player to spawn them here
        public void SpawnPlayer(Player player)
        {
            if (isActive)
            {
                player.transform.position = transform.position;
                Debug.Log("Player spawned at: " + transform.position);
            }
        }

        public bool IsActive() => isActive;

        public void SetActive(bool activeStatus)
        {
            isActive = activeStatus;
        }
        
    }
