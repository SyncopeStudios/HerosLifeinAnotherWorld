
    using UnityEngine;
    using UnityEngine.SceneManagement;

    public class CanvasCamera: MonoBehaviour
    {
        public Canvas worldSpaceCanvas; // Assign the Canvas from the Inspector or find it dynamically
        private Camera mainCamera;

        private void Start()
        {
            // Find the main camera in the scene (tagged as MainCamera)
            FindMainCamera();
        
            // Assign the camera to the Canvas
            AssignCameraToCanvas();
        }

        private void OnEnable()
        {
            // Listen for scene changes
            SceneManager.sceneLoaded += OnSceneLoaded;
        }

        private void OnDisable()
        {
            // Unsubscribe from the scene loaded event
            SceneManager.sceneLoaded -= OnSceneLoaded;
        }

        private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
        {
            // Find the new main camera when the scene changes
            FindMainCamera();

            // Re-assign the camera to the Canvas
            AssignCameraToCanvas();
        }

        private void FindMainCamera()
        {
            // Find the camera tagged "MainCamera" in the new scene
            mainCamera = Camera.main;

            if (mainCamera == null)
            {
                Debug.LogWarning("Main Camera not found!");
            }
        }

        private void AssignCameraToCanvas()
        {
            if (worldSpaceCanvas != null && mainCamera != null)
            {
                // Assign the camera to the Canvas
                worldSpaceCanvas.worldCamera = mainCamera;
            }
            else
            {
                Debug.LogWarning("Canvas or Camera is missing!");
            }
        }
    }