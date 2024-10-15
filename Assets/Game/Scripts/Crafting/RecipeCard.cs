using Game.Scripts;
using UnityEngine;
using UnityEngine.UI;

public class RecipeCard : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] private Image recipeIcon;

    public Recipe RecipeLoaded { get; set; }

    public void InitRecipeCard(Recipe recipe)
    {
        RecipeLoaded = recipe;
        recipeIcon.sprite = recipe.itemfinal.Icon;
    }

    public void ClickRecipe()
    {
        CraftingManager.Instance.ShowRecipe(RecipeLoaded);
    }
}
