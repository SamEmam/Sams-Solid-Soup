using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Rewired;

public class LocalVehicleTypeSelector : MonoBehaviour
{
    [SerializeField]
    private GameObject[] Types;

    [SerializeField]
    private int currentIndex;

    [SerializeField]
    private int playerNum;

    private Player player;

    private float switchCooldown;

    // Start is called before the first frame update
    void OnEnable()
    {
        player = ReInput.players.GetPlayer(playerNum);
        EnableType(currentIndex);
        LoadType();
    }

    // Update is called once per frame
    void Update()
    {
        if (switchCooldown > 0f)
        {
            switchCooldown -= Time.deltaTime;
            return;
        }

        if (player.GetButtonDown("RT"))
        {
            NextType();
        }

        if (player.GetButtonDown("LT"))
        {
            PrevType();
        }

        //if (XCI.GetAxis(XboxAxis.RightTrigger, controller) > 0.2)
        //{
        //    NextType();
        //    switchCooldown = 0.2f;
        //}

        //if (XCI.GetAxis(XboxAxis.LeftTrigger, controller) > 0.2)
        //{
        //    PrevType();
        //    switchCooldown = 0.2f;
        //}
    }

    void OnDisable()
    {
        SaveType();
    }

    void SaveType()
    {
        TypeEnum type = (TypeEnum)currentIndex;

        switch (playerNum)
        {
            case 1:
                GamePrefs.P1Type = type;
                break;
            case 2:
                GamePrefs.P2Type = type;
                break;
            case 3:
                GamePrefs.P3Type = type;
                break;
            case 4:
                GamePrefs.P4Type = type;
                break;
            case 5:
                GamePrefs.P5Type = type;
                break;
            case 6:
                GamePrefs.P6Type = type;
                break;
            case 7:
                GamePrefs.P7Type = type;
                break;
            case 8:
                GamePrefs.P8Type = type;
                break;
        }
    }

    void LoadType()
    {
        switch (playerNum)
        {
            case 1:
                EnableType((int)GamePrefs.P1Type);
                currentIndex = (int)GamePrefs.P1Type;
                break;
            case 2:
                EnableType((int)GamePrefs.P2Type);
                currentIndex = (int)GamePrefs.P2Type;
                break;
            case 3:
                EnableType((int)GamePrefs.P3Type);
                currentIndex = (int)GamePrefs.P3Type;
                break;
            case 4:
                EnableType((int)GamePrefs.P4Type);
                currentIndex = (int)GamePrefs.P4Type;
                break;
            case 5:
                EnableType((int)GamePrefs.P5Type);
                currentIndex = (int)GamePrefs.P5Type;
                break;
            case 6:
                EnableType((int)GamePrefs.P6Type);
                currentIndex = (int)GamePrefs.P6Type;
                break;
            case 7:
                EnableType((int)GamePrefs.P7Type);
                currentIndex = (int)GamePrefs.P7Type;
                break;
            case 8:
                EnableType((int)GamePrefs.P8Type);
                currentIndex = (int)GamePrefs.P8Type;
                break;
        }
    }

    void NextType()
    {
        if (currentIndex == Types.Length - 1)
        {
            currentIndex = 0;
        }
        else
        {
            currentIndex++;
        }

        EnableType(currentIndex);
    }

    void PrevType()
    {
        if (currentIndex == 0)
        {
            currentIndex = Types.Length - 1;
        }
        else
        {
            currentIndex--;
        }

        EnableType(currentIndex);
    }

    void EnableType(int index)
    {
        DisableTypes();
        Types[index].SetActive(true);
    }

    void DisableTypes()
    {
        foreach (var type in Types)
        {
            type.SetActive(false);
        }
    }
}
