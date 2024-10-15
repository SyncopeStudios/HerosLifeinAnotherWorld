using System;
using Game.Scripts.Extra;
using Game.Scripts.Quest;
using UnityEngine;

namespace Game
{
    public class QuestManager : Singelton<QuestManager>
    {
        [Header("Quests")]
        [SerializeField] private Quest[] _quests;

        [Header("NPCQuest Panel")]
        [SerializeField] private QuestCardNPC npcQuestCardPrefab;
        [SerializeField] private Transform npcPanelContainer;

        [Header("Player Quest Panel")]
        [SerializeField] private QuestCardPlayer _questCardPlayerPrefab;
        [SerializeField] private Transform PlayerQuestContainer;
        private void Start()
        {
            LoadQuestIntoNPCPanel();
        }

        public void AcceptQuest(Quest quest)
        {
           QuestCardPlayer cardPlayer = Instantiate(_questCardPlayerPrefab, PlayerQuestContainer);
           
           cardPlayer.ConfigQuestUI(quest);

        }

        public void AddProgress(string questID, int amount)
        {
            Quest questToUpdate = QuestExists(questID);

            if (questToUpdate == null) return;
            if (questToUpdate.QuestAccepted)
            {
                questToUpdate.AddProgreess(amount);
            }
        }

        private Quest QuestExists(string QuestID)
        {
            foreach (Quest quest in _quests)
            {
                if (quest.ID == QuestID)
                {
                    return quest;
                }
            }

            return null;
        }
        
        

        private void LoadQuestIntoNPCPanel()
        {
            for (int i = 0; i < _quests.Length; i++)
            {
                QuestCard npcCard = Instantiate(npcQuestCardPrefab, npcPanelContainer);
                npcCard.ConfigQuestUI(_quests[i]);

            }
            
            
        }

        private void OnEnable()
        {
            for (int i = 0; i < _quests.Length; i++)
            {
                _quests[i].ResetQuest();
            }
        }
    }
}