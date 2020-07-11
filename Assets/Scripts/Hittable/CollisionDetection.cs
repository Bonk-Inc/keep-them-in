using System.Collections;
using UnityEngine;

public class CollisionDetection : MonoBehaviour {
    [SerializeField]
    private LayerMask checkLayer;
    [SerializeField]
    private float cooldowntime;
    [SerializeField]
    private HittableParams dmg;

    private bool onStayContacted = false;

    private void OnCollisionEnter(Collision collision) {
        if (checkLayer == (checkLayer | ( 1<< collision.gameObject.layer))) {
            onStayContacted = true;
            Transform other = collision.transform;
            IHittable hittable = other.GetComponent<IHittable>();
            StartCoroutine(HitCooldown(hittable));
        }
    }

    private void OnCollisionExit(Collision collision) {
        onStayContacted = false;
    }

    private IEnumerator HitCooldown(IHittable target) {
        target?.Hit(dmg);
        yield return new WaitForSeconds(cooldowntime);
        if (onStayContacted && target != null) {
            StartCoroutine(HitCooldown(target));
        } else {
            StopCoroutine(HitCooldown(target));
        }
    }
}