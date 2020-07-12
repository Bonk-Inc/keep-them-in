using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeModifier : Modifier
{
    [SerializeField]
    private float modifiedTime = 5 * 60;

    [SerializeField]
    private EnemySpawnTimer timer;

    public override void Modify()
    {
        print(name);
        timer.SetLevelTime(modifiedTime);
    }
}
