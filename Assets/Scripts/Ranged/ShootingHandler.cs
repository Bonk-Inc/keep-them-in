using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingHandler : MonoBehaviour
{
    [SerializeField]
    private PhysicsProjectile projectilePrefab;

    [SerializeField]
    private Transform launchTransform;

    [SerializeField]
    private float launchPower;

    private void Reset()
    {
        launchTransform = transform;
    }

    public void Shoot(GameObject target)
    {
        PhysicsProjectile projectile = Instantiate(projectilePrefab);
        projectile.transform.SetParent(launchTransform);
        projectile.transform.localPosition = Vector3.zero;
        projectile.Launch(target.transform, launchPower);
    }   
}
