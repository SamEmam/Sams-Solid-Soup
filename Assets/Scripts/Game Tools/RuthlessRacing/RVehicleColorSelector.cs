using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RVehicleColorSelector : MonoBehaviour
{
    [SerializeField]
    private Mesh[] Colors;

    [SerializeField]
    private RVehicleTypeSelector typeSelector;

    [SerializeField]
    private MeshFilter vehicleMesh;

    private void OnEnable()
    {
        LoadColor();
    }

    void LoadColor()
    {
        switch (typeSelector.GetPlayerNum())
        {
            case 1:
                EnableColor((int)GamePrefs.P1Color);
                break;
            case 2:
                EnableColor((int)GamePrefs.P2Color);
                break;
            case 3:
                EnableColor((int)GamePrefs.P3Color);
                break;
            case 4:
                EnableColor((int)GamePrefs.P4Color);
                break;
            case 5:
                EnableColor((int)GamePrefs.P5Color);
                break;
            case 6:
                EnableColor((int)GamePrefs.P6Color);
                break;
            case 7:
                EnableColor((int)GamePrefs.P7Color);
                break;
            case 8:
                EnableColor((int)GamePrefs.P8Color);
                break;
        }
    }

    void EnableColor(int index)
    {
        vehicleMesh.mesh = Colors[index];
    }
}
