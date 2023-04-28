using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementManager : MonoBehaviour
{
    public Transform tObj;
    public Transform tPlate;
    public Transform tSpawn;

    // Start is called before the first frame update
    void Start()
    {
        tObj = this.transform;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.D))
        {
            tObj.position += new Vector3(-0.1F, 0.0F, 0.0F);
        }
        else if (Input.GetKey(KeyCode.A))
        {
            tObj.position += new Vector3(0.1F, 0.0F, 0.0F);
        }
        /*else*/
        if (Input.GetKey(KeyCode.W))
        {
            tObj.position += new Vector3(0.0F, 0.0F, 0.1F);
        }
        else if (Input.GetKey(KeyCode.S))
        {
            tObj.position += new Vector3(0.0F, 0.0F, -0.1F);
        }
    }
}
