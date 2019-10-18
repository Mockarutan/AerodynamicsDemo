using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MotionApplier : MonoBehaviour
{
    public Vector3 StartLinearVelocity;
    public Vector3 StartAngularVelocity;
    public Vector3 PersistentLinearVelocity;
    public Vector3 PersistentAngularVelocity;

    private Transform _Trans;
    private Rigidbody _Body;

    void Start()
    {
        _Trans = transform;
        _Body = GetComponentInParent<Rigidbody>();

        _Body.AddForceAtPosition(StartLinearVelocity, _Trans.position);
        _Body.AddTorque(StartAngularVelocity);
    }

    void Update()
    {
        _Body.AddForceAtPosition(PersistentLinearVelocity, _Trans.position);
        _Body.AddTorque(PersistentAngularVelocity);
    }
}
