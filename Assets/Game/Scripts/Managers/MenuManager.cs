using System.Collections.Generic;
using Game.Scripts.Extra;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : Singelton<MenuManager>
{

    
    [SerializeField] private List<GameObject> menus;

    private void Awake()
    {
        base.Awake();
        if (MenuManager.Instance == null)
        {
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }


    public void SaveGame()
    {
        // Get the active scene's name or build index
        string currentScene = SceneManager.GetActiveScene().name;

        // Save the current scene name to PlayerPrefs
        PlayerPrefs.SetString("SavedScene", currentScene);
        
        // Save any other necessary game data here
        PlayerPrefs.Save();
        
        Debug.Log("Game saved in scene: " + currentScene);
    }
    public void ContinueGame()
    {
        // Check if a saved scene exists in PlayerPrefs
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
            Debug.LogWarning("No saved game found! Starting a new game.");
            // Optionally, load a default or starting scene here
            SceneManager.LoadScene("FirstScene"); // Replace with your actual first scene name
        }
    }
    public void OpenMenu(GameObject menuToOpen)
    {

        foreach (var menu in menus)
        {
            
            menu.SetActive(false);
            
        }
        
        menuToOpen.SetActive(true);
    }

    public void CloseAllMenus()
    {

        foreach (var menu in menus)
        {
            
            menu.SetActive(false);
            
        }
        
    }

    public void AddMenu(GameObject menu)
    {
        if (!menus.Contains(menu))
        {
            menus.Add(menu);
        }
        
    }

    public void RemoveMenu(GameObject menu)
    {
        if (menus.Contains(menu))
        {
            menus.Remove(menu);
        }
    }
}
