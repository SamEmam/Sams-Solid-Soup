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
