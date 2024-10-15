using System;
using TMPro;
using UnityEngine;

namespace Game.Scripts.Quest
{
    public class QuestCardNPC : QuestCard
    {

        [SerializeField] private TextMeshProUGUI questRewardTMP;

        public override void ConfigQuestUI(global::Quest quest)
        {
            base.ConfigQuestUI(quest);
            questRewardTMP.text = $"- {quest.GoldReward} Gold\n" +
                                  $"- {quest.ExpReward} Exp\n"+
                                  $"- x{quest.ItemReward.Quantity} {quest.ItemReward.Item.Name} Item";

        }

        public void AcceptQuest()
        {

            if (QuestToComplete == null) return;
            QuestToComplete.QuestAccepted = true;
            QuestManager.Instance.AcceptQuest(QuestToComplete);
            gameObject.SetActive(false);

        }


    }
}