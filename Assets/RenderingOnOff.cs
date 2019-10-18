using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class RenderingOnOff : MonoBehaviour
{
    public bool RenderingOn;

    private bool _LastRenderingOn;

    void Update()
    {
        if (_LastRenderingOn != RenderingOn)
        {
            var renderers = GetComponentsInChildren<Renderer>();
            for (int i = 0; i < renderers.Length; i++)
                renderers[i].enabled = RenderingOn;
        }

        _LastRenderingOn = RenderingOn;
    }
}
