using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VRGunController : MonoBehaviour
{
    [SerializeField]
    SpawnObj bulletSpawner;

    [SerializeField]
    Transform rightHand;

    [SerializeField]
    Transform leftHand;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (OVRInput.GetDown(OVRInput.RawButton.RIndexTrigger))
        {
            bulletSpawner.Spawn();
        }

        transform.position = rightHand.position;

        Vector3 lookVec = leftHand.position - transform.position;
        transform.rotation = Quaternion.LookRotation(lookVec);
    }
}
