using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveController : MonoBehaviour
{
    public List<float> shotTimes = new List<float>();

    //二連続撃ちの回数
    public int doubuleShotNum;
    //三連続うちの回数
    public int tripleShotNum;

    private float elpsedTime;

    private int shotCount;

    public WaveManager myManager;
    private void Start()
    {
        elpsedTime = 0f;
        shotCount = 0;
    }

    public void ActiveWaveUpdate()
    {
        elpsedTime += Time.deltaTime;
        if (shotCount < shotTimes.Count)
        {
            if (elpsedTime > shotTimes[shotCount])
            {
                Debug.Log(this.gameObject.name+"弾を発射");
                elpsedTime = 0f;
                shotCount++;
            }
        }
        else
        {
            StartCoroutine(myManager.FinishWave());
        }
    }
}
