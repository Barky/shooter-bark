using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LoadingPanel : MonoBehaviour
{

    [SerializeField] private Slider loadingSlider;
    [SerializeField] private TextMeshProUGUI loadingText;
    private int loadingPerc, textPerc;
    private float sliderPerc, sliderPlus;

    private int loadCount;

    private void Awake()
    {
        
    }

    private void Start()
    {
        LevelManager.instance.LoadNextLevel += loadLevel;

        loadCount = LevelManager.instance.LoadCount;
        
        loadingPerc = 0;
        textPerc = Mathf.RoundToInt(100 / loadCount);
        // loadingSlider.value = 0.3f;
        sliderPlus = 0;
        // sliderPerc = 1 / loadCount;
        sliderPerc = 0.25f;
    }

    private void loadLevel()
    {
        StartCoroutine(loadLevelco());
    }


    IEnumerator loadLevelco()
    {
        
        for (int i = 0; i <= loadCount; i++)
        {
            loadingText.text = "%" + loadingPerc;
            loadingSlider.value = sliderPlus;
            yield return new WaitForSeconds(1f);
            loadingPerc= Mathf.Clamp(loadingPerc + textPerc, 0, 100);

            sliderPlus += sliderPerc;
        }
        
    }
}
