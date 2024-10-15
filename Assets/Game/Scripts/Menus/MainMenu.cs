using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
   [SerializeField] private Player player;
    private void Start()
    {
        MenuManager.Instance.AddMenu(gameObject);
    }

    public void StartGame()
    {
        Scene currentScene = SceneManager.GetActiveScene();
    
        // Get the build index of the current scene and add 1
        int nextSceneIndex = currentScene.buildIndex + 1;
    
        // Check if the next scene index is valid (within bounds of available scenes)
        if (nextSceneIndex < SceneManager.sceneCountInBuildSettings)
        {
            // Load the next scene
            SceneManager.LoadScene(nextSceneIndex);
           
            Debug.Log("Loading scene at index: " + nextSceneIndex);
        }
        else
        {
            Debug.LogWarning("No more scenes to load, this is the last scene!");
        }
    }

    public void ContinueGame()
    {   // Check if a saved scene exists in PlayerPrefs
        if (PlayerPrefs.HasKey("SavedScene"))
        {
            // Retrieve the saved scene name
            string savedScene = PlayerPrefs.GetString("SavedScene");

            // Load the saved scene
            SceneManager.LoadScene(savedScene);
            Debug.Log("Loaded saved scene: " + savedScene);
        }
        else
        {
            Debug.Log("No saved game found.");
            // Optionally, load a default starting scene
        }
    }
    public void QuitGame()
    {
        // Exit the game
        Application.Quit();
    }

    private void OnDestroy()
    {
        MenuManager.Instance.RemoveMenu(gameObject);  // Clean up when destroyed
    }
}
