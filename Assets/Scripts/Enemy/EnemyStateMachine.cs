using UnityEngine;

[RequireComponent(typeof(Sence))]
public class EnemyStateMachine : MonoBehaviour {

    [SerializeField]
    private StateData[] states;

    private Sence sence;
    private PawnMovement pawnMovement;
    private Vector3 target = Vector3.zero;

    private void Start() {
        sence = GetComponent<Sence>();
        pawnMovement = GetComponent<PawnMovement>();
        SwitchState(Enums.PawnStates.Moving);
        sence.MoveToTarget += Chace;
    }
    private void OnDisable() {
        sence.MoveToTarget -= Chace;
    }

    public void SwitchState(Enums.PawnStates pawnState) {
        states[(int)pawnState].calledEvent.Invoke(target);
    }

    private void Chace(Vector3 newTarget) {
        target = newTarget;
        SwitchState(Enums.PawnStates.Chasing);
    }
}