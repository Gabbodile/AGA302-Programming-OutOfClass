using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EnemyType
{
    OneHand,
    TwoHand,
    Archer
}
public class EnemyManager : GameBehaviour<EnemyManager>
{
    public string[] enemyNames;
    public Transform[] spawnPoints;
    public GameObject[] enemyTypes;

    public List<GameObject> enemies;

    void Start()
    {
        SpawnEnemy();
    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.K))
            KillEnemy(enemies[0]);

        if (Input.GetKeyDown(KeyCode.B))
            KillSpecificEnemies("_B");
    }

    void SpawnEnemy()
    {
        for (int i = 0; i < spawnPoints.Length; i++)
        {
            int rnd = Random.Range(0, enemyTypes.Length);
            GameObject go = Instantiate(enemyTypes[rnd], spawnPoints[i].position, spawnPoints[i].rotation);
        }
    }

    void KillSpecificEnemies(string _condition)
    {
        int eCount = enemies.Count;
        for (int i = 0; i < enemies.Count; i++)
        {
            if (enemies[i].name.Contains(_condition))
                KillEnemy(enemies[i]);
        }
    }

    void KillAllEnemies()
    {
        int eCount = enemies.Count;
        for (int i = 0; i <enemies.Count; i++)
        {
            KillEnemy(enemies[1]);
        }
    }

    void KillEnemy(GameObject _enemy)
    {
        if (enemies.Count == 0)
            return;

        Destroy(_enemy);
        enemies.Remove(_enemy);
    }

    float spawnDelay = 3;

    IEnumerator SpawnEnemyDelayed()
    {
        for (int i = 0; i < spawnPoints.Length; i++)
        {
            int rndEnemy = Random.Range(0, enemyTypes.Length);
            GameObject enemy = Instantiate(enemyTypes[rndEnemy], spawnPoints[i].position, spawnPoints[i].rotation);
            enemies.Add(enemy);
            yield return new WaitForSeconds(spawnDelay);
        }
    }

    public void EnemyDied(Enemy _enemy)
    {
        enemies.Remove(_enemy.gameObject);
        print(enemies.Count);
    }
}
