using UnityEngine;
using UnityEngine.AI;

public class PawnMovement : MonoBehaviour
{
    [SerializeField]
    private NavMeshAgent navMeshAgent;
    [SerializeField]
    private Vector3 fixedDestination;
    [SerializeField]
    private bool randomDestenation = true;

    private void Awake() {
        if(randomDestenation) {
        fixedDestination = new Vector3(Random.Range(-100, 100), transform.position.y, Random.Range(-100, 100));
        fixedDestination = fixedDestination.normalized * 50;
        } else {
            fixedDestination = transform.position;
        }
    }

    private void FixedUpdate() {
        if (navMeshAgent.remainingDistance < .2f) {
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