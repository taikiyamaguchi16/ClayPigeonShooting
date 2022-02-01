using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LauncherManager : MonoBehaviour
{
    [SerializeField]
    private GameObject clay;
    [SerializeField]
    private GameObject launchPos;

    public float claySpeed;


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            //Launcher();
            LaunchToOrder(4);
        }     
    }

    //ÉNÉåÅ[î≠éÀ
    public void Launcher()
    {
        GameObject insClay = Instantiate(clay, transform);
        Vector3 direction = launchPos.transform.forward;


        insClay.transform.position = launchPos.transform.position;

        insClay.transform.rotation = Quaternion.Euler(0, transform.rotation.y, Random.Range(5, 20));
        Vector3 velocity = insClay.transform.rotation * direction;

        //insClay.GetComponent<Rigidbody>().AddForce(velocity * claySpeed, ForceMode.Impulse);
        insClay.GetComponent<Rigidbody>().AddForce(velocity * claySpeed, ForceMode.Impulse);

        insClay.AddComponent<AutoDestroy>().time = 5;
    }

    //ï°êîìØéûÇ…î≠éÀ
    public void LaunchToConcurrent(int _num)
    {
        for (int i = 0; i < _num; ++i){
            Launcher();
        }
    }

    //èáî‘Ç…î≠éÀ
    public void LaunchToOrder(int _num)
    {
        StartCoroutine("CoLaunchToOrder", _num);
    }

    IEnumerator CoLaunchToOrder(int _num)
    {
        for (int i = 0; i < _num; ++i){
            Launcher();
            yield return new WaitForSeconds(0.3f);
        }

    }
}
