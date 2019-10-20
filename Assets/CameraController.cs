using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform LookAtTarget;
    public Transform PositionTarget;
    public float MaxDistance;
    public float RollSpeed;
    public float MaxRollAngle;
    public AnimationCurve RollSpeedCurve;

    private Transform _Trans;
    private Vector3 _TargetUp;

    void Start()
    {
        _Trans = transform;
        _TargetUp = LookAtTarget.up;
    }

    void Update()
    {
        var distance = Vector3.Distance(_Trans.position, PositionTarget.position);
        var direction = (PositionTarget.position - _Trans.position).normalized;
        if (distance > MaxDistance)
            _Trans.position = _Trans.position + direction * (distance - MaxDistance);

        var angle = Vector3.Angle(_TargetUp, LookAtTarget.up);
        if (angle > MaxRollAngle)
        {
            var cross = Vector3.Cross(_TargetUp, LookAtTarget.up);
            _TargetUp = Quaternion.AngleAxis(-MaxRollAngle, cross) * LookAtTarget.up;
        }
        else
        {
            var angleDiff = RollSpeedCurve.Evaluate(angle / MaxRollAngle);
            _TargetUp = Vector3.RotateTowards(_TargetUp, LookAtTarget.up, RollSpeed * angleDiff * Time.deltaTime, 0);
        }

        _Trans.LookAt(LookAtTarget, _TargetUp);
    }
}
