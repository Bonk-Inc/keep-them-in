using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedDefenceShootingBehavior : MonoBehaviour
{

    [SerializeField]
    private float fireRate = 0.2f;

    [SerializeField]
    private RangedTargeter targeter;

    [SerializeField]
    private ShootingHandler shooter;

    public event Action<GameObject> OnTargetChanged { add => targeter.OnTargetChanged += value; remove => targeter.OnTargetChanged -= value; }
    public event Action<GameObject> OnShotAtTarget;

    private void Start()
    {
        StartCoroutine(ShootingRoutine());
    }

    private IEnumerator ShootingRoutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(fireRate);
            Shoot();
        }
    }

    private void Shoot()
    {
        if (targeter.Target == null)
            return;

        GameObject target = targeter.Target;
        shooter.Shoot(target);
        OnShotAtTarget?.Invoke(target);
    }

}
