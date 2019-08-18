using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SPointsBar : MonoBehaviour
{
    public int playerNum;
    public Image imgPointsBar;
    public TextMeshProUGUI txtPoints;
    public int min, max;
    public GameObject canvas;
    private bool canUpdate;

    private bool maxHasBeenUpdated = false;

    public int currentValue;
    private float currenctPercent;

    private void Start()
    {
        switch (playerNum)
        {
            case 1:
                SetupPointsBar(GamePrefs.Player1, GamePrefs.Player1Score, GamePrefs.P1Color);
                break;
            case 2:
                SetupPointsBar(GamePrefs.Player2, GamePrefs.Player2Score, GamePrefs.P2Color);
                break;
            case 3:
                SetupPointsBar(GamePrefs.Player3, GamePrefs.Player3Score, GamePrefs.P3Color);
                break;
            case 4:
                SetupPointsBar(GamePrefs.Player4, GamePrefs.Player4Score, GamePrefs.P4Color);
                break;
            case 5:
                SetupPointsBar(GamePrefs.Player5, GamePrefs.Player5Score, GamePrefs.P5Color);
                break;
            case 6:
                SetupPointsBar(GamePrefs.Player6, GamePrefs.Player6Score, GamePrefs.P6Color);
                break;
            case 7:
                SetupPointsBar(GamePrefs.Player7, GamePrefs.Player7Score, GamePrefs.P7Color);
                break;
            case 8:
                SetupPointsBar(GamePrefs.Player8, GamePrefs.Player8Score, GamePrefs.P8Color);
                break;

        }
    }

    private void LateUpdate()
    {
        //if (!canUpdate)
        //{
        //    return;
        //}

        UpdatePoints(GetPoints(playerNum));
    }

    public void UpdateMax(int newMax)
    {
        maxHasBeenUpdated = true;
        max = newMax;
    }

    int GetPoints(int playerNum)
    {
        switch (playerNum)
        {
            case 1:
                return GamePrefs.Player1Score;
            case 2:
                return GamePrefs.Player2Score;
            case 3:
                return GamePrefs.Player3Score;
            case 4:
                return GamePrefs.Player4Score;
            case 5:
                return GamePrefs.Player5Score;
            case 6:
                return GamePrefs.Player6Score;
            case 7:
                return GamePrefs.Player7Score;
            case 8:
                return GamePrefs.Player8Score;
            default:
                return 0;

        }
    }

    void SetupPointsBar(bool player, int score, ColorEnum color)
    {
        if (!player)
        {
            canUpdate = false;
            canvas.SetActive(false);
        }
        else
        {
            max = 1;
            SetBarColor((int)color);
        }
    }

    void SetBarColor(int color)
    {
        switch (color)
        {
            case 0:
                imgPointsBar.color = Color.black;
                break;
            case 1:
                imgPointsBar.color = Color.white;
                break;
            case 2:
                imgPointsBar.color = Color.red;
                break;
            case 3:
                imgPointsBar.color = new Color(255, 100, 0);
                break;
            case 4:
                imgPointsBar.color = Color.yellow;
                break;
            case 5:
                imgPointsBar.color = new Color(178, 255, 0);
                break;
            case 6:
                imgPointsBar.color = Color.green;
                break;
            case 7:
                imgPointsBar.color = Color.cyan;
                break;
            case 8:
                imgPointsBar.color = Color.blue;
                break;
            case 9:
                imgPointsBar.color = Color.magenta;
                break;

        }
    }


    void UpdatePoints(int points)
    {
        if (points != currentValue || maxHasBeenUpdated)
        {
            maxHasBeenUpdated = false;
            if (max - min == 0)
            {
                currentValue = 0;
                currenctPercent = 0;
            }
            else
            {
                currentValue = points;
                currenctPercent = (float)currentValue / (float)(max - min);
            }

            txtPoints.text = currentValue.ToString();
            imgPointsBar.fillAmount = currenctPercent;
        }
    }
}
