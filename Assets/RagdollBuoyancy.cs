using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RagdollBuoyancy : MonoBehaviour
{
    public float WaterLevel;
    public float UnderWaterDrag;

    private Rigidbody[] _Bodies;

    void Start()
    {
        _Bodies = GetComponentsInChildren<Rigidbody>();
    }

    void Update()
    {
        for (int i = 0; i < _Bodies.Length; i++)
        {
            var body = _Bodies[i];
            if (body.position.y < WaterLevel)
            {
                body.useGravity = false;
                body.drag = UnderWaterDrag;
            }
        }
    }
}
