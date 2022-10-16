using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public Health _health;
    public Transform hitPoint;
    public bool isDamageable;

    private void Awake()
    {
        _health = GetComponent<Health>();
    }

    private void Start()
    {
        _health.onDeath += onDeath;
        isDamageable = true;
    }


    private void onDeath()
    {
        
    }
}
