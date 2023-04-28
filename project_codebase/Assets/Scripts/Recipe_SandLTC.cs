using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Recipe_SandLTC : Recipe
{
    public Recipe_SandLTC()
    {
        ingredientList = new Dictionary<string, int>() { { "Bread", 2 }, 
                                                         { "Tomato", 1 },
                                                         { "Salad", 1 }, 
                                                         { "Cheese", 1 } };
        // ingredientList = new Dictionary<string, int>() { { "Toast", 2 },
        //                                                  { "Tomato", 1 } };
        name = "BLT";
        size = 5;
        //model = Resources.Load("recipes/sandwich_smaller", GameObject) as GameObject;
        model = Resources.Load<GameObject>("recipes/BLT");
        transform = model.GetComponent<Transform>();
        tag = "Recipe_SandLTC";
    }

/*    // Start is called before the first frame update
    void Start()
    {
        //ingredientList = new List<string>() { "Toast", "Toast", "Tomato", "Salad", "Cheese" };
    }

    // Update is called once per frame
    void Update()
    {

    }*/

}
