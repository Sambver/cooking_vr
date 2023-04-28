using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System;

public class IngredientGeneration : MonoBehaviour
{
    public Transform spawnLoc;
    public Transform ingredient;
    public Vector3 localSpawnPosition = new Vector3(0.0F, 0.0F, 0.0F);
    public Vector3 localSpawnRotation = new Vector3(0.0F, 0.0F, 0.0F);
    public Vector3 localScale = new Vector3(0.0F, 0.0F, 0.0F);
    private String ingredientName;

    // Start is called before the first frame update
    void Start()
    {
        //Transform firstIngredient = Instantiate(ingredient, spawnLoc.position, spawnLoc.rotation)
        //Debug.Log(spawnLoc.rotation);
        ingredientName = ingredient.gameObject.name;
    }

    // Update is called once per frame
    void Update()
    {
        if (spawnLoc.childCount == 0)
        {
            //Debug.Log("No children!");
            //Rigidbody newIngredient;
            Transform newIngredient = Instantiate(ingredient, spawnLoc.position, spawnLoc.rotation);
            newIngredient.SetParent(spawnLoc);

            newIngredient.localPosition = localSpawnPosition;
            newIngredient.rotation = Quaternion.Euler(localSpawnRotation);
            newIngredient.localScale = localScale;
            //newIngredient.localScale = new Vector3(0.5F, 0.5F, 0.5F);

            // Freeze all movement of new ingredient (only moves when picked up by user)
            Rigidbody rbIngredient = newIngredient.gameObject.GetComponent<Rigidbody>();
            rbIngredient.constraints = RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezeRotationX
                                     | RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezeRotationY
                                     | RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezeRotationZ;

            newIngredient.gameObject.name = ingredientName;
        }
    }
}
