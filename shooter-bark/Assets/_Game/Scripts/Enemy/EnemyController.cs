using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public Health _health;
    

    public List<Transform> targets;

    private void Awake()
    {
        _health = GetComponent<Health>();
    }

    private void Start()
    {
        _health.onDeath += onDeath;
    }


    private void onDeath()
    {
        
    }
}
