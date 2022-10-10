using System;
using System.Collections;
using System.Collections.Generic;
using _Game.Scripts.Managers;
using UnityEngine;
using UnityEngine.UI;

public class TapToStartPanel : PanelsMain

{
    [SerializeField] private Button taptostartbutton;


    public override void onAwake()
    {
        taptostartbutton.onClick.AddListener(tappedFirsttime);
    }

    public void tappedFirsttime()
    {
        GameManager.instance.SetGameState(GameState.Started);
    }
    
    
}
