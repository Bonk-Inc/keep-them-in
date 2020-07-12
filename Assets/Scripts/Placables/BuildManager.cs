using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class BuildManager : MonoBehaviour
{

    [SerializeField]
    private Buildable buildPreset;

    [SerializeField]
    private BuildOrder buildOrder;

    [SerializeField]
    private int maxAvailableWorkers = 15;

    private int availableWorkers = 15;

    private List<BuildOrder> buildQueue = new List<BuildOrder>();

    public void RequestBuilding(Tile tile)
    {
        BuildOrder order = Instantiate(buildOrder);
        order.Init(buildPreset.WorkersNeeded, buildPreset.BuildTime);
        order.OnBuildingFinished += () => 
        {
            tile.PlaceObject(buildPreset.BuildingPreset, tile.transform.position);
            availableWorkers += buildPreset.WorkersNeeded;
            buildQueue.Remove(order);
            Destroy(order);
        };

        tile.IsOcupied = true;
        buildQueue.Add(order);
    }

    private void Update()
    {
        for (int i = 0; i < buildQueue.Count; i++)
        {
            if(buildQueue[i].WorkersNeeded <= availableWorkers)
            {

            }
        }
    }

    public void ChangeBuildPreset(Buildable preset)
    {
        buildPreset = preset;
    }
}
