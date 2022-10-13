using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Bullet : MonoBehaviour
{
    public GameObject part;

    public void GetFired(bool isFlame,  int targetno, EnemyController enemy)
    {
        if(isFlame) part.SetActive(true);
        transform.DOMove(enemy.targets[targetno].position, 2f);
    }
}
