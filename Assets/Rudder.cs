using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rudder : MonoBehaviour
{
    public KeyCode UpKey;
    public KeyCode DownKey;
    public float UpAngle;
    public float DownAngle;

    private Transform _Trans;

    private void Awake()
    {
        _Trans = transform;
    }

    void Update()
    {
        if (Input.GetKey(UpKey))
            _Trans.localRotation = Quaternion.Euler(UpAngle, 0, 0);
        else if (Input.GetKey(DownKey))
            _Trans.localRotation = Quaternion.Euler(DownAngle, 0, 0);
        else
            _Trans.localRotation = Quaternion.Euler(0, 0, 0);
    }
}
