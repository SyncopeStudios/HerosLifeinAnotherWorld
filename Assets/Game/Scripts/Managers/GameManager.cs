using System;
using System.Collections;
using System.Collections.Generic;
using Game.Scripts.Extra;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class GameManager : Singelton<GameManager>
{
    [SerializeField] private Player player;
    [SerializeField] private AudioManagerData audioManagerData; // Reference to ScriptableObject

    public UnityEvent OnPlayerSpawned = new UnityEvent();
    public Player Player => player;

    private Dictionary<string, AudioClip> sceneAudioClips = new Dictionary<string, AudioClip>();

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        LoadAudioClips();
        SpawnPoint[] points = FindObjectsOfType<SpawnPoint>();
        foreach (var point in points)
        {
            SpawnManager.Instance.RegisterSpawnPoint(point);
        }

        
        PlayMusicForCurrentScene();
    }
    public void AddPlayerExp(float expAmount)
    {
        PlayerExp playerExp = player.GetComponent<PlayerExp>();
        playerExp.AddExp(expAmount);
    }

    private void LoadAudioClips()
    {
        foreach (var clip in audioManagerData.sceneAudioClips)
        {
            sceneAudioClips[clip.sceneName] = clip.AudioClip;
        }
    }

    public void PlayerSpawned(Player player)
    {
        this.player = player;
        OnPlayerSpawned?.Invoke();

    }

    private void PlayMusicForCurrentScene()
    {
        string currentSceneName = SceneManager.GetActiveScene().name;

        if (sceneAudioClips.TryGetValue(currentSceneName, out AudioClip clip))
        {
            AudioManager.Instance.PlayMusic(clip);
        }
        else
        {
            Debug.LogWarning($"No music clip found for scene: {currentSceneName}");
        }
    }
}
