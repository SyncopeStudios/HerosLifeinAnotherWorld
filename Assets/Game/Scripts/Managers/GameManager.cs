using System;
using System.Collections;
using System.Collections.Generic;
using Game.Scripts.Extra;
using UnityEngine;

public class GameManager : Singelton<GameManager>
{

    [SerializeField] private Player player;

    public Player Player => player;

    private Transform currentSpawnPoint;

    private void Start()
    {
        SpawnPoint[] points = FindObjectsOfType<SpawnPoint>();
        foreach (var point in points)
        {
            SpawnManager.Instance.RegisterSpawnPoint(point);
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            player.ResetPlayer();
        }
    }

    // Method to set a new spawn point (call this when the scene changes or based on logic)
    public void SetSpawnPoint(Transform spawnPoint)
    {
        currentSpawnPoint = spawnPoint;
    }

    // Method to respawn the player at the spawn point
    public void RespawnPlayer()
    {
        if (currentSpawnPoint != null)
        {
            player.transform.position = currentSpawnPoint.position;
            player.transform.rotation = currentSpawnPoint.rotation;
        }
        else
        {
            Debug.LogWarning("No spawn point set!");
        }
    }

    public void AddPlayerExp(float expAmount)
    {
        PlayerExp playerExp = player.GetComponent<PlayerExp>();
        playerExp.AddExp(expAmount);
    }
}
