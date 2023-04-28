using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//using TMPro;

public class OrderManager : MonoBehaviour
{

    public Transform ticket;

    public Vector3 firstTicketPosition = new Vector3(1.087F, 1.807F, -3.441F);
    public Vector3 ticketRotation = new Vector3(0.0F, 0.0F, 0.0F);

    private List<string> recipeList; // List of all available recipes to choose from
    private List<Recipe> orderQueue; // List of all current recipes
    private List<Transform> ticketQueue; // List of all order ticket game objects
    public int maxTime = 50;
    public int minTime = 30;
    int totalOrdersAllowed = 3;
    private int currentOrders = 0;
    private int currentTimer;
    private string nextOrder;
    private System.Random rnd = new System.Random();

    private float duration = 3.0F;
    private float durationTime;

    // Start is called before the first frame update
    void Start()
    {
        //Debug.Log("initializing order generator");
        recipeList = new List<string>();
        recipeList.Add("Recipe_SandLTC");
        recipeList.Add("Recipe_SandT");
        recipeList.Add("Recipe_SandC");
        orderQueue = new List<Recipe>();
        ticketQueue = new List<Transform>();
        Time.timeScale = 1;
        nextOrder = "";

        resetTimer();
    }

    // Update is called once per frame
    void Update()
    {
        if (currentTimer == 0 && currentOrders < totalOrdersAllowed)
        {
            generateNextOrder();
            resetTimer();
        }
        else if (currentOrders == 0)
        {
            generateNextOrder();
        }
    }

    void resetTimer()
    {
        // Reset timer to next order only if the order queue
        // isn't already maxed out
        if (currentOrders < totalOrdersAllowed)
        {
            currentTimer = rnd.Next(minTime, maxTime);
        }
        StartCoroutine("OrderTimer");
    }

    // Sends out order to user
    void outputOrder(int index)
    {
        Transform newTicket = Instantiate(ticket, firstTicketPosition, Quaternion.Euler(ticketRotation));
        if (index != 0)
        {
            newTicket.position = new Vector3(ticketQueue[index - 1].position.x - 0.647F,
                    ticketQueue[index - 1].position.y, ticketQueue[index - 1].position.z);
        }
        ticketQueue.Insert(index, newTicket);
        Transform canvas = ticketQueue[index].GetChild(0);
        Text orderTitle = canvas.Find("OrderTitle").gameObject.GetComponent<Text>();
        Text orderContents = canvas.Find("OrderContents").gameObject.GetComponent<Text>();

        string title = orderQueue[index].getRecipeName();
        string contents = orderQueue[index].ingredientMenu();
        orderTitle.text = title;
        orderContents.text = contents;
    }

    // Generate a random index between 0 and recipeList size
    // and choose the next order based on random number
    void generateNextOrder()
    {
        int recipeIndex = rnd.Next(0, 2);
        nextOrder = recipeList[recipeIndex];
        Type recipeType = Type.GetType(nextOrder);
        Recipe newOrder = (Recipe)Activator.CreateInstance(recipeType);
        orderQueue.Add(newOrder);
        outputOrder(currentOrders);

        currentOrders++;
    }

    public bool orderMatch(GameObject delivery)
    {
        bool match = false;

        foreach (Recipe order in orderQueue)
        {
            string cloneName = order.name + "(Clone)";
            //if (string.Equals(order.getTag(), delivery.gameObject.tag))
            if (string.Equals(cloneName, delivery.gameObject.name))
            {
                match = true;
                completeOrder(order);
                break;
            }
        }
        return match;
    }

    private void completeOrder(Recipe removeRecipe)
    {
        int index = orderQueue.IndexOf(removeRecipe);
        orderQueue.Remove(removeRecipe);
        GameObject toBeDestroyed = ticketQueue[index].gameObject;
        ticketQueue.RemoveAt(index);
        Destroy(toBeDestroyed);

        // Edit inner paramters so more orders are generated
        currentOrders--;
        if (index != (totalOrdersAllowed - 1))
            moveOrderTickets(index);
    }

    private void moveOrderTickets(int skip)
    {
        Vector3 offset = new Vector3(0.647F, 0.0F, 0.0F);
        float step = 3.0F * Time.deltaTime;
        foreach (Transform ticket in ticketQueue)
        {
            // Only move the tickets before the gap
            // (skips specified amount of tickets at the beginning)
            if (skip == 0)
                ticket.position += offset;

            else
                skip--;
        }
    }


    // ends the order manager service
    public void endAll()
    {
        StopCoroutine("OrderTimer");
        // Destroy all ticket obejct
        foreach (Transform ticket in ticketQueue)
        {
            Destroy(ticket.gameObject);
        }
    }

    // Keeps track of time, based on max and min time, a new order is generated
    IEnumerator OrderTimer()
    {
        while (currentTimer > 0)
        {
            yield return new WaitForSeconds(1);
            currentTimer--;
        }
    }

}
