using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    [SerializeField]
    private GameObject ocupiedPlacement;

    [SerializeField]
    private bool isOcupied = false;

    [SerializeField]
    private bool isBroken = false;

    public Vector2Int debugLocation;

    private BuildManager buildManager;
    public BuildManager BuildManager { get => buildManager; set => buildManager = value; }

    private TownGrid grid;
    public TownGrid Grid { get => grid; set => grid = value; }
    public bool IsOcupied { get => isOcupied; set => isOcupied = value; }

    public void buildObject()
    {
        if(!IsOcupied && !isBroken)
            buildManager?.RequestBuilding(this);
    }

    public void PlaceObject(GameObject placement, Vector3 position)
    {
        placement = Instantiate(placement);
        ocupiedPlacement = placement;

        placement.transform.SetParent(this.transform);
        placement.transform.position = position;
    }

    public bool BreakDown(GameObject rubbage, Vector3 position)
    {
        if (ocupiedPlacement == null || isBroken)
            return false;
        DestroyImmediate(ocupiedPlacement);

        ocupiedPlacement = rubbage;
        rubbage.transform.position = position;
        isBroken = true;

        return true;
    }
        
}
