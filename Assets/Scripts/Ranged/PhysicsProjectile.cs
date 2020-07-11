using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicsProjectile : MonoBehaviour
{

    private Rigidbody rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    public void Launch(Transform target, float power)
    {
        Vector3 dir = (target.position - transform.position).normalized;
        rb.AddForce(dir * power, ForceMode.Impulse);
    }

}
