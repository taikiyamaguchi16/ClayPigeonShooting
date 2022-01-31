using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoDestroy : MonoBehaviour
{
    public float time;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("ObjectDestroy");
    }


    private IEnumerator ObjectDestroy()
    {
        
        yield return new WaitForSeconds(time);
        Debug.Log(time);
        Destroy(this.gameObject);
    }
}
