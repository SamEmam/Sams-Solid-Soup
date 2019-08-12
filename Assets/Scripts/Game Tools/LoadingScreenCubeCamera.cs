using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadingScreenCubeCamera : MonoBehaviour
{
    public Light[] SoftLights;
    public Light[] HardLights;
    

    private void OnPreRender()
    {
        foreach (Light l in SoftLights) { l.shadows = LightShadows.None; }
        foreach (Light l in HardLights) { l.shadows = LightShadows.None; }
    }

    private void OnPostRender()
    {
        foreach (Light l in SoftLights) { l.shadows = LightShadows.Soft; }
        foreach (Light l in HardLights) { l.shadows = LightShadows.Hard; }
    }
}
