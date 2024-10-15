using System;
using System.Collections.Generic;
using Game.Scripts.Extra;
using Game.Scripts.NPC;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : Singelton<DialogueManager>
{

    public static event Action<InteractionType> OnExtraInteractionEvent; 
    
    
    [Header("Config")]
    [SerializeField] private GameObject dialoguePanel;
    [SerializeField] private Image npcIcon;
    [SerializeField] private SpriteRenderer nextPageIcon;
    [SerializeField] private TextMeshProUGUI npcNameTMP;
    [SerializeField] private TextMeshProUGUI npcDialogueTMP;

    public NPCInteraction NPCSelected { get; set; }

    private bool dialogueStarted;
    private PlayerActions _actions;

    private Queue<string> dialogueQueue = new Queue<string>();

    protected override void Awake()
    {
        base.Awake();
        _actions = new PlayerActions();
    }

    private void Start()
    {
        _actions.Dialogue.Interact.performed += ctx => ShowDialogue();
        _actions.Dialogue.Continue.performed += ctx => continueDialogue();
    }

    public void CloseDialoguePanel()
    {
        dialoguePanel.SetActive(false);
        dialogueStarted = false;
        dialogueQueue.Clear();
    }

    private void LoadDialogueFromNPC()
    {
        if(NPCSelected.DialogueToShow.Dialogue.Length<=0) return;

        foreach (var VARIABLE in NPCSelected.DialogueToShow.Dialogue)
        {
            dialogueQueue.Enqueue(VARIABLE);
        }
    }

    private void ShowDialogue()
    {
        if(NPCSelected == null) return;
        if(dialogueStarted) return;
        dialoguePanel.SetActive(true);
            LoadDialogueFromNPC();
            
            npcIcon.sprite = NPCSelected.DialogueToShow.Icon;
            npcNameTMP.text = NPCSelected.DialogueToShow.Name;
            npcDialogueTMP.text = NPCSelected.DialogueToShow.Greeting;
            dialogueStarted = true;

            if (dialogueQueue.Count > 0)
            {
                nextPageIcon.enabled = true;
            }
            
    }

    private void continueDialogue()
    {
        if (NPCSelected == null)
        {
            dialogueQueue.Clear();
            return;
        }

        if (dialogueQueue.Count <= 0 )
        {
            CloseDialoguePanel();
            dialogueStarted = false;
            if (NPCSelected.DialogueToShow.HasInteraction)
            {
                OnExtraInteractionEvent?.Invoke(NPCSelected.DialogueToShow.InteractionType);
            }
            return;
        }

        npcDialogueTMP.text = dialogueQueue.Dequeue();
    }

    private void OnEnable()
    {
        _actions.Enable();
    }

    private void OnDisable()
    {
        _actions.Disable();
    }
}
