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

    public RGameMaster GM;

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
        SetGMVehicle();
    }

    void DisableTypes()
    {
        foreach (var type in Types)
        {
            type.SetActive(false);
        }
    }

    void SetGMVehicle()
    {
        switch (playerNum)
        {
            case 1:
                GM.p1 = playerVehicle;
                GM.p1Score = playerVehicle.GetComponent<RPlayerScore>();
                GM.p1Power = playerVehicle.GetComponent<RPlayerPowerup>();
                GM.p1Alive = true;
                GM.totalPlayers++;
                break;
            case 2:
                GM.p2 = playerVehicle;
                GM.p2Score = playerVehicle.GetComponent<RPlayerScore>();
                GM.p2Power = playerVehicle.GetComponent<RPlayerPowerup>();
                GM.p2Alive = true;
                GM.totalPlayers++;
                break;
            case 3:
                GM.p3 = playerVehicle;
                GM.p3Score = playerVehicle.GetComponent<RPlayerScore>();
                GM.p3Power = playerVehicle.GetComponent<RPlayerPowerup>();
                GM.p3Alive = true;
                GM.totalPlayers++;
                break;
            case 4:
                GM.p4 = playerVehicle;
                GM.p4Score = playerVehicle.GetComponent<RPlayerScore>();
                GM.p4Power = playerVehicle.GetComponent<RPlayerPowerup>();
                GM.p4Alive = true;
                GM.totalPlayers++;
                break;
            case 5:
                GM.p5 = playerVehicle;
                GM.p5Score = playerVehicle.GetComponent<RPlayerScore>();
                GM.p5Power = playerVehicle.GetComponent<RPlayerPowerup>();
                GM.p5Alive = true;
                GM.totalPlayers++;
                break;
            case 6:
                GM.p6 = playerVehicle;
                GM.p6Score = playerVehicle.GetComponent<RPlayerScore>();
                GM.p6Power = playerVehicle.GetComponent<RPlayerPowerup>();
                GM.p6Alive = true;
                GM.totalPlayers++;
                break;
            case 7:
                GM.p7 = playerVehicle;
                GM.p7Score = playerVehicle.GetComponent<RPlayerScore>();
                GM.p7Power = playerVehicle.GetComponent<RPlayerPowerup>();
                GM.p7Alive = true;
                GM.totalPlayers++;
                break;
            case 8:
                GM.p8 = playerVehicle;
                GM.p8Score = playerVehicle.GetComponent<RPlayerScore>();
                GM.p8Power = playerVehicle.GetComponent<RPlayerPowerup>();
                GM.p8Alive = true;
                GM.totalPlayers++;
                break;
        }
    }
}
