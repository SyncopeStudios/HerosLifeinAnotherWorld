

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Game.Scripts.Extra;
using Unity.VisualScripting;
using UnityEngine;

public class CheckPointSystem :Singelton<CheckPointSystem>
{
    
    [SerializeField] private Player player;
    [SerializeField] private SaveCheckPointIcon savingIcon;

    private Checkpoint _lastCheckpoint;

    private void Awake()
    {

        Respawn();
    }

    public void SaveCheckpoint(Checkpoint savePoint)
    {
        _lastCheckpoint = savePoint;
        PlayerPrefs.SetFloat("checkpointX", savePoint.spawnPosition.position.x);
        PlayerPrefs.SetFloat("checkpointY", savePoint.spawnPosition.position.y);
    }

    public void Respawn()
    {
        if (PlayerPrefs.HasKey("checkpointX") && PlayerPrefs.HasKey("checkpointY"))
        {
            Vector2 checkpointPos = new Vector2(PlayerPrefs.GetFloat("checkpointX"), PlayerPrefs.GetFloat("checkpointY"));
            player.transform.position = checkpointPos;
        }
    }

    public void SetPlayer(Player nell) {
        player = nell;
    }

    public void ForceGrabValues()
    {
        // TODO: Really bad, @alvin fix ASAP
        player = FindFirstObjectByType<Player>();
        savingIcon = FindFirstObjectByType<SaveCheckPointIcon>();
    }


   
}

