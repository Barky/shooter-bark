using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Bullet : MonoBehaviour
{
    public GameObject part;
    private Health enemyHealth;
    private int damage = 5;

    private void Start()
    {
        Destroy(gameObject , 2);
    }

    public void GetFired(bool isFlame,  int targetno, EnemyController enemy)
    {
        enemyHealth = enemy._health;
        if(isFlame) part.SetActive(true);

        if (enemyHealth.currentHealth - damage <= 0)
        {
            enemy.isDamageable = false;
        }
        transform.DOMove(enemy.hitPoint.transform.position, 1.5f).OnComplete(() => enemyHealth.ChangeHealth(damage) ); 
    }
}
