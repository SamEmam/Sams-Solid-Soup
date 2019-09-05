using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RScoreManager : MonoBehaviour
{
    public RGameMaster GM;

    public int rewardValue;
    public int winScore = 10;
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
        if (GamePrefs.TotalPlayerCount > 2)
        {
            winScore += winScoreHalf;
        }
        if (GamePrefs.TotalPlayerCount > 4)
        {
            winScore += winScoreHalf * 2;
        }
        if (GamePrefs.TotalPlayerCount > 6)
        {
            winScore += winScoreHalf * 3;
        }
    }

    public void UpdateScore(RPlayerScore score)
    {
        if (rewardValue == 0)
        {
            rewardValue++;
        }
        score.score += rewardValue;
        UpdatePrefScore(score.playerNum, rewardValue);
        if (score.score < 0)
        {
            score.score = 0;
        }
        rewardValue++;
    }

    void UpdatePrefScore(int playerNum, int reward)
    {
        switch (playerNum)
        {
            case 1:
                GamePrefs.Player1Score += reward;
                if (GamePrefs.Player1Score < 0)
                {
                    GamePrefs.Player1Score = 0;
                }
                break;
            case 2:
                GamePrefs.Player2Score += reward;
                if (GamePrefs.Player2Score < 0)
                {
                    GamePrefs.Player2Score = 0;
                }
                break;
            case 3:
                GamePrefs.Player3Score += reward;
                if (GamePrefs.Player3Score < 0)
                {
                    GamePrefs.Player3Score = 0;
                }
                break;
            case 4:
                GamePrefs.Player4Score += reward;
                if (GamePrefs.Player4Score < 0)
                {
                    GamePrefs.Player4Score = 0;
                }
                break;
            case 5:
                GamePrefs.Player5Score += reward;
                if (GamePrefs.Player5Score < 0)
                {
                    GamePrefs.Player5Score = 0;
                }
                break;
            case 6:
                GamePrefs.Player6Score += reward;
                if (GamePrefs.Player6Score < 0)
                {
                    GamePrefs.Player6Score = 0;
                }
                break;
            case 7:
                GamePrefs.Player7Score += reward;
                if (GamePrefs.Player7Score < 0)
                {
                    GamePrefs.Player7Score = 0;
                }
                break;
            case 8:
                GamePrefs.Player8Score += reward;
                if (GamePrefs.Player8Score < 0)
                {
                    GamePrefs.Player8Score = 0;
                }
                break;
            default:
                break;
        }
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
