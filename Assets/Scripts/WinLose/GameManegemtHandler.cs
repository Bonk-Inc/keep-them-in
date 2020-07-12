using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameManegemtHandler : MonoBehaviour
{

    [Header("Win condition"), SerializeField]
    private Transform enemyParent;
    [SerializeField]
    private EnemySpawnTimer spawnTimer;

    [Header("Events")]
    public UnityEvent OnLevelWon;
    public UnityEvent OnLevelLost;

    private bool gameEnded = false;

    private void Start()
    {
        SetupWinCondition();
    }

    private void SetupWinCondition()
    {
        spawnTimer.OnSpawningFinished += () => {
            if (gameEnded)
                return;

            Debug.Log("Winner winner sushi dinner");
            gameEnded = true;
            OnLevelWon?.Invoke();
        };
    }

    public void DemonEscaped()
    {
        if (gameEnded)
            return;

        Debug.Log("big sad :(");
        gameEnded = true;
        OnLevelLost?.Invoke();
    }
}
