using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlateSpawn : MonoBehaviour
{
    public Transform spawnLoc;
    public Transform spawn;
    public Vector3 localSpawnPosition = new Vector3(0.0F, 0.0F, 0.0F);
    public Vector3 localSpawnRotation = new Vector3(0.0F, 0.0F, 0.0F);
    public Vector3 localScale = new Vector3(0.0F, 0.0F, 0.0F);
    public string spawnName;


    // Start is called before the first frame update
    void Start()
    {
        spawnName = spawn.gameObject.name;
    }

    // Update is called once per frame
    void Update()
    {
        if (spawnLoc.childCount == 0)
        {
            Transform newSpawn = Instantiate(spawn, spawnLoc.position, spawnLoc.rotation);
            newSpawn.SetParent(spawnLoc);

            newSpawn.localPosition = localSpawnPosition;
            newSpawn.rotation = Quaternion.Euler(localSpawnRotation);
            newSpawn.localScale = localScale;
            //newSpawn.localScale = new Vector3()

            // Freeze plate
            Rigidbody rbIngredient = newSpawn.gameObject.GetComponent<Rigidbody>();
            rbIngredient.constraints = RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezeRotationX
                                     | RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezeRotationY
                                     | RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezeRotationZ;

            newSpawn.gameObject.name = spawnName;
        }
    }
}
