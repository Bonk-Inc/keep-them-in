using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetingRotator : MonoBehaviour
{
    [SerializeField]
    private RangedTargeter targeter;

    [SerializeField]
    private GameObject target;

    private void Awake()
    {
        targeter.OnTargetChanged += SetTarget;
    }

    private void Update()
    {
        if (target == null)
            return;

        Vector3 newDirection = Vector3.RotateTowards(transform.forward, (target.transform.position - transform.position), Mathf.Infinity, 0.0f);
        transform.rotation = Quaternion.LookRotation(newDirection);
    }

    public void SetTarget(GameObject target)
    {
        this.target = target;
    }



}
