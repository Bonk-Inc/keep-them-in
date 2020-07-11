using UnityEngine.Events;
using UnityEngine;

[System.Serializable]
public class StateData {
    public Enums.PawnStates pawnState;
    public StateEvent calledEvent;
}
[System.Serializable]
public class StateEvent : UnityEvent<Vector3> {}