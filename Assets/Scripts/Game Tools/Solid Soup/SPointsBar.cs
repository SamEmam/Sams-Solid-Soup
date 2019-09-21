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

    public int startPoints;

    private bool maxHasBeenUpdated = false;

    public int currentValue;
    private float currentPercent;

    private void Start()
    {
        switch (playerNum)
        {
            case 1:
                SetupPointsBar(GamePrefs.Player1, GamePrefs.Player1Score, GamePrefs.P1Color);
                startPoints = GamePrefs.Player1Score;
                break;
            case 2:
                SetupPointsBar(GamePrefs.Player2, GamePrefs.Player2Score, GamePrefs.P2Color);
                startPoints = GamePrefs.Player2Score;
                break;
            case 3:
                SetupPointsBar(GamePrefs.Player3, GamePrefs.Player3Score, GamePrefs.P3Color);
                startPoints = GamePrefs.Player3Score;
                break;
            case 4:
                SetupPointsBar(GamePrefs.Player4, GamePrefs.Player4Score, GamePrefs.P4Color);
                startPoints = GamePrefs.Player4Score;
                break;
            case 5:
                SetupPointsBar(GamePrefs.Player5, GamePrefs.Player5Score, GamePrefs.P5Color);
                startPoints = GamePrefs.Player5Score;
                break;
            case 6:
                SetupPointsBar(GamePrefs.Player6, GamePrefs.Player6Score, GamePrefs.P6Color);
                startPoints = GamePrefs.Player6Score;
                break;
            case 7:
                SetupPointsBar(GamePrefs.Player7, GamePrefs.Player7Score, GamePrefs.P7Color);
                startPoints = GamePrefs.Player7Score;
                break;
            case 8:
                SetupPointsBar(GamePrefs.Player8, GamePrefs.Player8Score, GamePrefs.P8Color);
                startPoints = GamePrefs.Player8Score;
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
                imgPointsBar.color = new Color( 63f / 255f,  68f / 255f,  68f / 255f, 0.7f);
                break;
            case 1:
                imgPointsBar.color = new Color(203f / 255f, 203f / 255f, 203f / 255f, 0.7f);
                break;
            case 2:
                imgPointsBar.color = new Color(198f / 255f,  68f / 255f,  65f / 255f, 0.7f);
                break;
            case 3:
                imgPointsBar.color = new Color(210f / 255f, 124f / 255f,  56f / 255f, 0.7f);
                break;
            case 4:
                imgPointsBar.color = new Color(211f / 255f, 177f / 255f,  41f / 255f, 0.7f);
                break;
            case 5:
                imgPointsBar.color = new Color(150f / 255f, 195f / 255f,  57f / 255f, 0.7f);
                break;
            case 6:
                imgPointsBar.color = new Color( 34f / 255f, 143f / 255f, 105f / 255f, 0.7f);
                break;
            case 7:
                imgPointsBar.color = new Color( 77f / 255f, 173f / 255f, 188f / 255f, 0.7f);
                break;
            case 8:
                imgPointsBar.color = new Color( 80f / 255f, 117f / 255f, 173f / 255f, 0.7f);
                break;
            case 9:
                imgPointsBar.color = new Color(138f / 255f,  40f / 255f, 173f / 255f, 0.7f);
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
                currentPercent = 0;
            }
            else
            {
                currentValue = points;
                currentPercent = (float)currentValue / (float)(max - min);
            }

            txtPoints.text = currentValue.ToString();
            if (startPoints != currentValue)
            {
                txtPoints.text += " (+" + (currentValue - startPoints) + ")";
            }
            imgPointsBar.fillAmount = currentPercent;
        }
    }
}
