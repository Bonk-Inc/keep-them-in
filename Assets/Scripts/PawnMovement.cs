using UnityEngine;
using UnityEngine.AI;

public class PawnMovement : MonoBehaviour
{
    [SerializeField] private NavMeshAgent navMeshAgent;
    private Vector3 fixedDestenation;

    private void Awake() {
        fixedDestenation = new Vector3(Random.Range(10, 50),transform.position.y, Random.Range(10, 50));
    }

    public void GoToDestenation() {
        SetDestination(fixedDestenation);
    }

    public void SetDestination(Vector3 destination) {
        navMeshAgent.SetDestination(destination);
    }
}