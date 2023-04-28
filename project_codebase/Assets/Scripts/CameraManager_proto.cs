using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager_proto : MonoBehaviour
{
    public Transform transformCam;
    public float mspeed = 2.0f;
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        if (Input.GetKey("left"))
        {
            //transformCam.position += new Vector3(0.1F, 0.0F, 0.0F);
            transformCam.position = transformCam.position + Camera.main.transform.right * -1 * mspeed * Time.deltaTime;
        }
        else if (Input.GetKey("right"))
        {
            //transformCam.position += new Vector3(-0.1F, 0.0F, 0.0F);
            transformCam.position = transformCam.position + Camera.main.transform.right * mspeed * Time.deltaTime;
        }
        /*else*/
        if (Input.GetKey("up"))
        {
            //transformCam.position += new Vector3(0.0F, 0.0F, -0.1F);
            transformCam.position = transformCam.position + Camera.main.transform.forward * mspeed * Time.deltaTime;
        }
        else if (Input.GetKey("down"))
        {
            //transformCam.position += new Vector3(0.0F, 0.0F, 0.1F);
            transformCam.position = transformCam.position + Camera.main.transform.forward * mspeed * -1 * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.A))
        {
            transformCam.Rotate(0.0F, -1.0F, 0.0F);
        } 
        else if(Input.GetKey(KeyCode.D))
        {
            transformCam.Rotate(0.0F, 1.0F, 0.0F);
        }
    }
}
