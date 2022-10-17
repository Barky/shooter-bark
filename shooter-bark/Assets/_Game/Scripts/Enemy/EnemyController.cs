using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public Health _health;
    public Transform hitPoint;
    public bool isDamageable;
    public EnemySpawner spawner;
    private Animator anim => GetComponent<Animator>();

    private void Awake()
    {
        _health = GetComponent<Health>();
    }

    private void Start()
    {
        _health.onDeath += onDeath;
        isDamageable = true;
    }

    private void OnDisable()
    {
        _health.onDeath -= onDeath;
    }

    

    private void onDeath()
    {
spawner.RemoveEnemy(this);
anim.SetBool("died", true);
Destroy(gameObject, 1f);
//disable

    }
}
