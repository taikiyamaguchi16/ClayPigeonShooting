using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveManager : MonoBehaviour
{
    private int waveCount;
    public List<WaveController> wavesList = new List<WaveController>();

    private bool changeNow;
    // Start is called before the first frame update
    void Start()
    {
        waveCount = 0;
        changeNow = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(waveCount<wavesList.Count)
        {
            if(!changeNow)
                wavesList[waveCount].ActiveWaveUpdate();
        }
    }


    public IEnumerator FinishWave()
    {
        //ここで少し待って切り替わり演出入れるといいかも
        changeNow = true;
        Debug.Log("waveを切り替えます");
        yield return new WaitForSeconds(5f);
        waveCount++;
        Debug.Log("切り替わりました");
        changeNow = false;
        yield break;
    }
}
