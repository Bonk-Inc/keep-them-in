using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedModifier : Modifier
{

    [SerializeField]
    private float modifiedTimescale = 1.5f;

    public override void Modify()
    {
        print(name);
        Time.timeScale = modifiedTimescale;
    }
}
