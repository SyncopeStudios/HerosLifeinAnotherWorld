using Unity.Cinemachine;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private CinemachineCamera virtualCam;
    private Transform playerTransform;

    private void Start()
    {
        // Attempt to find the player object (don't destroy on load player)
        FindPlayer();

        // Find the Cinemachine camera in the current scene
        virtualCam = FindObjectOfType<CinemachineCamera>();

        // Set the camera to follow the player if both are found
        if (virtualCam != null && playerTransform != null)
        {
            virtualCam.Follow = playerTransform;
        }
    }

    private void OnEnable()
    {
        // Subscribe to the scene change event
        UnityEngine.SceneManagement.SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDisable()
    {
        // Unsubscribe to the scene change event
        UnityEngine.SceneManagement.SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void OnSceneLoaded(UnityEngine.SceneManagement.Scene scene, UnityEngine.SceneManagement.LoadSceneMode mode)
    {
        // Update the virtual camera and player reference after a scene is loaded
        virtualCam = FindObjectOfType<CinemachineCamera>();

        // Try to find the player again in case it's not assigned
        if (playerTransform == null)
        {
            FindPlayer();
        }

        // Set the camera to follow the player
        if (virtualCam != null && playerTransform != null)
        {
            virtualCam.Follow = playerTransform;
        }
    }

    private void FindPlayer()
    {
        // Search for the player by tag (assuming the player has a "Player" tag)
        GameObject playerObject = GameObject.FindGameObjectWithTag("Player");

        if (playerObject != null)
        {
            playerTransform = playerObject.transform;
        }
        else
        {
            Debug.LogWarning("Player object not found in scene!");
        }
    }
}
