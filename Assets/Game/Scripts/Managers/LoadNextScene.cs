using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadNextScene : MonoBehaviour
{
    public string sceneToLoad; // Name of the scene to load

    // This method will be called when the player enters the trigger
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")) // Assuming the player has the "Player" tag
        {
            // Load the specified scene asynchronously
            SceneManager.LoadScene(sceneToLoad); 
        }
    }
}
