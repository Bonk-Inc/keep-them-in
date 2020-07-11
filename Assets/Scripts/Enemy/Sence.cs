using UnityEngine;
using System;
[RequireComponent(typeof (PawnMovement))]
public class Sence : MonoBehaviour {
    [SerializeField]
    private float checkRadius;
    [SerializeField]
    private LayerMask checkLayers;
    [SerializeField]
    private string targetTag = "NPC";

    private bool hasTarget;
    private PawnMovement pawnMovement;
    private Collider target;

    public event Action<Vector3> MoveToTarget;

    private void Awake() {
        pawnMovement = GetComponent<PawnMovement>();
    }

    private void Update() {
        Collider[] colliders = Physics.OverlapSphere(transform.position, checkRadius, checkLayers);
        Array.Sort(colliders, new DistanceComparer(transform));
        if (colliders.Length > 0 && target != colliders[0] && colliders[0].CompareTag(targetTag)) {
            target = colliders[0];
            MoveToTarget(colliders[0].transform.position);
        }
    }

    private void OnDrawGizmos() {
        Gizmos.DrawWireSphere(transform.position, checkRadius);
    }
}
