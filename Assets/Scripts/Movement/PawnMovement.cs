using UnityEngine;
using UnityEngine.AI;

public class PawnMovement : MonoBehaviour
{
    [SerializeField]
    private NavMeshAgent navMeshAgent;
    private Vector3 fixedDestenation;

    private void Awake() {
        fixedDestenation = new Vector3(Random.Range(-50, 50), transform.position.y, Random.Range(-50, 50));
        if (fixedDestenation.x < 20 && fixedDestenation.x > 0) {
            fixedDestenation.x = 20;
        }
        if (fixedDestenation.z < 20 && fixedDestenation.z > 0) {
            fixedDestenation.z = 20;
        }
        if (fixedDestenation.x > -20 && fixedDestenation.x < 0) {
            fixedDestenation.x = -20;
        }
        if (fixedDestenation.z > -20 && fixedDestenation.z < 0) {
            fixedDestenation.z = -20;
        }
    }

    private void FixedUpdate() {
        if (navMeshAgent.remainingDistance < .5f) {
            GoToDestenation();
        }
    }

    public void GoToDestenation() {
        SetDestination(fixedDestenation);
    }

    public void SetDestination(Vector3 destination) {
        navMeshAgent.SetDestination(destination);
    }
}