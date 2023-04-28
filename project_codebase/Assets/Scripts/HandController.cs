using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandController : MonoBehaviour
{
    public double pickupDistance = 3.0;
    public static GameObject heldObject;
    public static int itemHeld = 0;
    public float objectDist = -.1F;
    public GameObject hand;
    public bool leftHand;

    private string triggerButton;

    // Start is called before the first frame update
    void Start()
    {
        //hand = gameObject.FindWithTag("Player");
        if(leftHand)
        {
            triggerButton = "Oculus_CrossPlatform_PrimaryHandTrigger";
        }
        else
        {
            triggerButton = "Oculus_CrossPlatform_SecondaryHandTrigger";
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetAxis(triggerButton) > 0.1f)
        {
            //Debug.Log(itemHeld);
            if (itemHeld == 1)
            {
                itemHeld = 2;
            }

        }
        else if (Input.GetAxis(triggerButton) < 0.1f && itemHeld == 2)
        {
            heldObject.transform.SetParent(null);
            heldObject.GetComponent<Rigidbody>().isKinematic = false;
            heldObject = null;
            itemHeld = 0;
        }
    }

   void OnTriggerStay(Collider coll)
    {
        if (Input.GetAxis(triggerButton) > 0.1f)
        {
            if (itemHeld == 0)
            {
                Transform cParent = coll.transform.parent;
                if (coll.gameObject.tag == "pickupable" && 
                    (cParent.tag == "ingredient_spawn" ||
                    coll.transform.parent == null))
                {
                    pickup(coll.GetComponent<Collider>().gameObject);
                    if(coll.gameObject.GetComponent<AssemblyCounterSnap>() != null) {
                        Destroy(coll.gameObject.GetComponent<AssemblyCounterSnap>());
                    }
                } 
                else if (coll.gameObject.tag == "completed_dish")
                {
                    Transform parent = coll.transform.parent;
                    pickup(parent.gameObject);
                }
            }
        }
    }

    private void pickup(GameObject obj)
    {
        heldObject = obj;
        heldObject.transform.SetParent(hand.GetComponent<Transform>());
        heldObject.transform.localPosition = new Vector3(0.0F, 0.0F, 0.0F);
        //heldObject.transform.localPosition = new Vector3(0.51F, 0.28F, -0.51F);
        //heldObject.transform.localPosition = new Vector3(1.0F, 1.0F, -1.0F);

        heldObject.GetComponent<Rigidbody>().isKinematic = true;
        //heldObject.transform.localPosition = new Vector3(0, objectDist, 0);
        itemHeld = 1;

        heldObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
    }

}
