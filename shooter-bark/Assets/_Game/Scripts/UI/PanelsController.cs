using System;
using System.Collections;
using System.Collections.Generic;
using _Game.Scripts.Managers;
using UnityEngine;
using UnityEngine.UI;


public class PanelsController : MonoBehaviour
{
    public List<PanelsMain> panels = new List<PanelsMain>();

    private void Start()
    {
        GameManager.instance.OnGameStateChanged += OnGameStateChanged;
    }

    private void OnDestroy()
    {
        GameManager.instance.OnGameStateChanged -= OnGameStateChanged;
    }

    private void OnGameStateChanged(GameState state)
    {
        switch (state)
        {
            case(GameState.TapToStart):
                OpenNeededPanel(panels[0]);
                break;
            case(GameState.Started):
                OpenNeededPanel(panels[1]);
                break;
            case(GameState.Finished):
                OpenNeededPanel(panels[2]);
                break;
            case(GameState.Win):
                OpenNeededPanel(panels[3]);
                break;
            case(GameState.Fail):
                OpenNeededPanel(panels[4]);
                break;
        }
    }

    private void OpenNeededPanel(PanelsMain openpanel)
    {
        foreach (var a in panels)
        {
            if(a ==  openpanel) a.Open();
            else a.Close();
        }
    }
}
