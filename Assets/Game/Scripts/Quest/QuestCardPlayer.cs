using System;
using Game.Scripts;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class QuestCardPlayer : QuestCard
{

    [Header("Config")]
    [SerializeField] private TextMeshProUGUI statusTMP;
    [SerializeField] private TextMeshProUGUI GoldRewardTMP;
    [SerializeField] private TextMeshProUGUI ExpTMP;


    [Header("Item")]
    [SerializeField] private Image ItemIcon;
    [SerializeField] private TextMeshProUGUI ItemQuantityTMP;

    [Header("Quest Completed")]
    [SerializeField] private GameObject claimButton;
    [SerializeField] private GameObject rewardsPanel;

    private void Update()
    {
        
        statusTMP.text = $"Status\n{QuestToComplete.CurrentStatus}/{QuestToComplete.QueatGoal}";
    }

    public override void ConfigQuestUI(Quest quest)
    {
        base.ConfigQuestUI(quest);
        statusTMP.text = $"Status\n {quest.CurrentStatus}/{quest.QueatGoal}";
        GoldRewardTMP.text = quest.GoldReward.ToString();
        ExpTMP.text = quest.ExpReward.ToString();

        ItemIcon.sprite = quest.ItemReward.Item.Icon;
        ItemQuantityTMP.text = quest.ItemReward.Quantity.ToString();

    }

    public void ClaimQuest()
    {
        
        GameManager.Instance.AddPlayerExp(QuestToComplete.ExpReward);
        Inventory.Instance.AddItem(QuestToComplete.ItemReward.Item, QuestToComplete.ItemReward.Quantity);
        CoinManager.Instance.AddCoins(QuestToComplete.GoldReward);
        gameObject.SetActive(false);
        
    }

    private void QuestComletedCheck()
    {
        if (QuestToComplete.QuestCompleted)
        {
            
            claimButton.SetActive(true);
            rewardsPanel.SetActive(false);
            
        }
        
    }

    private void OnEnable()
    {
        QuestComletedCheck();
    }
}
