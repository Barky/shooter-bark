using System;
using System.Collections;
using System.Collections.Generic;
using _Game.Scripts.Managers;
using UnityEngine;
using UnityEngine.UI;

public class PausePanel : PanelsMain
{
    [SerializeField] private Button continueButton;

    private void OnEnable()
    {
        continueButton.onClick.AddListener(continueGame);
    }


    void continueGame()
    {
        GameManager.instance.ContinueGame();
    }
}
