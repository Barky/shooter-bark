using System;
using System.Collections;
using System.Collections.Generic;
using _Game.Scripts.Managers;
using UnityEngine;

public class Health : MonoBehaviour
{
    public event Action<float> Change;
    public event Action onDeath;

    private GameState currentstate;
    
    public float currentHealth;
   public float defaultHealth;

    private void Awake()
    {
        currentHealth = defaultHealth;
    }

    private void Start()
    {
        GameManager.instance.OnGameStateChanged += onGameStateChanged;
    }

    private void OnDestroy()
    {
        GameManager.instance.OnGameStateChanged -= onGameStateChanged;
    }

    public void ChangeHealth(float amount)
    {
        
       // if (currentstate != GameState.Started || currentHealth <= 0) return;

        currentHealth = Mathf.Clamp((currentHealth - amount), 0, defaultHealth);
        Debug.Log(gameObject.name + " hasar aldım= "+ currentHealth);
        Change?.Invoke(amount);
        
        if(currentHealth == 0)
        {
            onDeath?.Invoke();
        }
        
        

    }
    private void onGameStateChanged(GameState state)
    {
        currentstate = state;
    }
}
