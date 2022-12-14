using System;
using System.Collections;
using System.Collections.Generic;
using _Game.Scripts.Managers;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private DynamicJoystick joystick;

    private Animator anim;
    private float angle;

    private bool canMove;
    
   

    private Health playerHealth;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        playerHealth = GetComponent<Health>();
    }

    private void Start()
    {
        GameManager.instance.OnGameStateChanged += OnGameStateChanged;
        playerHealth.Change += Damaged;
        playerHealth.onDeath += onDeath;
    }

    private void OnDestroy()
    {
        GameManager.instance.OnGameStateChanged -= OnGameStateChanged;
        playerHealth.Change -= Damaged;

        playerHealth.onDeath -= onDeath;

    }

    private void FixedUpdate()
    {
        if (!canMove) return;
        
        Movement();
    }

    void Movement()
    {
        if (joystick.Horizontal != 0 || joystick.Vertical != 0)
        {
            anim.SetBool("running", true);
             angle = Mathf.Atan2(joystick.Horizontal, joystick.Vertical) * Mathf.Rad2Deg;
             transform.rotation = Quaternion.Euler(new Vector3(0, angle, 0));
             transform.position += (transform.forward * (5f * Time.deltaTime));
        }
        else
        {
            anim.SetBool("running", false);

        }
    }

    void Damaged(float amount)
    {
        
    }
    void onDeath()
    {
        
    }

    private void OnGameStateChanged(GameState state)
    {
        switch (state)
        {
            case (GameState.TapToStart):
                canMove = false;
                break;
            case(GameState.Started):
                canMove = true;
                break;
        }
    }

}
