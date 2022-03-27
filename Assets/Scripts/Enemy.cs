using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : GameBehaviour
{
    float moveDistance = 500;

    public EnemyType myType;
    public int myHealth;

    void Start()
    {
        SetUp();
    }
    void SetUp()
    {
        switch(myType)
        {
            case EnemyType.Archer:
                myHealth = 50;
                break;
            case EnemyType.OneHand:
                myHealth = 100;
                break;
            case EnemyType.TwoHand:
                myHealth = 200;
                break;
        }
    }

    IEnumerator Move()
    {
        for(int i = 0; i < moveDistance; i ++)
        {
            transform.Translate(Vector3.forward * Time.deltaTime);
            yield return null;
        }
        transform.Rotate(Vector3.up * 180);
        yield return new WaitForSeconds(3);
        StartCoroutine(Move());
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.H))
            Hit(10);
    }

    void Hit(int _damage)
    {
        myHealth -= _damage;
        GameEvents.ReportEnemyHit(this);

        if (myHealth <= 0)
            Die();
    }

    void Die()
    {
        GameEvents.ReportEnemyDied(this);
        StopAllCoroutines();
        Destroy(this.gameObject);
    }
}
