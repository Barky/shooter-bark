using System;
using System.Collections;
using System.Collections.Generic;
using _Game.Scripts.Managers;
using TMPro;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class StartedPanel : PanelsMain
{
    public TextMeshProUGUI waveText;
    public Button pauseButton;

    public override void onAwake()
    {
        base.onAwake();
        
        pauseButton.onClick.AddListener(clickedPause);
    }
    void clickedPause()
    {
        GameManager.instance.PauseGame();
    }
    private void OnEnable()
    {
        EnemySpawner.instance.waveSpawn += waveSpawn;
    }

    private void OnDestroy()
    {
        EnemySpawner.instance.waveSpawn -= waveSpawn;
    }

    void waveSpawn(int no, bool isFinal)
    {
        Debug.LogError("evente girdi, " +no +" "+isFinal);
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
waveText.transform.DOShakeScale(4f, 0.4f).OnComplete(() =>waveText.gameObject.SetActive(false));


    }

    
}
