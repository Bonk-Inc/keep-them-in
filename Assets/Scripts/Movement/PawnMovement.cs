using UnityEngine;
using UnityEngine.AI;

public class PawnMovement : MonoBehaviour
{
    [SerializeField]
    private NavMeshAgent navMeshAgent;
    private Vector3 fixedDestination;

    private void Awake() {
        fixedDestination = new Vector3(Random.Range(-100, 100), transform.position.y, Random.Range(-100, 100));
        fixedDestination = fixedDestination.normalized * 50;
    }

    private void FixedUpdate() {
        if (navMeshAgent.remainingDistance < .5f) {
            GoToDestenation();
        }
    }

    public void GoToDestenation() {
        SetDestination(fixedDestination);
    }

    public void SetDestination(Vector3 destination) {
        navMeshAgent.SetDestination(destination);
    }
}