using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class WorldBounds
{
    [SerializeField]
    private Transform cornerOne, cornerTwo;

    public Vector3 MinPosition { get; private set; }
    public Vector3 MaxPosition { get; private set; }

    public Transform CornerOne => cornerOne;
    public Transform CornerTwo => cornerTwo;

    public Vector3 ClampPosition(Vector3 position) {
        position.x = Mathf.Clamp(position.x, MinPosition.x, MaxPosition.x);
        position.y = Mathf.Clamp(position.y, MinPosition.y, MaxPosition.y);
        position.z = Mathf.Clamp(position.z, MinPosition.z, MaxPosition.z);
        return position;
    }

    public void CalculateBounds()
    {
        if (cornerOne == null || cornerTwo == null)
            SetInfiniteBounds();

        MaxPosition = new Vector3(
            Mathf.Max(cornerOne.position.x, cornerTwo.position.x),
            Mathf.Max(cornerOne.position.y, cornerTwo.position.y),
            Mathf.Max(cornerOne.position.z, cornerTwo.position.z)
        );

        MinPosition = new Vector3(
            Mathf.Min(cornerOne.position.x, cornerTwo.position.x),
            Mathf.Min(cornerOne.position.y, cornerTwo.position.y),
            Mathf.Min(cornerOne.position.z, cornerTwo.position.z)
        );
    }

    private void SetInfiniteBounds()
    {
        MaxPosition = Vector3.positiveInfinity;
        MinPosition = Vector3.negativeInfinity;
    }


}

