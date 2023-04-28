using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecipeManager
{
    private List<string> allRecipes;

    public RecipeManager()
    {
        allRecipes = new List<string>() { "Recipe_SandLTC", "Recipe_SandC", "Recipe_SandT" };
    }

    public bool checkForRecipeMatch(Dictionary<string, int> assembledIngs, int totalIngredients)
    {
        //Debug.Log("Recipe Manager: checking for match");
        //Debug.Log(allRecipes);
        bool matchFound = false;
        int assembledCount = assembledIngs.Count;
        foreach (string recipe in allRecipes)
        {
            //Debug.Log("in foreach");
            Type recipeType = Type.GetType(recipe);
            Recipe tempRecipe = (Recipe)Activator.CreateInstance(recipeType);
            //Debug.Log("Count of recipe ingredients: " + tempRecipe.getRecipeSize());
            //Debug.Log("Count of assembled ingredients: " + totalIngredients);
            if (tempRecipe.getRecipeSize() == totalIngredients)
            {
                //Debug.Log("found a size match");
                matchFound = tempRecipe.checkForMatch(assembledIngs);
                if (matchFound)
                    break;
            }
        }
        return matchFound;
    }

    public Recipe findRecipeMatch(Dictionary<string, int> assembledIngs, int totalIngredients)
    {
        //Debug.Log("Recipe Manager: checking for match");
        //Debug.Log(allRecipes);
        bool matchFound = false;
        Recipe recipeMatch = null;
        int assembledCount = assembledIngs.Count;
        foreach (string recipe in allRecipes)
        {
            //Debug.Log("in foreach");
            Type recipeType = Type.GetType(recipe);
            Recipe tempRecipe = (Recipe)Activator.CreateInstance(recipeType);
            if (tempRecipe.getRecipeSize() == totalIngredients)
            {
                matchFound = tempRecipe.checkForMatch(assembledIngs);
                if (matchFound)
                {
                    recipeMatch = tempRecipe;
                    break;
                }
            }
        }
        //return matchFound;
        //Debug.Log("recipe found status is: " + matchFound);
        return recipeMatch;
    }
}
