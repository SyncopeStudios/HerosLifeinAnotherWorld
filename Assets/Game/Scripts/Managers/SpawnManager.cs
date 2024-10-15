using System.Collections.Generic;
using Game.Scripts.Extra;
using UnityEngine;



public class SpawnManager : Singelton<SpawnManager>
{
    private SpawnPoint lastActiveSpawnPoint;
   [SerializeField] private List<SpawnPoint> spawnPoints = new List<SpawnPoint>();

    // Call this method to register spawn points in the scene
    public void RegisterSpawnPoint(SpawnPoint point)
    {
        if (!spawnPoints.Contains(point))
        {
            spawnPoints.Add(point);
        }
    }

    // Choose a spawn point based on your criteria (random or specific)
    public void SetActiveSpawnPoint(SpawnPoint point)
    {
        if (lastActiveSpawnPoint != null)
        {
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
}