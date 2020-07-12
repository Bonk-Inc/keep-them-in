using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderDistanceComparer : IComparer<Collider>
{

    private Vector3 point;

    public ColliderDistanceComparer(Vector3 point)
    {
        this.point = point;
    }

    public int Compare(Collider x, Collider y)//TODO maybe add a null check?
    {
        var centerDistanceToX = Vector3.Distance(x.transform.position, point);
        var centerDistanceToY = Vector3.Distance(y.transform.position, point);

        return (int)(centerDistanceToX - centerDistanceToY);
    }
}
