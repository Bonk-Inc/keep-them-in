using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHitHandler : MonoBehaviour, IHittableEnemy
{
    public void Hit(HittableParams param)
    {
        Destroy(gameObject);//RIP enemy :(
    }

}
