using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetingRotator : MonoBehaviour
{
    [SerializeField]
    private RangedTargeter targeter;

    [SerializeField]
    private GameObject target;

    [SerializeField]
    private float rotationSpeed = Mathf.Infinity;

    private void Awake()
    {
        targeter.OnTargetChanged += SetTarget;
    }

    private void Update()
    {
        if (target == null)
            return;

        float step = rotationSpeed * Time.deltaTime;
        Vector3 targetDirection = target.transform.position - transform.position;
        Vector3 newDirection = Vector3.RotateTowards(transform.forward, targetDirection, step, 0.0f);
        transform.rotation = Quaternion.LookRotation(newDirection);
    }

    public void SetTarget(GameObject target)
    {
        this.target = target;
    }
}
