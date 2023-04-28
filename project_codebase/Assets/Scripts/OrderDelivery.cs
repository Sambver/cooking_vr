using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class OrderDelivery : MonoBehaviour
{
    public Text alert;
    public GameObject GameElements;
    public AudioSource cashRegister;
    public AudioSource error;

    public GameObject correctParticles;
    public GameObject errorParticles;

    private bool alreadyChecked = false;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerStay(Collider delivery)
    {
        Transform tChild = null;
        if (delivery.transform.parent == null)
        {
            if (delivery.gameObject.GetComponent<Transform>().childCount > 2)
                // Get the 3rd child transform (index of 2) of collision
                tChild = delivery.gameObject.GetComponent<Transform>().GetChild(2);
            else // there aren't enough children, this is an invalid deliver
                return;
            // Check to see if order is completed
            // if delivery tag is equal to any current order tag
            if(GameElements.GetComponent<OrderManager>().orderMatch(tChild.gameObject))
            {
                Destroy(delivery.gameObject);
                correctParticles.GetComponent<ParticleSystem>().Play();
                cashRegister.Play();
                cashRegister.Play();

                GameElements.GetComponent<ScoreKeeper>().scoreUp(5);
                alreadyChecked = true;
                return;
            }
            else if (!alreadyChecked)
            {
                alreadyChecked = false;
                //if (delivery.gameObject.name == "Dish_Blue Small") return;
                Destroy(delivery.gameObject);

                errorParticles.GetComponent<ParticleSystem>().Play();
                error.Play();
            }
        }
    }

    void ClearText()
    {
        alert.text = "";
    }
   
}
