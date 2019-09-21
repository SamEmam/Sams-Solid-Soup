using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SDerbyPointsBar : MonoBehaviour
{
    public SDerbyMaster derbyMaster;

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

    private int points, kills;

    private void Start()
    {
        switch (playerNum)
        {
            case 1:
                SetupPointsBar(GamePrefs.Player1, GamePrefs.P1Color);
                break;
            case 2:
                SetupPointsBar(GamePrefs.Player2, GamePrefs.P2Color);
                break;
            case 3:
                SetupPointsBar(GamePrefs.Player3, GamePrefs.P3Color);
                break;
            case 4:
                SetupPointsBar(GamePrefs.Player4, GamePrefs.P4Color);
                break;
            case 5:
                SetupPointsBar(GamePrefs.Player5, GamePrefs.P5Color);
                break;
            case 6:
                SetupPointsBar(GamePrefs.Player6, GamePrefs.P6Color);
                break;
            case 7:
                SetupPointsBar(GamePrefs.Player7, GamePrefs.P7Color);
                break;
            case 8:
                SetupPointsBar(GamePrefs.Player8, GamePrefs.P8Color);
                break;

        }
    }

    private void LateUpdate()
    {
        SetPoints(playerNum);
        UpdatePoints(points, kills);
    }

    public void UpdateMax(int newMax)
    {
        maxHasBeenUpdated = true;
        max = newMax;
    }

    void SetPoints(int playerNum)
    {
        foreach (var player in derbyMaster.players)
        {
            if (player.playerNum == playerNum)
            {
                points = player.points;
                kills = player.kills;
            }
        }
    }

    void SetupPointsBar(bool player, ColorEnum color)
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
                imgPointsBar.color = new Color(63f / 255f, 68f / 255f, 68f / 255f, 1f);
                break;
            case 1:
                imgPointsBar.color = new Color(203f / 255f, 203f / 255f, 203f / 255f, 1f);
                break;
            case 2:
                imgPointsBar.color = new Color(198f / 255f, 68f / 255f, 65f / 255f, 1f);
                break;
            case 3:
                imgPointsBar.color = new Color(210f / 255f, 124f / 255f, 56f / 255f, 1f);
                break;
            case 4:
                imgPointsBar.color = new Color(211f / 255f, 177f / 255f, 41f / 255f, 1f);
                break;
            case 5:
                imgPointsBar.color = new Color(150f / 255f, 195f / 255f, 57f / 255f, 1f);
                break;
            case 6:
                imgPointsBar.color = new Color(34f / 255f, 143f / 255f, 105f / 255f, 1f);
                break;
            case 7:
                imgPointsBar.color = new Color(77f / 255f, 173f / 255f, 188f / 255f, 1f);
                break;
            case 8:
                imgPointsBar.color = new Color(80f / 255f, 117f / 255f, 173f / 255f, 1f);
                break;
            case 9:
                imgPointsBar.color = new Color(138f / 255f, 40f / 255f, 173f / 255f, 1f);
                break;

        }
    }

    void UpdatePoints(int points, int kills)
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
            if (kills > 0)
            {
                txtPoints.text += " (" + kills + ")";
            }

            imgPointsBar.fillAmount = currentPercent;
        }
    }
}
