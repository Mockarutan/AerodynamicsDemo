using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragApplierExtended : MonoBehaviour
{
    public float WaterLevel;
    public float Drag;
    public bool OneSided;
    public Vector3 GlobalForce;

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
        if (_Body.position.y < WaterLevel)
        {
            var velocity = (_Trans.position - _LastPosition) / Time.fixedDeltaTime;

            var totalVelocity = velocity + GlobalForce;

            var velocityMagnitude = totalVelocity.magnitude;

            var velocitySquared = velocityMagnitude * velocityMagnitude;

            var directionFactor = Vector3.Dot(totalVelocity.normalized, _Trans.up);

            if (OneSided)
                directionFactor = Mathf.Clamp01(directionFactor);

            var dragForce = velocitySquared * directionFactor * -_Trans.up * Drag;

            _Body.AddForceAtPosition(dragForce, _Trans.position);
        }

        _LastPosition = _Trans.position;
    }
}
