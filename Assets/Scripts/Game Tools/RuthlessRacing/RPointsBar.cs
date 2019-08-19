using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class RPointsBar : MonoBehaviour
{
    [SerializeField]
    private RPlayerScore ps;
    [SerializeField]
    private int playerNum;
    [SerializeField]
    private RGameMaster GM;
    [SerializeField]
    private RScoreManager SM;
    [SerializeField]
    private Image imgPointsBar;
    [SerializeField]
    private TextMeshProUGUI txtPoints;
    [SerializeField]
    private int min, max;
    [SerializeField]
    private GameObject canvas;

    private bool canUpdate = true;
    private bool overrideUpdate = true;

    private int currentValue;
    private float currenctPercent;

    private void Start()
    {
        ps = GM.GetPlayerScore(playerNum);
        SetBarColor(playerNum);
        if (!ps || !ps.transform.gameObject.activeInHierarchy)
        {
            canUpdate = false;
            canvas.SetActive(false);
        }
        else
        {
            max = SM.winScore;
            Debug.Log("PointsBar: " + gameObject.name);
        }

    }

    void SetBarColor(int playerNum)
    {
        int color = 0;
        switch (playerNum)
        {
            case 1:
                color = (int)GamePrefs.P1Color;
                break;
            case 2:
                color = (int)GamePrefs.P2Color;
                break;
            case 3:
                color = (int)GamePrefs.P3Color;
                break;
            case 4:
                color = (int)GamePrefs.P4Color;
                break;
            case 5:
                color = (int)GamePrefs.P5Color;
                break;
            case 6:
                color = (int)GamePrefs.P6Color;
                break;
            case 7:
                color = (int)GamePrefs.P7Color;
                break;
            case 8:
                color = (int)GamePrefs.P8Color;
                break;
        }

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

    public void SetPoints(int points)
    {

        if (points != currentValue)
        {
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
            txtPoints.text = currentValue + " / " + max;

            imgPointsBar.fillAmount = currenctPercent;
        }
    }
    private void OverrideSetPoints(int points)
    {
        overrideUpdate = false;
        max = SM.winScore;
        currentValue = points;
        currenctPercent = (float)currentValue / (float)(max - min);

        txtPoints.text = currentValue + " / " + max;
        imgPointsBar.fillAmount = currenctPercent;

    }

    private void LateUpdate()
    {
        if (overrideUpdate)
        {
            OverrideSetPoints(ps.score);
        }
        if (!ps)
        {
            canUpdate = false;
            canvas.SetActive(false);
        }
        if (canUpdate)
        {
            SetPoints(ps.score);
        }
    }

    public float CurrentPercent
    {
        get { return currenctPercent; }
    }
    public int CurrentValue
    {
        get { return currentValue; }
    }
}
