using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class BuildManager : MonoBehaviour
{

    [SerializeField]
    private Buildable buildPreset;

    [SerializeField]
    private int maxAvailableWorkers = 15;

    private int availableWorkers = 15;

    private List<BuildOrder> buildQueue = new List<BuildOrder>();

    public void RequestBuilding(Tile tile)
    {
        BuildOrder order = new BuildOrder(buildPreset.WorkersNeeded, buildPreset.BuildTime);
        order.OnBuildingFinished += () => { tile.PlaceObject(buildPreset.BuildingPreset, tile.transform.position); };
        tile.IsOcupied = true;

        buildQueue.Add(order);
    }

    private void Update()
    {
        
    }

    public void ChangeBuildPreset(Buildable preset)
    {
        buildPreset = preset;
    }
}
