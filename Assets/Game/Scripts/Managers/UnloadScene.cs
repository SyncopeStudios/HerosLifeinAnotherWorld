using UnityEngine;
using UnityEngine.SceneManagement;

public class UnloadScene : MonoBehaviour
{
    public string sceneToUnload; // Name of the scene to unload

    // This method will be called when the player enters the trigger
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")) // Assuming the player has the "Player" tag
        {
            // Get the scene you want to unload by name
            Scene scene = SceneManager.GetSceneByName(sceneToUnload);

            // Check if the scene is valid and loaded
            if (scene.IsValid() && scene.isLoaded)
            {
                // Unload the scene if it's not the current active scene
                if (scene.name != SceneManager.GetActiveScene().name)
                {
                    SceneManager.UnloadSceneAsync(sceneToUnload);
                }
                else
                {
                    Debug.LogWarning("Cannot unload the active scene!");
                }
            }
            else
            {
                Debug.LogWarning("Scene " + sceneToUnload + " is not loaded or doesn't exist!");
            }
        }
    }
}