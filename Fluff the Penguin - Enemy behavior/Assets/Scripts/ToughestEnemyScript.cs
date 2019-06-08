using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToughestEnemyScript : MonoBehaviour
{
    private int count = 0;
    private EnemyHealth toughestHP;
    private EnemyMovement toughestMove;
    public PenguinHealth penHP;
    public GameObject enemy;
    public float spawnTime = 3.0f;
    public Transform[] spawnPoints;

    void OnEnable()
    {
        toughestHP = enemy.GetComponent<EnemyHealth>();
        toughestMove = enemy.GetComponent<EnemyMovement>();
        toughestHP.startHealth = 16;
        toughestMove.nav.speed = 19.5f;
        InvokeRepeating("Spawn", spawnTime, spawnTime);
    }

    void Spawn()
    {
        if (count >= 3)
        {
            CancelInvoke();
            return;
        }

        if (PenguinHealth.lives <= 0)
        {
            CancelInvoke();
            return;
        }

        // Find a random index between zero and one less than the number of spawn points.
        int spawnPointIndex = Random.Range(0, spawnPoints.Length);

        // Create an instance of the enemy prefab at the randomly selected spawn point's position and rotation.
        Instantiate(enemy, spawnPoints[spawnPointIndex].position, spawnPoints[spawnPointIndex].rotation);
        count++;
    }
}
