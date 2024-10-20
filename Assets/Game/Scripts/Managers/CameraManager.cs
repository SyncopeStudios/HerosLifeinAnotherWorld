using Game.Scripts.Extra;
using Unity.Cinemachine;
using UnityEngine;
using UnityEngine.SceneManagement;


public class CameraManager : Singelton<CameraManager>
{
    public GameObject cinemachineCameraPrefab; // Prefab of the Cinemachine camera

    void Start()
    {
        CreateCinemachineCamera();
        SceneManager.sceneLoaded += OnSceneLoaded; // Subscribe to scene loaded event
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        CreateCinemachineCamera(); // Create a new camera when a new scene is loaded
    }

    void CreateCinemachineCamera()
    {
        if (cinemachineCameraPrefab != null)
        {
            GameObject newCamera = Instantiate(cinemachineCameraPrefab); // Instantiate the prefab
            CinemachineVirtualCamera vCam = newCamera.GetComponent<CinemachineVirtualCamera>();

            if (vCam != null)
            {
                // You can configure the camera settings here if needed
                vCam.Follow = GameObject.FindWithTag("Player").transform; // Assume there's a player with "Player" tag
            }
        }
        else
        {
            Debug.LogError("Cinemachine camera prefab is not assigned.");
        }
    }

    private void OnDestroy()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded; // Unsubscribe when the object is destroyed
    }
}