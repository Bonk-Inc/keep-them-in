using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedTargeter : MonoBehaviour
{
    private const int SEARCH_LIMIT = 5;

    [SerializeField]
    private LayerMask mask;

    [SerializeField]
    private float maxDistance = Mathf.Infinity;

    public GameObject Target { get; private set; }

    public event Action<GameObject> OnTargetChanged;

    private void Update()
    {
        if (Target == null || Vector3.Distance(Target.transform.position, transform.position) > maxDistance)
        {
            SetTarget(null);
            FindTarget();
        }
    }

    private void FindTarget()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, maxDistance, mask);
        colliders = SortColliders(colliders);

        if (colliders.Length == 0)
            return;

        GameObject newTarget = colliders[0].gameObject;
        SetTarget(newTarget);
    }

    private void SetTarget(GameObject newTarget)
    {
        if (this.Target == newTarget)
            return;

        Target = newTarget;
        OnTargetChanged?.Invoke(Target);
    }

    private Collider[] SortColliders(Collider[] colliders)
    {
        List<Collider> colliderList = new List<Collider>(colliders);
        colliderList.Sort(new ColliderDistanceComparer(transform.position));
        return colliderList.ToArray();
    }

    private void OnDrawGizmos()
    {
        if (maxDistance < Mathf.Infinity)
            Gizmos.DrawWireSphere(transform.position, maxDistance);

    }


}
