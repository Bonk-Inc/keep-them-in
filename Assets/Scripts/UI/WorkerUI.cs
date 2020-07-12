using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorkerUI : MonoBehaviour
{

    [SerializeField]
    private TMPro.TextMeshProUGUI maxAvailibleUI, availibleUI;

    [SerializeField]
    private BuildManager manager;
    private void Start()
    {
        SetAvailibleUI(manager.MaxAvailableWorkers);
        SetMaxAvailibleUI(manager.AvailableWorkers);
        manager.OnAvailableWorkersChange += SetAvailibleUI;
        manager.OnMaxAvailableWorkersChange += SetMaxAvailibleUI;
    }

    private void SetMaxAvailibleUI(int amount)
    {
        maxAvailibleUI.text = amount.ToString();
    }

    private void SetAvailibleUI(int amount)
    {
        availibleUI.text = amount.ToString();
    }

}
