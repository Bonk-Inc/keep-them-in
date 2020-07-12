using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject enemyPrefab;

    [SerializeField]
    private Transform spawnPosition;

    public void Spawn()
    {
        GameObject enemy = Instantiate(enemyPrefab);
        enemy.transform.position = spawnPosition.position;

        enemy.transform.SetParent(transform);
    }

}
    