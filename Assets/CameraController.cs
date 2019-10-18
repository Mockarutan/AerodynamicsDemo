using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform LookAtTarget;
    public Transform PositionTarget;
    public float MaxDistance;

    private Transform _Trans;

    void Start()
    {
        _Trans = transform;
    }

    void Update()
    {
        var distance = Vector3.Distance(_Trans.position, PositionTarget.position);
        var direction = (PositionTarget.position - _Trans.position).normalized;
        if (distance > MaxDistance)
            _Trans.position = _Trans.position + direction * (distance - MaxDistance);

        _Trans.LookAt(LookAtTarget, LookAtTarget.up);
    }
}
