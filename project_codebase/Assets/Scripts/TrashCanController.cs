using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashCanController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerStay(Collider coll)
    {
        GameObject collisionObject = coll.gameObject;

        if (coll.transform.parent == null && 
            coll.gameObject.tag == "pickupable")
        {
            Destroy(coll.gameObject);
        }
    }

}
