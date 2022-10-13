using System;
using System.Collections;
using System.Collections.Generic;
using _Game.Scripts.Managers;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public static EnemySpawner instance;
    private LevelSettingsSO leveldata => GameManager.instance.leveldata;

    private EnemiesData enemyData => GameManager.instance.enemiesdata;
    private int wavecount => leveldata.enemyWaveCount;

    private int currentwave = 1, wavesLeft = 5;

    private Vector3 currentSpawnPoint;

    private bool canSpawn = true;

    private void Awake()
    {
        GetSingleton();
    }

    private void Start()
    {
        waveSpawn += SpawnWave;
    }

    public event Action<int, bool> waveSpawn;
    
    public void executeSpawnWave()
    {
        if (!canSpawn) return;
        Debug.Log(wavecount +"wavecount");
        waveSpawn?.Invoke(currentwave, isFinalWave());
        currentwave++;
    }

    bool isFinalWave()
    {
        if (currentwave == wavecount)
        {
            canSpawn = false;
            return true;
        }

        return false;

    }
    public void SpawnWave(int currentno, bool isFinal)
    {

        Debug.Log(currentno+ " numaralı wave geldi. " + isFinal + " kaldı.");

        currentSpawnPoint = leveldata.spawnPoints[currentno - 1].transform.position;

        for (int i = 0; i < leveldata.WaveSettingsList[0].count; i++)
        {
            var enemy = Instantiate(enemyData.getEnemy(leveldata.WaveSettingsList[0].firstType), currentSpawnPoint,
                Quaternion.identity);
            
        }
        
        if(isFinal) Debug.Log("bu son wave bilider.");
    }
    
    void GetSingleton()
    {
        if (instance == null) instance = this;
            
    }
}

public enum EnemyType
{
    Plumber = 0
}