using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SSPlatformColorSelector : MonoBehaviour
{
    public Material[] materials;
    private Material mat;
    private int playerNum;

    private void OnEnable()
    {
        playerNum = GetComponentInParent<RVehicleTypeSelector>().GetPlayerNum();

        switch (playerNum)
        {
            case 1:
                SetMaterial((int)GamePrefs.P1Color);
                break;
            case 2:
                SetMaterial((int)GamePrefs.P2Color);
                break;
            case 3:
                SetMaterial((int)GamePrefs.P3Color);
                break;
            case 4:
                SetMaterial((int)GamePrefs.P4Color);
                break;
            case 5:
                SetMaterial((int)GamePrefs.P5Color);
                break;
            case 6:
                SetMaterial((int)GamePrefs.P6Color);
                break;
            case 7:
                SetMaterial((int)GamePrefs.P7Color);
                break;
            case 8:
                SetMaterial((int)GamePrefs.P8Color);
                break;
        }
    }

    void SetMaterial(int index)
    {
        GetComponentInChildren<MeshRenderer>().material = materials[index];
    }
}
