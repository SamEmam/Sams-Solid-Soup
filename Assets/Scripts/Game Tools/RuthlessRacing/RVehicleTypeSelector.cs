using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XboxCtrlrInput;

public class RVehicleTypeSelector : MonoBehaviour
{
    [SerializeField]
    private GameObject[] Types;

    [SerializeField]
    private int playerNum;

    private GameObject playerVehicle;

    private void OnEnable()
    {
        LoadType();
    }

    void LoadType()
    {
        switch (playerNum)
        {
            case 1:
                EnableType((int)GamePrefs.P1Type);
                break;
            case 2:
                EnableType((int)GamePrefs.P2Type);
                break;
            case 3:
                EnableType((int)GamePrefs.P3Type);
                break;
            case 4:
                EnableType((int)GamePrefs.P4Type);
                break;
            case 5:
                EnableType((int)GamePrefs.P5Type);
                break;
            case 6:
                EnableType((int)GamePrefs.P6Type);
                break;
            case 7:
                EnableType((int)GamePrefs.P7Type);
                break;
            case 8:
                EnableType((int)GamePrefs.P8Type);
                break;
        }
    }

    public int GetPlayerNum()
    {
        return playerNum;
    }

    
    public GameObject GetVehicle()
    {
        return playerVehicle;
    }

    void EnableType(int index)
    {
        DisableTypes();
        Types[index].SetActive(true);
        SetVehicle(index);
    }

    void SetVehicle(int index)
    {
        playerVehicle = Types[index];
    }

    void DisableTypes()
    {
        foreach (var type in Types)
        {
            type.SetActive(false);
        }
    }
}
