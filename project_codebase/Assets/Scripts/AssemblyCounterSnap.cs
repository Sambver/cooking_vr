using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System;

public class AssemblyCounterSnap : MonoBehaviour
{
    public Transform tSnap;
    private GameObject orderSparkle;

    public List<Recipe> availableOrders;

    public GameObject plate;
    private bool isAssbembled = false; 
    List<GameObject> assembledIngredients = new List<GameObject>();
    Dictionary<string, int> assembledIngredientNames;
    ArrayList orderList;

    RecipeManager recipeManager;

    //public AudioSource dishCreate;
    private AudioSource dishCreate;

    // Start is called before the first frame update
    void Start()
    {
        recipeManager = new RecipeManager();
        assembledIngredientNames = new Dictionary<string, int>();

        orderSparkle = GameObject.Find("GameElements/OrderParticles");
        GameObject soundObject = GameObject.Find("GameElements/Audio_dish_creation");
        dishCreate = soundObject.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        Recipe match = recipeManager.findRecipeMatch(assembledIngredientNames, assembledIngredients.Count);
        if (match != null)
        {
            foreach(GameObject current in assembledIngredients)
            {
                Destroy(current);
            }

            assembledIngredients.Clear();

            Transform plateLoc = tSnap;
            Transform tRecipe = Instantiate(match.getTransform(), plateLoc.position, plateLoc.rotation);
            orderSparkle.GetComponent<ParticleSystem>().Play();
            dishCreate.Play();


            tRecipe.SetParent(plateLoc);
            tRecipe.localPosition = new Vector3(-0.004F, 0.028F, 0.01899996F);
            tRecipe.gameObject.tag = match.getTag();

            Destroy(tRecipe.gameObject.GetComponent<Rigidbody>());
            Destroy(tRecipe.gameObject.GetComponent<BoxCollider>());

            isAssbembled = true;
        }
    }

    void OnTriggerStay(Collider collider)
    {
        //Debug.Log("In trigger");
        if (isAssbembled)
        {
            return;
        }
        //Debug.Log(collider.gameObject.name);
        //Debug.Log(collider.transform.parent);
        // Snap to location of plate
        if (collider.transform.parent == null)
        {
            GameObject ingredient = collider.GetComponent<Collider>().gameObject;
            if (assembledIngredientNames.ContainsKey(ingredient.name))
                assembledIngredientNames[ingredient.name] = assembledIngredientNames[ingredient.name] + 1;
            else
                assembledIngredientNames.Add(ingredient.name, 1);
            // assembledIngredients.AddLast(ingredient);
            assembledIngredients.Add(ingredient);
            //ingredient.transform.SetParent(tSnap.GetChild(0));
            ingredient.transform.SetParent(tSnap);
            //ingredient.transform.SetParent(plate.GetComponent<Transform>());
            ingredient.transform.localPosition = new Vector3(-0.004F, 0.01600001F, 0.01899996F);
            //ingredient.transform.rotation = Quaternion.identity;
            ingredient.transform.localEulerAngles = new Vector3(90.0F, 0.0F, 0.0F);
            // Remove Rigidbody and collider components from ingredient
            Destroy(ingredient.GetComponent<Rigidbody>());
            Destroy(ingredient.GetComponent<BoxCollider>());

            //Debug.Log("Assembled Ingredient count is now: " + assembledIngredients.Count);
        }
    }
}
