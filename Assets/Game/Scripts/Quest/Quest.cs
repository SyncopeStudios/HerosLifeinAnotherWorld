using System;
using UnityEngine;

[CreateAssetMenu]
public class Quest : ScriptableObject
{

    
    public string Name;
    public string ID;
    public int QueatGoal;

    [Header("Description")]
    [TextArea] public string Description;


    [Header("reward")]
    public int GoldReward;
    public float ExpReward;
    public QuestItemReward ItemReward;

    [Header("Quest Status")]
    [HideInInspector] public int CurrentStatus;
    [HideInInspector] public bool QuestCompleted;
    [HideInInspector] public bool QuestAccepted;


    public void AddProgreess(int amount)
    {
        CurrentStatus += amount;
        if (CurrentStatus >= QueatGoal)
        {
            CurrentStatus = QueatGoal;
            QuestIsComplete();
        }
    }

    private void QuestIsComplete()
    {
        if (QuestCompleted)
        {
            return;
        }

        QuestCompleted = true;
    }

    public void ResetQuest()
    {
        QuestAccepted = false;
        QuestCompleted = false;
        CurrentStatus = 0;
    }
}

[Serializable]
public class QuestItemReward
{
    public InventoryItem Item;

    public int Quantity;

}