using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public static class GameEvents
{
    public static event Action<Enemy> OnEnemyHit = null;
    public static event Action<Enemy> OnEnemyDied = null;

    //Debug reports
    public static void ReportEnemyHit(Enemy _enemy)
    {
        Debug.Log("Enemy " + _enemy.name + " was hit" );
        OnEnemyHit?.Invoke(_enemy);
    }

    public static void ReportEnemyDied(Enemy _enemy)
    {
        Debug.Log("Enemy " + _enemy.name + " died");
        OnEnemyDied?.Invoke(_enemy);
    }
}
