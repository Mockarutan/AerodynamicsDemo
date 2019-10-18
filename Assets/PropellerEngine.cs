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

    private Rigidbody _Body;

    void Start()
    {
        _Body = GetComponentInParent<Rigidbody>();
    }

    void Update()
    {
        float rotateSpeed = MinRotateSpeed;

        if (Input.GetKey(FullThottleKey))
        {
            _Body.AddRelativeForce(new Vector3(0, 0, MaxForce));
            rotateSpeed = MaxRotateSpeed;
        }

        PropellerMesh.Rotate(new Vector3(0, 0, rotateSpeed), Space.Self);
    }
}
