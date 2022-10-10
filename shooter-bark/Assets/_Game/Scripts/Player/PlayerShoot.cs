using System;
using System.Collections;
using System.Collections.Generic;
using _Game.Scripts.Managers;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{

    [SerializeField] private BulletController bulletprefab;
    public Transform shootPos;
    public Transform destpos;
    private void Start()
    {
        GameManager.instance.OnGameStateChanged += OnGameStateChanged;
    }

    private void OnDestroy()
    {
        GameManager.instance.OnGameStateChanged -= OnGameStateChanged;
    }

    public IEnumerator Shoot()
    {
        while(true)
        {
            var currentbullet = Instantiate(bulletprefab);
            currentbullet.dest_ = destpos.position;
            currentbullet.transform.position = shootPos.position;
            yield return new WaitForSeconds(0.4f);
            yield return null;

        }

    }

    private void OnGameStateChanged(GameState state)
    {
        switch (state)
        {
            case (GameState.TapToStart):
                //do nothin
                break;
            case(GameState.Started):
                StartCoroutine(Shoot());
                break;
        }
        
    }
}
