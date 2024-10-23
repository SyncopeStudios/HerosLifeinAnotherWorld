using System;
using System.Collections;
using System.Collections.Generic;
using BayatGames.SaveGameFree;
using Game.Scripts.Extra;
using Game.Scripts.Player;
using PixelCrushers.DialogueSystem;
using TMPro.EditorUtilities;
using UnityEngine;
using Random = UnityEngine.Random;

public class Player : MonoBehaviour
{  [Header("Config")]
    [SerializeField] private PlayerStats stats;

    public Animator PlayerAnim;
    public bool isFishing;
    public bool poleBack;
    public bool throwBobber;
    public Transform fishingPoint;
    public GameObject bobber;

    public float targetTime = 0.0f;
    public float savedTargetTime;
    public float extraBobberDistance;

    public InventoryItem item;
    public int quantity = 1;
    public GameObject fishGame;

    public float TimeTillCatch = 0.0f;
    public bool winnerAnim;
    public PlayerStats Stats => stats;

    public PlayerMana mana { get; set; }
    
    private PlayerAnimations animations;

    public PlayerHealth playerHealth { get; private set; }

    public PlayerAttack playerAttack { get; private set; }

    private void Start()
    {
        isFishing = false;
        fishGame.SetActive(false);
        throwBobber = false;
        targetTime = 0.0f;
        savedTargetTime = 0.0f;
        extraBobberDistance = 0.0f;
                                                
    }

    private void Awake()
    {
        
       
        animations = GetComponent<PlayerAnimations>();
        playerHealth = GetComponent<PlayerHealth>();
        mana = GetComponent<PlayerMana>();
        playerAttack = GetComponent<PlayerAttack>();
    }

    private void Update()
    {
        int random = GenerateRandomNumber();
        if (Input.GetKeyDown(KeyCode.F) && isFishing == false && winnerAnim == false)
        {
            poleBack = true;
            
        }

        if (isFishing == true)
        {
            

            TimeTillCatch += Time.deltaTime;
            if (TimeTillCatch >= 3.0f)
            {
                fishGame.SetActive(true);
                
            }

        }

        if (Input.GetKeyUp(KeyCode.F) && isFishing == false & winnerAnim == false)
        {

            poleBack = false;
            isFishing = true;
            throwBobber = true;
            if (targetTime >= 3.0f)
            {
                extraBobberDistance += 3.0f;
            }
            else
            {
                extraBobberDistance += targetTime;
            }

        }

        Vector3 temp = new Vector3(extraBobberDistance, 0, 0);

        fishingPoint.transform.position += temp;

        if (poleBack == true)
        {
            PlayerAnim.Play("Swing");
            savedTargetTime = targetTime;
            targetTime += Time.deltaTime;
        }

        if (isFishing==true)
        {
            if (throwBobber==true)
            {
                Instantiate(bobber, fishingPoint.position, fishingPoint.rotation, transform);
                fishingPoint.transform.position -= temp;
                throwBobber = false;
                targetTime = 0.0f;
                savedTargetTime = 0.0f;
                extraBobberDistance = 0.0f;

            }
            PlayerAnim.Play("herofishing");
        }

        if (Input.GetKeyDown(KeyCode.P) && TimeTillCatch <= 3)
        {
            poleBack = false;
            throwBobber = false;
            isFishing = false;
            TimeTillCatch = 0;
        }
    }

    public void FishGameWon()
    {
       
      
        PlayerAnim.Play("WonFish");
        //fishGame.SetActive(false);
        poleBack = false;
        throwBobber = false;
        isFishing = false;
        TimeTillCatch = 0;
        Inventory.Instance.AddItem( item, quantity );
        
    }
    public void FishGameLossed()
    {
        PlayerAnim.Play("hero_Idledown");
        fishGame.SetActive(false);
        poleBack = false;
        throwBobber = false;
        isFishing = false;
        TimeTillCatch = 0;
        
    }

    public int GenerateRandomNumber()
    {
        // Random.Range with integers is inclusive for both min and max values
        return Random.Range(0, 11); // 0 to 10 inclusive
    }
    public void ResetPlayer()
    {
        stats.ResetPlayer();
        animations.ResetPlayer();
        mana.ResetMana();
        SaveGame.Delete(Inventory.Instance.INVENTORY_KEY_DATA);
    }
}
