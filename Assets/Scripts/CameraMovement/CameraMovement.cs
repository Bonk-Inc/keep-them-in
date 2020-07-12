using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField]
    private float speed = 0.01f;

    private Vector2 prevMousePosition = Vector2.zero;
    private Vector2 mouseDelta = Vector2.zero;

    [SerializeField]
    private WorldBounds bounds;

    private void Awake()
    {
        prevMousePosition = Input.mousePosition;
        bounds.CalculateBounds();
    }

    private void Update()
    {
        UpdateMouseinfo();
        MoveCamera();
    }

    private void UpdateMouseinfo()
    {
        mouseDelta = prevMousePosition - (Vector2)Input.mousePosition;
        prevMousePosition = Input.mousePosition;
    }

    private void MoveCamera()
    {
        if (!Input.GetMouseButton(1))
            return;
        var movement = new Vector3(mouseDelta.x, 0, mouseDelta.y) * speed;
        var newPosition = transform.position;
        newPosition += movement;
        newPosition = bounds.ClampPosition(newPosition);
        transform.position = newPosition;

    }




}
