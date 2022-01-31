using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveController : MonoBehaviour
{
    [System.Serializable]
    public struct ShotData
    {
        public float shotTime;
        //一度に打つ量
        public int oneShotNum;
    }
    public List<ShotData> shotDatas = new List<ShotData>();

    private float elpsedTime;

    private int shotCount;

    public WaveManager myManager;

    public List<LauncherManager> launchers = new List<LauncherManager>();
    private void Start()
    {
        elpsedTime = 0f;
        shotCount = 0;
    }

    public void ActiveWaveUpdate()
    {
        elpsedTime += Time.deltaTime;
        if (shotCount < shotDatas.Count)
        {
            if (elpsedTime > shotDatas[shotCount].shotTime)
            {
                WhichLaunchersShot();
                elpsedTime = 0f;
                shotCount++;
            }
        }
        else
        {
            StartCoroutine(myManager.FinishWave());
        }
    }

    private void WhichLaunchersShot()
    {
        int shotNum = Random.Range(1, shotDatas[shotCount].oneShotNum - 1);
        launchers[0].LaunchToOrder(shotNum);      
        if(shotDatas[shotCount].oneShotNum-shotNum>0)
        {
            launchers[1].LaunchToOrder(shotDatas[shotCount].oneShotNum - shotNum);
        }
    }
}
