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

    public void Start()
    {
        StartCoroutine(SpawnEnemies());
    }

    private IEnumerator SpawnEnemies()
    {
        float elapesTime = 0f;
        float currentSpawnrate = startSpawnrate;
        while(true)
        {
            yield return new WaitForSeconds(1 / currentSpawnrate);
            elapesTime += 1 / currentSpawnrate;
            currentSpawnrate = GetCurrentSpawnrate(elapesTime);
            spawner.Spawn();
        }
    }

    private float GetCurrentSpawnrate(float elapsedTime)
    {
        float curvePos = Mathf.Min(1, 1 / levelTime * elapsedTime);
        float currentSpawnrate = startSpawnrate + ((finalSpawnrate - startSpawnrate) * curve.Evaluate(curvePos));
        return currentSpawnrate;
    }

}