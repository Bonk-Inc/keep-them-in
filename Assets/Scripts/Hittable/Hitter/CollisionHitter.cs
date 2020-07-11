using UnityEngine;

public class CollisionHitter : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        Transform other = collision.transform;
        IHittable hittable = other.GetComponent<IHittable>();
        hittable?.Hit(new HittableParams());
        Destroy(this.gameObject);
    }
}
