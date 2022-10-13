using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class EnemiesData : ScriptableObject
{

    public List<EnemyCollection> EnemyCollections;

    public EnemyController getEnemy(EnemyType type)
    {
        foreach (var a in EnemyCollections)
        {
            if (a.type != type) continue;
            
                return a.enemy;
            
        }

        return null;
    }
    
[Serializable]
    public class EnemyCollection
    {
        public EnemyType type;
        public EnemyController enemy;
    }

}


