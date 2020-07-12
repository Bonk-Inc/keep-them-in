using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnModifier : Modifier
{
    [SerializeField]
    private float modifiedSpawnrate = 120;

    [SerializeField]
    private EnemySpawnTimer timer;

    public override void Modify()
    {
        print(name);
        timer.FinalSpawnrate = modifiedSpawnrate;
    }
}
