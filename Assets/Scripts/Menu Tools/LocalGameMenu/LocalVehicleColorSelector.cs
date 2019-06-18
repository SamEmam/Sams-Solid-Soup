using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XboxCtrlrInput;

public class LocalVehicleColorSelector : MonoBehaviour
{
    [SerializeField]
    private GameObject[] Colors;

    [SerializeField]
    private int currentIndex;

    [SerializeField]
    private int playerNum;

    public XboxController controller;
    
    // Start is called before the first frame update
    void OnEnable()
    {
        EnableColor(currentIndex);
        LoadColor();
    }

    // Update is called once per frame
    void Update()
    {
        if (XCI.GetButtonDown(XboxButton.RightBumper, controller))
        {
            NextColor();
        }

        if (XCI.GetButtonDown(XboxButton.LeftBumper, controller))
        {
            PrevColor();
        }
    }

    void OnDisable()
    {
        SaveColor();
    }

    void SaveColor()
    {
        ColorEnum color = (ColorEnum)currentIndex;

        switch (playerNum)
        {
            case 1:
                GamePrefs.P1Color = color;
                break;
            case 2:
                GamePrefs.P2Color = color;
                break;
            case 3:
                GamePrefs.P3Color = color;
                break;
            case 4:
                GamePrefs.P4Color = color;
                break;
            case 5:
                GamePrefs.P5Color = color;
                break;
            case 6:
                GamePrefs.P6Color = color;
                break;
            case 7:
                GamePrefs.P7Color = color;
                break;
            case 8:
                GamePrefs.P8Color = color;
                break;
        }
    }

    void LoadColor()
    {
        switch (playerNum)
        {
            case 1:
                if (GamePrefs.P1Color != ColorEnum.Undefined)
                {
                    EnableColor((int)GamePrefs.P1Color);
                    currentIndex = (int)GamePrefs.P1Color;
                }
                break;
            case 2:
                if (GamePrefs.P2Color != ColorEnum.Undefined)
                {
                    EnableColor((int)GamePrefs.P2Color);
                    currentIndex = (int)GamePrefs.P2Color;
                }
                break;
            case 3:
                if (GamePrefs.P3Color != ColorEnum.Undefined)
                {
                    EnableColor((int)GamePrefs.P3Color);
                    currentIndex = (int)GamePrefs.P3Color;
                }
                break;
            case 4:
                if (GamePrefs.P4Color != ColorEnum.Undefined)
                {
                    EnableColor((int)GamePrefs.P4Color);
                    currentIndex = (int)GamePrefs.P4Color;
                }
                break;
            case 5:
                if (GamePrefs.P5Color != ColorEnum.Undefined)
                {
                    EnableColor((int)GamePrefs.P5Color);
                    currentIndex = (int)GamePrefs.P5Color;
                }
                break;
            case 6:
                if (GamePrefs.P6Color != ColorEnum.Undefined)
                {
                    EnableColor((int)GamePrefs.P6Color);
                    currentIndex = (int)GamePrefs.P6Color;
                }
                break;
            case 7:
                if (GamePrefs.P7Color != ColorEnum.Undefined)
                {
                    EnableColor((int)GamePrefs.P7Color);
                    currentIndex = (int)GamePrefs.P7Color;
                }
                break;
            case 8:
                if (GamePrefs.P8Color != ColorEnum.Undefined)
                {
                    EnableColor((int)GamePrefs.P8Color);
                    currentIndex = (int)GamePrefs.P8Color;
                }
                break;
        }
    }

    void NextColor()
    {
        if (currentIndex == Colors.Length - 1)
        {
            currentIndex = 0;
        }
        else
        {
            currentIndex++;
        }

        EnableColor(currentIndex);
    }

    void PrevColor()
    {
        if (currentIndex == 0)
        {
            currentIndex = Colors.Length - 1;
        }
        else
        {
            currentIndex--;
        }

        EnableColor(currentIndex);
    }

    void EnableColor(int index)
    {
        DisableColors();
        Colors[index].SetActive(true);
    }

    void DisableColors()
    {
        foreach (var color in Colors)
        {
            color.SetActive(false);
        }
    }
}
