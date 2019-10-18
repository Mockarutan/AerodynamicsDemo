using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubmarineBuoyancy : MonoBehaviour
{
    public float WaterHighLevel;
    public float WaterLowLevel;
    public float ForceMultiply;
    public AnimationCurve BuoyancyForceCurve;

    public float RollForceXMultiply;
    public float RollForceZMultiply;
    public AnimationCurve RollForceCurve;

    private Transform _Trans;
    private Rigidbody _Body;

    void Start()
    {
        _Trans = transform;
        _Body = GetComponent<Rigidbody>();
    }

    void Update()
    {
        float waterLevelRange = WaterHighLevel - WaterLowLevel;
        float normWaterLevelDiff = Mathf.Clamp01((_Body.position.y - WaterLowLevel) / waterLevelRange);
        if (normWaterLevelDiff > 0)
        {
            float buoyancyForce = BuoyancyForceCurve.Evaluate(normWaterLevelDiff) * ForceMultiply;
            _Body.AddForce(new Vector3(0, -buoyancyForce, 0));
        }

        float xRollAngle = Mathf.Clamp(Vector3.SignedAngle(_Trans.up, Vector3.up, _Trans.right) / 90, -1, 1);
        if (xRollAngle != 0)
        {
            float rollForce = RollForceCurve.Evaluate(Mathf.Abs(xRollAngle)) * RollForceXMultiply;
            if (xRollAngle > 0)
                _Body.AddRelativeTorque(new Vector3(rollForce, 0, 0));
            else
                _Body.AddRelativeTorque(new Vector3(-rollForce, 0, 0));
        }

        float zRollAngle = Mathf.Clamp(Vector3.SignedAngle(_Trans.up, Vector3.up, _Trans.forward) / 90, -1, 1);
        if (zRollAngle != 0)
        {
            float rollForce = RollForceCurve.Evaluate(Mathf.Abs(zRollAngle)) * RollForceZMultiply;
            if (zRollAngle > 0)
                _Body.AddRelativeTorque(new Vector3(0, 0, rollForce));
            else
                _Body.AddRelativeTorque(new Vector3(0, 0, -rollForce));
        }
    }
}
