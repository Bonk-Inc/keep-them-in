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

    private TownGrid grid;

    public TownGrid Grid { get => grid; set => grid = value; }

    public bool PlaceObject(GameObject placement, Vector3 position)
    {
        if (isOcupied)
            return false;

        ocupiedPlacement = placement;
        placement.transform.position = position;
        isOcupied = true;

        return true;
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
