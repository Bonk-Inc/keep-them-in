using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class EscapeWall : MonoBehaviour
{
    [SerializeField]
    private GameManegemtHandler manager;

    private void Reset()
    {

        manager = GetComponentInParent<GameManegemtHandler>();    
    }

    private void OnTriggerEnter(Collider other)
    {
        manager.DemonEscaped();
    }

}
