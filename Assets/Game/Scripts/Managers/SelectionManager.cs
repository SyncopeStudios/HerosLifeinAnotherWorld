using System;
using Game.Scripts;
using Game.Scripts.Enemy;
using Game.Scripts.Extra;
using Unity.Cinemachine;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SelectionManager : Singelton<SelectionManager>
{
    public static event Action<EnemyBrain> OnEnemySelectedEvent;
    public static event Action OnNoSelectionEvent;

    [Header("Config")]
    [SerializeField] private LayerMask enemyMask;

    private Camera mainCamera;
    private CinemachineVirtualCamera cinemachineCamera;

    private void Awake()
    {

        base.Awake();
        DontDestroyOnLoad(gameObject);
        
        mainCamera = Camera.main;  // Assign camera on awake
        SceneManager.sceneLoaded += OnSceneLoaded;
        // Subscribe to scene load events
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        // Reassign the main camera whenever a new scene is loaded
        mainCamera = Camera.main;
        if (mainCamera == null)
        {
            Debug.LogError("Main camera is missing after scene load!");
        }
    }
    private void Start()
    {
        cinemachineCamera = FindObjectOfType<CinemachineVirtualCamera>(); // Find the Cinemachine Camera in the scene

        if (cinemachineCamera != null)
        {
            cinemachineCamera.Follow = Camera.main.transform; // Set the camera's follow target to the main camera's transform
        }
    }

    private void Update()
    {
        // Make sure the camera is still valid
        if (mainCamera == null)
        {
            mainCamera = Camera.main;  // Try reassigning the camera
            if (mainCamera == null)
            {
                Debug.LogError("Main camera is missing!");
                return;
            }
        }

        SelectEnemy();
    }

    private void SelectEnemy()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit2D hit = Physics2D.Raycast(
                mainCamera.ScreenToWorldPoint(Input.mousePosition),
                Vector2.zero, Mathf.Infinity, enemyMask);

            if (hit.collider != null)
            {
                EnemyBrain enemy = hit.collider.GetComponent<EnemyBrain>();
                if (enemy == null) return;

                EnemyHealth enemyHealth = enemy.GetComponent<EnemyHealth>();
                if (enemyHealth.CurrentHealth <= 0f)
                {
                    EnemyLoot enemyLoot = enemy.GetComponent<EnemyLoot>();
                    LootManager.Instance.ShowLoot(enemyLoot);
                }
                else
                {
                    OnEnemySelectedEvent?.Invoke(enemy);  // Trigger event if enemy selected
                }
            }
            else
            {
                OnNoSelectionEvent?.Invoke();  // Trigger event if no selection
            }
        }
    }

    private void OnDestroy()
    {
        // Unsubscribe from events to avoid memory leaks
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }
}

