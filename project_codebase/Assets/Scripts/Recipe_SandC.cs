using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Recipe_SandC : Recipe
{
    public Recipe_SandC()
    {
        /*        ingredientList = new Dictionary<string, int>() { { "Toast", 2 }, 
                                                                 { "Tomato", 1 },
                                                                 { "Salad", 1 }, 
                                                                 { "Cheese", 1 } };*/
        ingredientList = new Dictionary<string, int>() { { "Bread", 2 },
                                                         { "Cheese", 1 } };
        name = "Cheese Sandwich";
        size = 3;
        //model = Resources.Load("recipes/sandwich_smaller", GameObject) as GameObject;
        model = Resources.Load<GameObject>("recipes/Cheese Sandwich");
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
