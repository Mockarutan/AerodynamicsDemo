using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragApplier : MonoBehaviour
{
    public float Drag;

    private Transform _Trans;
    private Rigidbody _Body;

    void Start()
    {
        _Trans = transform;
        _Body = GetComponentInParent<Rigidbody>();
    }

    void Update()
    {
        if (ControlPanel.GlobalApplyDrag)
        {
            var velocitySquared = _Body.velocity.magnitude * _Body.velocity.magnitude;

            var directionFactor = Vector3.Dot(_Body.velocity.normalized, _Trans.up);

            var dragForce = velocitySquared * directionFactor * -_Trans.up * Drag;

            _Body.AddForceAtPosition(dragForce, _Trans.position);
        }
    }
}
