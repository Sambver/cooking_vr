using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
	public Transform transformCam;
    public Transform transformCannonBall;
    public Transform transformSpawning;

    public float campSpeed = 1.0F; //Meters/second

    public int destroyTimeCannonBall = 3;

    // Start is called before the first frame update
    void Start()
    {
        transformCam = this.transform;
        //Debug.Log(this.gameObject.name);
    }

    // Update is called once per frame
    void Update()
    {
        // if (Input.GetKeyDown(KeyCode.LeftArrow))
        // {
        // 	transformCam.position += new Vector3(-1.0F, 0.0F, 0.0F);
        //     Debug.Log("left arrow key was pressed");
        // }  
        // else if (Input.GetKeyDown(KeyCode.RightArrow))
        // {
        // 	transformCam.position += new Vector3(1.0F, 0.0F, 0.0F);
        //     Debug.Log("right arrow key was pressed");
        // }       
        // else if (Input.GetKeyDown(KeyCode.UpArrow))
        // {
        // 	transformCam.position += new Vector3(0.0F, 1.0F, 0.0F);
        //     Debug.Log("up arrow key was pressed");
        // } 
        // else if (Input.GetKeyDown(KeyCode.DownArrow))
        // {
        // 	transformCam.position += new Vector3(0.0F, -1.0F, 0.0F);
        //     Debug.Log("down arrow key was pressed");
        // }
        /*else*/ if (Input.GetKey("left"))
        {
        	transformCam.position += new Vector3(-0.1F, 0.0F, 0.0F);
        }
        else if (Input.GetKey("right"))
        {
        	transformCam.position += new Vector3(0.1F, 0.0F, 0.0F);
        }
        /*else*/ if (Input.GetKey("up"))
        {
        	transformCam.position += new Vector3(0.0F, 0.1F, 0.0F);
        }
        else if (Input.GetKey("down"))
        {
        	transformCam.position += new Vector3(0.0F, -0.1F, 0.0F);
        }

/*        // FIRING
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // Instantiate the projectile at the position and rotation of this transform
            //Rigidbody clone;
            //clone = Instantiate(projectile, transform.position, transform.rotation);
            Transform transformClone = Instantiate(transformCannonBall, transformSpawning.position, transformSpawning.rotation);
            Rigidbody rbClone = transformClone.GetComponent<Rigidbody>();
            rbClone.AddForce(-10000.0F, 0.0F, 100.0F);
            //rbClone.AddRelativeForce(-10000.0F, 0.0F, 0.0F);

            Destroy(transformClone.gameObject, 5);

            // Give the cloned object an initial velocity along the current
            // object's Z axis
            //clone.velocity = transform.TransformDirection(Vector3.forward * 10);
            Debug.Log("Space key was pressed");
        }*/
    }
}
