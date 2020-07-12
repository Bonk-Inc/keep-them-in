using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class BuildOrder : MonoBehaviour
{
    [SerializeField]
    private GameObject rubble;

    [SerializeField]
    private int workersNeeded = 3;
    [SerializeField]
    private float timeNeeded = 5;

    private int workers = 0;

    public int Workers => workers;
    public int WorkersNeeded => workersNeeded;

    public event Action OnBuildingFinished;

    public void Init(int workersNeeded, float time)
    {
        this.workersNeeded = workersNeeded;
        print(this.workersNeeded + " " + workersNeeded);
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

        OnBuildingFinished?.Invoke();
        rubble.SetActive(false);
    }
}
