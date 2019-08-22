using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RScoreManager : MonoBehaviour
{
    public RGameMaster GM;

    public int rewardValue;
    public int winScore;
    private int winScoreHalf;
    private int winScoreDouble;

    private float gameTime;

    private void Start()
    {
        gameTime = GamePrefs.GameTime;

        winScoreDouble = winScore * 2;
        winScoreHalf = winScore / 2;
        WinScoreCalc();
    }

    private void Update()
    {
        gameTime -= Time.deltaTime;
    }

    void WinScoreCalc()
    {
        winScore = winScoreHalf;
        if (GM.playersLeft > 2)
        {
            winScore = winScoreHalf * 2;
        }
        if (GM.playersLeft > 4)
        {
            winScore = winScoreHalf * 3;
        }
        if (GM.playersLeft > 6)
        {
            winScore = winScoreDouble;
        }
    }

    public void UpdateScore(RPlayerScore score)
    {
        if (rewardValue == 0)
        {
            rewardValue++;
        }
        score.score += rewardValue;
        if (score.score < 0)
        {
            score.score = 0;
        }
        rewardValue++;
    }

    public void SetRewardValue()
    {
        switch (GM.playersLeft)
        {
            case 1:
                rewardValue = 1;
                break;
            case 2:
                rewardValue = -1;
                break;
            case 3:
                rewardValue = -1;
                break;
            case 4:
                rewardValue = -2;
                break;
            case 5:
                rewardValue = -2;
                break;
            case 6:
                rewardValue = -3;
                break;
            case 7:
                rewardValue = -3;
                break;
            case 8:
                rewardValue = -3;
                break;
        }

        if (gameTime <= 0)
        {
            rewardValue++;
        }
    }

    public void RewardLastPlayerAlive()
    {
        if (GM.p1Alive)
        {
            UpdateScore(GM.p1Score);
        }
        else if (GM.p2Alive)
        {
            UpdateScore(GM.p2Score);
        }
        else if (GM.p3Alive)
        {
            UpdateScore(GM.p3Score);
        }
        else if (GM.p4Alive)
        {
            UpdateScore(GM.p4Score);
        }
        else if (GM.p5Alive)
        {
            UpdateScore(GM.p5Score);
        }
        else if (GM.p6Alive)
        {
            UpdateScore(GM.p6Score);
        }
        else if (GM.p7Alive)
        {
            UpdateScore(GM.p7Score);
        }
        else if (GM.p8Alive)
        {
            UpdateScore(GM.p8Score);
        }
    }
}
