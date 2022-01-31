using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObj : MonoBehaviour
{
    [SerializeField]
    GameObject spawnObj;

    public void Spawn()
    {
        Instantiate(spawnObj, transform.position, transform.rotation);
    }
}
