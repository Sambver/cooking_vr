using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Recipe
{
    //List<string> ingredientList;
    protected Dictionary<string, int> ingredientList;
    protected int size;
    public string name;

    public GameObject model;
    public Transform transform;
    protected string tag;

    private List<string> recipeNames;

    public Recipe()
    {
        //ingredientList = new Dictionary<string, int>() { { "NA", 0 } };
        ingredientList = new Dictionary<string, int>();
        size = 0;
        ingredientList.Add("NA", 0);

        recipeNames = new List<string>() { "Recipe_SandLTC" };
        tag = "NA";
    }

    public Transform getTransform()
    {
        return transform;
    }

    public string getTag()
    {
        return tag;
    }

/*    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }*/

    // Returns a basic string of ingredients
    string listIngredients()
    {
        string ingredientsToString = "";
        foreach (KeyValuePair<string, int> ingredient in ingredientList)
        {
            ingredientsToString = ingredientsToString + " " + ingredient.Key + ingredient.Value;
        }
        return ingredientsToString;
        /*        string ingredientsToString = "";
                foreach(KeyValuePair<string, int> ingredient in ingredientList)
                {
                    ingredientsToString = ingredientsToString + ingredient.Key +
                                            " (" + ingredient.Value + ")" + "\n";
                }
                return ingredientsToString;*/
        /*        string ingToString = "";
                foreach (var ing in ingredientList)
                {
                    ingToString = ingToString + ing + " ";
                }
                return ingToString;*/
    }

    // Returns an organized string of ingredients (for menu)
    public string ingredientMenu()
    {
        string ingredientsToString = "";
        foreach (KeyValuePair<string, int> ingredient in ingredientList)
        {
            ingredientsToString = ingredientsToString + ingredient.Key +
                                    "(" + ingredient.Value + ")\n";
        }
        return ingredientsToString;
    }

    public string getRecipeName()
    {
        return name;
    }

    public int getRecipeSize()
    {
        return size;
    }

    public bool checkForMatch(Dictionary<string, int> assembledIngs)
    {
        bool matches = true;
        bool innerMatch = false;
        //int totalIngredients = ingredientList.Count();

        List<int> ingredientCount = ingredientCountToList();

        /*        // Iterate through ingredient list and assembled ingredients
                // to determine if there is a match
                for(int i_recipe = 0; i_recipe < size; i_recipe++)
                {
                    for (int i_assembled = 0; i_assembled < assembledIngs.Count; i_assembled++)
                    {
                        // if (String.Equals(checkOrderCompletion[ingIndex], current.name))
                        if (string.Equals(assembledIngs[i_assembled], ingredientList[i_recipe]) )
                        {
                            if ( ingredientCount[i_recipe] > 0)
                            {
                                ingredientCount[i_recipe] = ingredientCount[i_recipe] - 1;
                                innerMatch = true;
                                continue; // Match is found, go to next loop iteration
                            } 
                            else // there are too many assembled ingredients for this recipe
                            {
                                matches = false;
                                break;
                            }
                        }
                    }
                }*/
        int index = 0;
        // Compare each assembled ingredient to each ingredient in the recipe
        // to see if the assembled ingredients is a match
        foreach(KeyValuePair<string, int> ingredient in ingredientList)
        {
            //Debug.Log("Recipe Ingredient: " + ingredient.Key);
            foreach(KeyValuePair<string, int> assembled in assembledIngs)
            {
                //Debug.Log("Assembled Ingredient: " + assembled.Key);
                if(string.Equals(ingredient.Key, assembled.Key))
                {
                    //Debug.Log("ingredient value: " + ingredient.Value);
                    //Debug.Log("assembled value: " + assembled.Value);
                    if(ingredient.Value == assembled.Value)
                    {
                        ingredientCount[index] = 0;
                    }
                    else
                    {
                        matches = false;
                        break;
                    }
                }
            }
            index++;
        }

        //Debug.Log("At this point, matches is: " + matches);
        

        // If matches is now true, check to verify all 
        if (matches)
        {
            foreach (int ingredient in ingredientCount)
            {
                Debug.Log(ingredient);
                if (ingredient > 0)
                {
                    matches = false;
                    break;
                }
            }
        }

        Debug.Log("At the end, matches is: " + matches);
        return matches;
    }

    private List<int> ingredientCountToList ()
    {
        List<int> ingredientCount = new List<int>();
        foreach(KeyValuePair<string, int> ingredient in ingredientList)
        {
            ingredientCount.Add(ingredient.Value);
        }
        return ingredientCount;
    }
}
