using Game.Scripts.Extra;
using UnityEngine;

namespace Game.Scripts
{
    public class LootManager : Singelton<LootManager>
    {
        [Header("Config")]
        [SerializeField] private GameObject lootPanel;
        [SerializeField] private LootButton LootButtonPrefab;
        [SerializeField] private Transform container;

        public void ShowLoot(EnemyLoot loot)
        {
            
            lootPanel.SetActive(true);
            if (lootPanelWithItems())
            {
                for (int i = 0; i < container.childCount; i++)
                {
                    Destroy(container.GetChild(i).gameObject);
                    
                }
                
            }

       
            foreach (var item in loot.Items)
            {
                if(item.PickedItem)continue;
               LootButton lootButton = Instantiate(LootButtonPrefab, container);
               lootButton.ConfigLootButton(item);
            }
            
        }

        public void ClosePanel()
        {
            lootPanel.SetActive(false);
        }

        private bool lootPanelWithItems()
        {
            return container.childCount > 0;

        }
    }
}