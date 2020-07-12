using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnTimer : MonoBehaviour
{
    [SerializeField]
    private AnimationCurve curve;

    [SerializeField]
    private float startSpawnrate = 2, finalSpawnrate = 80;

    [SerializeField]
    private float levelTime;

    [SerializeField]
    private EnemySpawner spawner;

    float elapesTime = 0f;

    public bool EnemiesSpawning { get; private set; }
    public float TimeLeft => Mathf.Max(0, levelTime - elapesTime);

    public event Action OnStartSpawning, OnSpawningFinished;

    public void Start()
    {
        StartCoroutine(SpawnEnemies());
    }

    private IEnumerator SpawnEnemies()
    {
        EnemiesSpawning = true;
        OnStartSpawning?.Invoke();
        elapesTime = 0f;
        float currentSpawnrate = startSpawnrate;
        while(GetCurvePosition(elapesTime) < 1)
        {
            yield return new WaitForSeconds(1 / currentSpawnrate);
            elapesTime += 1 / currentSpawnrate;
            currentSpawnrate = GetCurrentSpawnrate(elapesTime);
            spawner.Spawn();
        }
        EnemiesSpawning = false;
        OnSpawningFinished?.Invoke();
    }

    private float GetCurrentSpawnrate(float elapsedTime)
    {
        float curvePos = GetCurvePosition(elapsedTime);
        float currentSpawnrate = startSpawnrate + ((finalSpawnrate - startSpawnrate) * curve.Evaluate(curvePos));
        return currentSpawnrate;
    }

    private float GetCurvePosition(float elapsedTime)
    {
        return Mathf.Min(1, 1 / levelTime * elapsedTime);
    }

}