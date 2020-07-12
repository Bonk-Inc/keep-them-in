using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Purchasable", menuName = "Buildable/Info")]
public class Buildable : ScriptableObject
{
    [SerializeField]
    private float buildTime;
    [SerializeField]
    private int workersNeeded;
    [SerializeField]
    private GameObject buildingPreset;

    public float BuildTime => buildTime;
    public int WorkersNeeded => workersNeeded;
    public GameObject BuildingPreset => buildingPreset;

}
