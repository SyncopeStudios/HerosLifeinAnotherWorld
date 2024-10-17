using System.Collections.Generic;
using Game.Scripts.Extra;
using UnityEngine;
using UnityEngine.SceneManagement;


public class SpawnManager : Singelton<SpawnManager>
{
 private SpawnPoint lastActiveSpawnPoint;
    [SerializeField] private List<SpawnPoint> spawnPoints = new List<SpawnPoint>();

    [SerializeField] private Player _player;
    // Call this method to register spawn points in the scene
    public void RegisterSpawnPoint(SpawnPoint point)
    {
        if (!spawnPoints.Contains(point))
        {
            spawnPoints.Add(point);
            SetActiveSpawnPoint(point);
        }
    }

    // Clear the list of spawn points (called when a new scene loads)
    public void ClearSpawnPoints()
    {
        spawnPoints.Clear();
        lastActiveSpawnPoint = null; // Reset the last active spawn point
    }

    // Choose a spawn point based on your criteria (random or specific)
    public void SetActiveSpawnPoint(SpawnPoint point)
    {
        if (lastActiveSpawnPoint != null)
        {
            SpawnPlayerAtPoint(_player);
            lastActiveSpawnPoint.SetActive(false);
        }

        point.SetActive(true);
        lastActiveSpawnPoint = point; // Save the last active spawn point
    }

    // Optional: Randomly set an active spawn point
    public void SetRandomSpawnPoint()
    {
        if (spawnPoints.Count > 0)
        {
            int randomIndex = Random.Range(0, spawnPoints.Count);
            SetActiveSpawnPoint(spawnPoints[randomIndex]);
        }
    }

    public void SpawnPlayerAtPoint(Player player)
    {
        if (lastActiveSpawnPoint != null)
        {
            lastActiveSpawnPoint.SpawnPlayer(player);
        }
        else
        {
            // Fallback: spawn at a default point or handle error
            Debug.LogWarning("No active spawn point available. Spawning at default location.");
            // Implement default spawn logic if needed
        }
    }

    // Subscribe to scene load event
    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    // Unsubscribe from scene load event
    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    // Callback when a new scene is loaded
    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        // Clear old spawn points
        ClearSpawnPoints();

        // Optionally find and re-register spawn points in the new scene
        SpawnPoint[] pointsInScene = FindObjectsOfType<SpawnPoint>();
        foreach (var point in pointsInScene)
        {
            RegisterSpawnPoint(point);
        }
    }
}