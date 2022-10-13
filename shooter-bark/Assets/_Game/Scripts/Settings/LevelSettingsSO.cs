using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu]
public class LevelSettingsSO : ScriptableObject
{
    public int enemyWaveCount;

    public List<waveSettings> WaveSettingsList;

    public List<TransformPoint> spawnPoints;


    [Serializable]
    public class waveSettings
    {
        public EnemyType firstType = EnemyType.Plumber;
        public int count;
    }
    
}
