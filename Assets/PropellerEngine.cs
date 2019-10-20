using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PropellerEngine : MonoBehaviour
{
    public float MaxRotateSpeed;
    public float MinRotateSpeed;
    public float MaxForce;

    public KeyCode FullThottleKey;

    public Transform PropellerMesh;

    private Transform _Trans;
    private Rigidbody _Body;

    void Start()
    {
        _Trans = transform;
        _Body = GetComponentInParent<Rigidbody>();
    }

    void Update()
    {
        float rotateSpeed = MinRotateSpeed;

        if (Input.GetKey(FullThottleKey))
        {
            var worldForce = _Trans.TransformDirection(new Vector3(0, 0, MaxForce));
            _Body.AddForceAtPosition(worldForce, _Trans.position);
            rotateSpeed = MaxRotateSpeed;
        }

        PropellerMesh.Rotate(new Vector3(0, 0, rotateSpeed), Space.Self);
    }
}
