using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlPanel : MonoBehaviour
{
    public bool ApplyDrag;
    public static bool GlobalApplyDrag = true;

    void Update()
    {
        GlobalApplyDrag = ApplyDrag;
    }
}
