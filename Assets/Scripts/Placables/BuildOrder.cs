using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class BuildOrder : MonoBehaviour
{
    [SerializeField]
    private int workersNeeded = 3;
    [SerializeField]
    private float timeNeeded = 5;

    private int workers = 0;

    public Action<GameObject, Vector3> OnBuildingFinished;

    public BuildOrder(int workers, float time)
    {
        workersNeeded = workers;
        timeNeeded = time;
        workers = 0;
    }

    public void AddWorkers(int sentWorkers)
    {
        workers += sentWorkers;
        workersNeeded -= sentWorkers;

        if(workersNeeded <= 0)
        {
            StartCoroutine(BuildCoroutine());
        }
    }

    private IEnumerator BuildCoroutine()
    {
        yield return new WaitForSeconds(timeNeeded);

    }




}
