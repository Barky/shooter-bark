using System;
using System.Collections;
using System.Collections.Generic;
using _Game.Scripts.Managers;
using UnityEditor.VersionControl;
using UnityEngine;
using UnityEngine.AI;

//[RequireComponent(typeof(NavMeshAgent))]
public class EnemyAI : MonoBehaviour
{
    private NavMeshAgent nav => GetComponent<NavMeshAgent>();

    private Transform player => GameManager.instance.player;
    private Health playerHealth;

    public int damage = 1;

    private EnemyController controller => GetComponent<EnemyController>();
    private Animator anim => GetComponent<Animator>();

    private void Start()
    {
        controller._health.onDeath += onDeath;
      playerHealth =  player.gameObject.GetComponent<Health>();
    }

    private void OnDestroy()
    {
        controller._health.onDeath -= onDeath;

    }

    private void Update()
    {
        if (Vector3.Distance(transform.position, player.position) > 1f)
        {
            Chase();
        }
        
        else 

        {
            Attack();
        }
    }

    void Chase()
    {
        if (anim.GetBool("punching"))
        {
            anim.SetBool("punching", false);

        }
        nav.enabled = true;
        transform.LookAt(player);
        anim.SetBool("running", true);
        nav.destination = player.position;
    }

    void Attack()
    {
        if (anim.GetBool("running"))
        {
            anim.SetBool("running", false);

        }
        nav.enabled = false;
        anim.SetBool("punching", true);
        playerHealth.ChangeHealth(damage);

        
    }

    void onDeath()
    {
        Destroy(this);
    }
}
