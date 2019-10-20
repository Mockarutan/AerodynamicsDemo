using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragApplier : MonoBehaviour
{
    public float Drag;

    private Transform _Trans;
    private Rigidbody _Body;

    private Vector3 _LastPosition;

    void Start()
    {
        _Trans = transform;
        _Body = GetComponentInParent<Rigidbody>();
        _LastPosition = _Trans.position;
    }

    void FixedUpdate()
    {
        var velocity = (_Trans.position - _LastPosition) / Time.fixedDeltaTime;

        var velocityMagnitude = velocity.magnitude;

        var velocitySquared = velocityMagnitude * velocityMagnitude;

        var directionFactor = Vector3.Dot(velocity.normalized, _Trans.up);

        var dragForce = velocitySquared * directionFactor * -_Trans.up * Drag;

        _Body.AddForceAtPosition(dragForce, _Trans.position);

        _LastPosition = _Trans.position;
    }
}
