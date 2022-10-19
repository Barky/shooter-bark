using System;
using System.Collections;
using System.Collections.Generic;
using _Game.Scripts.Managers;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthBar : MonoBehaviour
{
    private Health playerHealth;

    [SerializeField] private Slider healthSlider;

    private int maxHealth;

    private float minusPerc;

    private void Awake()
    {
        playerHealth = GetComponent<Health>();
    }

    private void Start()
    {
        playerHealth.Change += ChangeHealth;
        GameManager.instance.OnGameStateChanged += OnGameStateChanged;
        maxHealth =(Int32)playerHealth.defaultHealth;    }

    void started()
    {
        healthSlider.gameObject.SetActive(true);
        
        healthSlider.value = 1f;
    }

    private void ChangeHealth(float amount)
    {
        minusPerc = amount / maxHealth;

        healthSlider.value -= minusPerc;
    }
    private void OnGameStateChanged(GameState state)
    {
        switch (state)
        {
            case (GameState.TapToStart):
                healthSlider.gameObject.SetActive(false);
                break;
            case(GameState.Started):
                started();
                break;
        }
    }
}
