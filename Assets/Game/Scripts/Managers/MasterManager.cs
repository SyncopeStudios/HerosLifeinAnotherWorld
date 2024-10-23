using System;
using Game;
using Game.Scripts;
using Game.Scripts.Extra;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MasterManager : Singelton<MasterManager>
{
    public Inventory inventoryManager;
    public AudioManager audioManager;
    public UIManager uiManager;
    public CoinManager coinManager;
    public CraftingManager craftingManager;
    public DialogueManager dialogueManager;
    public DmgManager dmgManager;
    public GameManager gameManager;
    public LootManager lootManager;
    public QuestManager questManager;
    public SceneHandlerManager sceneHandlerManager;
    public SelectionManager selectionManager;
    public ShopManager shopManager;
    public SpawnManager spawnManager;
    public GameObject canvasHUD; // Add this line for the Canvas HUD

    public void Update()
    {
        
        
        // Assign the canvasHUD if not manually assigned via inspector
        if (canvasHUD == null)
            canvasHUD = FindObjectOfType<Canvas>().gameObject; // Ensure there's a Canvas in the scene

        // Get references to your managers if not manually assigned via inspector
        if (inventoryManager == null)
            inventoryManager = FindObjectOfType<Inventory>();

        if (audioManager == null)
            audioManager = FindObjectOfType<AudioManager>();

        if (uiManager == null)
            uiManager = FindObjectOfType<UIManager>();

        if (coinManager == null)
            coinManager = FindObjectOfType<CoinManager>();

        if (craftingManager == null)
            craftingManager = FindObjectOfType<CraftingManager>();

        if (dialogueManager == null)
            dialogueManager = FindObjectOfType<DialogueManager>();

        if (dmgManager == null)
            dmgManager = FindObjectOfType<DmgManager>();

        if (gameManager == null)
            gameManager = FindObjectOfType<GameManager>();

        if (lootManager == null)
            lootManager = FindObjectOfType<LootManager>();

        if (questManager == null)
            questManager = FindObjectOfType<QuestManager>();

        if (sceneHandlerManager == null)
            sceneHandlerManager = FindObjectOfType<SceneHandlerManager>();

        if (selectionManager == null)
            selectionManager = FindObjectOfType<SelectionManager>();

        if (shopManager == null)
            shopManager = FindObjectOfType<ShopManager>();

        if (spawnManager == null)
            spawnManager = FindObjectOfType<SpawnManager>();

        // Subscribe to scene change event
        SceneManager.activeSceneChanged += OnSceneChanged;
    }

    private void OnDestroy()
    {
        // Unsubscribe from scene change event to avoid memory leaks
        SceneManager.activeSceneChanged -= OnSceneChanged;
    }

    // This is called when the active scene is changed
    private void OnSceneChanged(Scene oldScene, Scene newScene)
    {
        // Move all managers to the new scene
        MoveManagersToScene(newScene);
    }

    private void MoveManagersToScene(Scene newScene)
    {
        if (inventoryManager != null)
            SceneManager.MoveGameObjectToScene(inventoryManager.gameObject, newScene);

        if (audioManager != null)
            SceneManager.MoveGameObjectToScene(audioManager.gameObject, newScene);

        if (uiManager != null)
            SceneManager.MoveGameObjectToScene(uiManager.gameObject, newScene);

        if (coinManager != null)
            SceneManager.MoveGameObjectToScene(coinManager.gameObject, newScene);

        if (craftingManager != null)
            SceneManager.MoveGameObjectToScene(craftingManager.gameObject, newScene);

        if (dialogueManager != null)
            SceneManager.MoveGameObjectToScene(dialogueManager.gameObject, newScene);

        if (dmgManager != null)
            SceneManager.MoveGameObjectToScene(dmgManager.gameObject, newScene);

        if (gameManager != null)
            SceneManager.MoveGameObjectToScene(gameManager.gameObject, newScene);

        if (lootManager != null)
            SceneManager.MoveGameObjectToScene(lootManager.gameObject, newScene);

        if (questManager != null)
            SceneManager.MoveGameObjectToScene(questManager.gameObject, newScene);

        if (sceneHandlerManager != null)
            SceneManager.MoveGameObjectToScene(sceneHandlerManager.gameObject, newScene);

        if (selectionManager != null)
            SceneManager.MoveGameObjectToScene(selectionManager.gameObject, newScene);

        if (shopManager != null)
            SceneManager.MoveGameObjectToScene(shopManager.gameObject, newScene);

        if (spawnManager != null)
            SceneManager.MoveGameObjectToScene(spawnManager.gameObject, newScene);

        // Move the canvas HUD to the new scene
        if (canvasHUD != null)
            SceneManager.MoveGameObjectToScene(canvasHUD, newScene);
    }
}