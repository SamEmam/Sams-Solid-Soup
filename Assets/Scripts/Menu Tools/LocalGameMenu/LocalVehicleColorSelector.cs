using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Rewired;

public class LocalVehicleColorSelector : MonoBehaviour
{
    [SerializeField]
    private GameObject[] Colors;

    [SerializeField]
    private int currentIndex;
    
    [SerializeField]
    private int playerNum;

    private Player player;

    private ColorEnum color;
    
    // Start is called before the first frame update
    void OnEnable()
    {
        player = ReInput.players.GetPlayer(playerNum);
        LoadColor();
        //EnableColor(currentIndex);

        
    }

    // Update is called once per frame
    void Update()
    {
        if (player.GetButtonDown("RB"))
        {
            NextColor();
        }

        if (player.GetButtonDown("LB"))
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
        color = (ColorEnum)currentIndex;

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
                    currentIndex = (int)GamePrefs.P1Color;
                    EnableColor(currentIndex);
                }
                break;
            case 2:
                if (GamePrefs.P2Color != ColorEnum.Undefined)
                {
                    currentIndex = (int)GamePrefs.P2Color;
                    EnableColor(currentIndex);
                }
                break;
            case 3:
                if (GamePrefs.P3Color != ColorEnum.Undefined)
                {
                    currentIndex = (int)GamePrefs.P3Color;
                    EnableColor(currentIndex);
                }
                break;
            case 4:
                if (GamePrefs.P4Color != ColorEnum.Undefined)
                {
                    currentIndex = (int)GamePrefs.P4Color;
                    EnableColor(currentIndex);
                }
                break;
            case 5:
                if (GamePrefs.P5Color != ColorEnum.Undefined)
                {
                    currentIndex = (int)GamePrefs.P5Color;
                    EnableColor(currentIndex);
                }
                break;
            case 6:
                if (GamePrefs.P6Color != ColorEnum.Undefined)
                {
                    currentIndex = (int)GamePrefs.P6Color;
                    EnableColor(currentIndex);
                }
                break;
            case 7:
                if (GamePrefs.P7Color != ColorEnum.Undefined)
                {
                    currentIndex = (int)GamePrefs.P7Color;
                    EnableColor(currentIndex);
                }
                break;
            case 8:
                if (GamePrefs.P8Color != ColorEnum.Undefined)
                {
                    currentIndex = (int)GamePrefs.P8Color;
                    EnableColor(currentIndex);
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

        if (ColorCompare(currentIndex))
        {
            NextColor();
            return;
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

        if (ColorCompare(currentIndex))
        {
            PrevColor();
            return;
        }

        EnableColor(currentIndex);
    }

    bool ColorCompare(int index)
    {
        switch (playerNum)
        {
            case 1:
                if (index == (int)GamePrefs.P2Color) return true;
                if (index == (int)GamePrefs.P3Color) return true;
                if (index == (int)GamePrefs.P4Color) return true;
                if (index == (int)GamePrefs.P5Color) return true;
                if (index == (int)GamePrefs.P6Color) return true;
                if (index == (int)GamePrefs.P7Color) return true;
                if (index == (int)GamePrefs.P8Color) return true;
                else return false;
            case 2:
                if (index == (int)GamePrefs.P1Color) return true;
                if (index == (int)GamePrefs.P3Color) return true;
                if (index == (int)GamePrefs.P4Color) return true;
                if (index == (int)GamePrefs.P5Color) return true;
                if (index == (int)GamePrefs.P6Color) return true;
                if (index == (int)GamePrefs.P7Color) return true;
                if (index == (int)GamePrefs.P8Color) return true;
                else return false;
            case 3:
                if (index == (int)GamePrefs.P1Color) return true;
                if (index == (int)GamePrefs.P2Color) return true;
                if (index == (int)GamePrefs.P4Color) return true;
                if (index == (int)GamePrefs.P5Color) return true;
                if (index == (int)GamePrefs.P6Color) return true;
                if (index == (int)GamePrefs.P7Color) return true;
                if (index == (int)GamePrefs.P8Color) return true;
                else return false;
            case 4:
                if (index == (int)GamePrefs.P1Color) return true;
                if (index == (int)GamePrefs.P2Color) return true;
                if (index == (int)GamePrefs.P3Color) return true;
                if (index == (int)GamePrefs.P5Color) return true;
                if (index == (int)GamePrefs.P6Color) return true;
                if (index == (int)GamePrefs.P7Color) return true;
                if (index == (int)GamePrefs.P8Color) return true;
                else return false;
            case 5:
                if (index == (int)GamePrefs.P1Color) return true;
                if (index == (int)GamePrefs.P2Color) return true;
                if (index == (int)GamePrefs.P3Color) return true;
                if (index == (int)GamePrefs.P4Color) return true;
                if (index == (int)GamePrefs.P6Color) return true;
                if (index == (int)GamePrefs.P7Color) return true;
                if (index == (int)GamePrefs.P8Color) return true;
                else return false;
            case 6:
                if (index == (int)GamePrefs.P1Color) return true;
                if (index == (int)GamePrefs.P2Color) return true;
                if (index == (int)GamePrefs.P3Color) return true;
                if (index == (int)GamePrefs.P4Color) return true;
                if (index == (int)GamePrefs.P5Color) return true;
                if (index == (int)GamePrefs.P7Color) return true;
                if (index == (int)GamePrefs.P8Color) return true;
                else return false;
            case 7:
                if (index == (int)GamePrefs.P1Color) return true;
                if (index == (int)GamePrefs.P2Color) return true;
                if (index == (int)GamePrefs.P3Color) return true;
                if (index == (int)GamePrefs.P4Color) return true;
                if (index == (int)GamePrefs.P5Color) return true;
                if (index == (int)GamePrefs.P6Color) return true;
                if (index == (int)GamePrefs.P8Color) return true;
                else return false;
            case 8:
                if (index == (int)GamePrefs.P1Color) return true;
                if (index == (int)GamePrefs.P2Color) return true;
                if (index == (int)GamePrefs.P3Color) return true;
                if (index == (int)GamePrefs.P4Color) return true;
                if (index == (int)GamePrefs.P5Color) return true;
                if (index == (int)GamePrefs.P6Color) return true;
                if (index == (int)GamePrefs.P7Color) return true;
                else return false;
        }

        return false;
    }

    void EnableColor(int index)
    {
        DisableColors();
        Colors[index].SetActive(true);
        SaveColor();
    }

    void DisableColors()
    {
        foreach (var color in Colors)
        {
            color.SetActive(false);
        }
    }
}
