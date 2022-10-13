using System;
using System.Collections;
using System.Collections.Generic;
using _Game.Scripts.Managers;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{

    private WeaponType currentweapon;
    private BulletType currentbullet;
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
            case (GameState.TapToStart):
                //do nothin
                break;
            case(GameState.Started):
                
                break;
        }
        
    }
}
