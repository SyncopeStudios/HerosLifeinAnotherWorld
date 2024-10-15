using System;
using Game.Scripts.Crafting;
using Game.Scripts.Extra;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Game.Scripts
{
    public class CraftingManager : Singelton<CraftingManager>
    {
        
        [Header("config")]
        [SerializeField]private RecipeCard _recipeCardPrefab;
        [SerializeField] private Transform recipeContanier;
        [SerializeField] private GameObject craftMaterialsPanel;

        [Header("Recipe Info")]
        [SerializeField] private TextMeshProUGUI recipeName;
        [SerializeField] private Image item1Icon;
        [SerializeField] private TextMeshProUGUI item1Name;
        [SerializeField] private TextMeshProUGUI item1Amount;
        [SerializeField] private Image item2Icon;
        [SerializeField] private TextMeshProUGUI item2Name;
        [SerializeField] private TextMeshProUGUI item2Amount;
        [SerializeField] private Button craftButton;
        
        [Header("Fianl item")]
        [SerializeField] private Image finalItemIcon;
        [SerializeField] private TextMeshProUGUI finalItemName;
        [SerializeField] private TextMeshProUGUI finalItemDes;
        [Header("Recipes")]
        [SerializeField] private RecipeList _recipeList;

        public Recipe RecipeSelected { get; private set; }
        private void Start()
        {
            LoadRecipes();
        }

        private void LoadRecipes()
        {
            for (int i = 0; i < _recipeList.Recipes.Length; i++)
            {
              RecipeCard card =  Instantiate(_recipeCardPrefab, recipeContanier);

              card.InitRecipeCard(_recipeList.Recipes[i]);
              
            }
            
        }

        public void CraftItem()
        {
            for (int i = 0; i < RecipeSelected.item1Amount ; i++)
            {
                global::Inventory.Instance.ConsumeItem(RecipeSelected.item1.ID);
                
            }  
            for (int i = 0; i < RecipeSelected.item2Amount ; i++)
            {
                global::Inventory.Instance.ConsumeItem(RecipeSelected.item2.ID);
                
            }
            
            global::Inventory.Instance.AddItem(RecipeSelected.itemfinal, RecipeSelected.itemfinalAmount);
            ShowRecipe(RecipeSelected);
        }

        public void ShowRecipe(Recipe recipe)
        {

            if (craftMaterialsPanel.activeSelf == false)
            {
                
                craftMaterialsPanel.SetActive(true);
                
            }

            RecipeSelected = recipe;

            recipeName.text = recipe.Name;
            item1Icon.sprite = recipe.item1.Icon;
            item1Name.text = recipe.item1.Name;
            item2Icon.sprite = recipe.item2.Icon;
            item2Name.text = recipe.item2.Name;

            item1Amount.text =
                $"{recipe.item1Amount}/{(global::Inventory.Instance.GetItemCurrentStock(recipe.item1.ID))}";
            item2Amount.text =
                $"{recipe.item2Amount}/{(global::Inventory.Instance.GetItemCurrentStock(recipe.item2.ID))}";


            finalItemIcon.sprite = recipe.itemfinal.Icon;
            finalItemName.text = recipe.itemfinal.Name;
            finalItemDes.text = recipe.itemfinal.Description;

            craftButton.interactable = CanCraftItem(recipe);
        }

        private bool CanCraftItem(Recipe recipe)
        {

            int item1Stock = global::Inventory.Instance.GetItemCurrentStock(recipe.item1.ID);
            int item2Stock = global::Inventory.Instance.GetItemCurrentStock(recipe.item2.ID);


            if (item1Stock >= recipe.item1Amount && item2Stock >= recipe.item2Amount)
            {

                return true;

            }

            return false;
        }
    }
}