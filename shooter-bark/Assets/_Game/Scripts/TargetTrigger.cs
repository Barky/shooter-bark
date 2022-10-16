using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class TargetTrigger : MonoBehaviour
{

    public event Action<EnemyController> targetPicker;

    public List<EnemyController> currentEnemies;

    public EnemyController currentTarget;

    private void Update()
    {
        // constantly sort array
    }

    public void enemyPicker()
    {
        currentTarget = SetTarget();
        targetPicker?.Invoke(currentTarget);
    }

    public EnemyController SetTarget()
    {
        if (sortByDistance() == null) return null;
        
        return sortByDistance()[0];
    }

    public List<EnemyController> sortByDistance()
    {
        if (!currentEnemies.Any()) return null;
        currentEnemies = currentEnemies.OrderBy(x => Vector3.Distance(transform.position, x.transform.position)).ToList();

        return currentEnemies;

    }

    public void RemoveEnemy(EnemyController enemy)
    {
        currentEnemies.Remove(enemy);
        enemyPicker();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.gameObject.CompareTag("Enemy")) return;
        
        currentEnemies.Add(other.gameObject.GetComponent<EnemyController>());
        enemyPicker();
    }

    private void OnTriggerExit(Collider other)
    {
        if (!other.gameObject.CompareTag("Enemy")) return;

        currentEnemies.Remove(other.gameObject.GetComponent<EnemyController>());
        enemyPicker();
    }
    
    
}
