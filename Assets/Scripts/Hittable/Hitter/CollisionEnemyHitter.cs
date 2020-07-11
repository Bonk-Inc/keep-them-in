using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionEnemyHitter : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        GameObject other = collision.collider.gameObject;
        IHittable hittable = other.GetComponent<IHittable>();
        hittable?.Hit(new HittableParams());
        Destroy(this.gameObject);
    }
}
