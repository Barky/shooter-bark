using System;
using System.Collections;
using System.Collections.Generic;
using _Game.Scripts.Managers;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemySpawner : MonoBehaviour
{
    public static EnemySpawner instance;
    private LevelSettingsSO leveldata => GameManager.instance.leveldata;

    private EnemiesData enemyData => GameManager.instance.enemiesdata;
    private int wavecount => leveldata.enemyWaveCount;

    private int currentwave = 1, wavesLeft = 5;

    private Vector3 currentSpawnPoint;

    private List<EnemyController> waveEnemies = new List<EnemyController>();
    
    

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
    public event Action FinalWave;
    
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


        currentSpawnPoint = leveldata.spawnPoints[currentno - 1].transform.position;

        for (int i = 0; i < leveldata.WaveSettingsList[currentno - 1].firstcount; i++)
        {
            var enemy = Instantiate(enemyData.getEnemy(leveldata.WaveSettingsList[0].firstType), currentSpawnPoint + new Vector3(Random.Range(-1,1), 0f, Random.Range(-1,1)),
                Quaternion.identity);
            EnemyController enemycont = enemy.GetComponent<EnemyController>();
            enemycont.spawner = this;
            waveEnemies.Add(enemycont);
            
        }
        
        for (int i = 0; i < leveldata.WaveSettingsList[currentno - 1].secondcount; i++)
        {
            var enemy = Instantiate(enemyData.getEnemy(leveldata.WaveSettingsList[0].secondType), currentSpawnPoint + new Vector3(Random.Range(-2,2), 0f, Random.Range(-2,2)),
                Quaternion.identity);
            EnemyController enemycont = enemy.GetComponent<EnemyController>();
            enemycont.spawner = this;
            waveEnemies.Add(enemycont);
            
        }        
        if(isFinal) FinalWave?.Invoke();
    }

    public void RemoveEnemy(EnemyController enemy)
    {
        waveEnemies.Remove(enemy);

        if (waveEnemies.Count == 0)
        {
            executeSpawnWave();
        }
    }
    
    void GetSingleton()
    {
        if (instance == null) instance = this;
            
    }
}

public enum EnemyType
{
    Plumber = 0,
    Clown = 1
}