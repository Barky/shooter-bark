using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using DG.Tweening;

public class StartedPanel : PanelsMain
{
    public TextMeshProUGUI waveText;

    private void Start()
    {
        EnemySpawner.instance.waveSpawn += waveSpawn;
    }

    void waveSpawn(int no, bool isFinal)
    {
        Debug.Log("evente girdi, " +no +" "+isFinal);
        waveText.gameObject.SetActive(true);
        if (isFinal)
        {
            waveText.text = "FINAL WAVE IS COMING!";
            
        }
else
        {
            switch (no)
            {
                case (1):
                    waveText.text = "FIRST WAVE IS COMING!";
                    break;
                case (2):
                    waveText.text = "SECOND WAVE IS COMING!";
                    break;
                case (3):
                    waveText.text = "THIRD WAVE IS COMING!";
                    break;
                case (4):
                    waveText.text = "FORTH WAVE IS COMING!";
                    break;
            }
        }
waveText.transform.DOShakeScale(2f).OnComplete(() =>waveText.gameObject.SetActive(false));


    }
}
