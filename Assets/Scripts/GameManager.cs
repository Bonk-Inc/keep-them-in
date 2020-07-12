using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{

    [Header("Win condition"), SerializeField]
    private Transform enemyParent;
    [SerializeField]
    private EnemySpawnTimer spawnTimer;

    [Header("Events")]
    public UnityEvent OnLevelWon;
    public UnityEvent OnLevelLost;

    private void Start()
    {
        SetupWinCondition();
    }

    private void SetupWinCondition()
    {
        spawnTimer.OnSpawningFinished += () => StartCoroutine(CheckWin());
    }


    private IEnumerator CheckWin()
    {
        while (enemyParent.childCount > 0) yield return null;
        Debug.Log("Winner winner sushi dinner");
        OnLevelWon?.Invoke();
    }

}
