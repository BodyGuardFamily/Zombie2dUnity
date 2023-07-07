using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public static bool enemyKilled;
    public Money moneyScript;

    void Start()
    {
        moneyScript = FindObjectOfType<Money>();
        enemyKilled = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<EnemyMovement>())
        {
            Destroy(collision.gameObject);
            Destroy(gameObject);
            Debug.Log("Enemy killed");

            enemyKilled = true;
            if (moneyScript != null)
            {
                moneyScript.IncrementScore();
                enemyKilled = false;
            }
            else
            {
                Debug.LogError("Money script not found!");
            }

        }
    }

}
