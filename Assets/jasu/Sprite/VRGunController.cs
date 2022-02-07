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

    public int ammoNum;

    public int maxAmmo = 10;

    // Start is called before the first frame update
    void Start()
    {
        ammoNum = maxAmmo;
    }

    // Update is called once per frame
    void Update()
    {
        if (OVRInput.GetDown(OVRInput.RawButton.RIndexTrigger) || Input.GetKeyDown(KeyCode.Return))
        {
            if(ammoNum > 0)
            {
                bulletSpawner.Spawn();
                ammoNum--;
            }
            else
            {

            }
        }

        // 向き
        transform.position = rightHand.position;

        Vector3 lookVec = leftHand.position - transform.position;
        transform.rotation = Quaternion.LookRotation(lookVec);
    }

    public void ResetAmmo(int _maxAmmo)
    {
        maxAmmo = _maxAmmo;
        ammoNum = maxAmmo;
    }
}
