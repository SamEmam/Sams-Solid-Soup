using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class REndGameManager : MonoBehaviour
{
    public RGameMaster GM;
    public RScoreManager SM;
    public RResetManager RM;

    public SceneLoader sceneLoader;
    public TextMeshProUGUI message;
    public bool gameHasEnded = false;

    public void EndGameCheck()
    {
        if (GM.playersLeft <= 1)
        {
            GM.roundsPlayed++;
            SM.RewardLastPlayerAlive();
            if (CheckForWinner() > 0)
            {
                RewardWinner(CheckForWinner());
                StartCoroutine(EndGame());
            }
            else
            {
                GM.playersLeft = 0;
                RM.Respawn();
                RM.ResetPowerups();
                RM.ResetPlayers();
                SM.SetRewardValue();
            }
        }
    }

    public IEnumerator EndGame()
    {
        gameHasEnded = true;
        yield return new WaitForSeconds(3);
        sceneLoader.LoadSceneByIndex(5); // CHANGE TO score scene
    }

    public void RewardWinner(int playerNum)
    {
        switch (playerNum)
        {
            case 1:
                //GamePrefs.Player1Score++;
                message.text += "P1 WINS!";
                break;
            case 2:
                //GamePrefs.Player2Score++;
                message.text += "P2 WINS!";
                break;
            case 3:
                //GamePrefs.Player3Score++;
                message.text += "P3 WINS!";
                break;
            case 4:
                //GamePrefs.Player4Score++;
                message.text += "P4 WINS!";
                break;
            case 5:
                //GamePrefs.Player5Score++;
                message.text += "P5 WINS!";
                break;
            case 6:
                //GamePrefs.Player6Score++;
                message.text += "P6 WINS!";
                break;
            case 7:
                //GamePrefs.Player7Score++;
                message.text += "P7 WINS!";
                break;
            case 8:
                //GamePrefs.Player8Score++;
                message.text += "P8 WINS!";
                break;

        }
    }

    public int CheckForWinner()
    {
        if (GM.p1Score && GM.p1Score.score >= SM.winScore)
        {
            return GM.p1Score.playerNum;
        }
        else if (GM.p2Score && GM.p2Score.score >= SM.winScore)
        {
            return GM.p2Score.playerNum;
        }
        else if (GM.p3Score && GM.p3Score.score >= SM.winScore)
        {
            return GM.p3Score.playerNum;
        }
        else if (GM.p4Score && GM.p4Score.score >= SM.winScore)
        {
            return GM.p4Score.playerNum;
        }
        else if (GM.p5Score && GM.p5Score.score >= SM.winScore)
        {
            return GM.p5Score.playerNum;
        }
        else if (GM.p6Score && GM.p6Score.score >= SM.winScore)
        {
            return GM.p6Score.playerNum;
        }
        else if (GM.p7Score && GM.p7Score.score >= SM.winScore)
        {
            return GM.p7Score.playerNum;
        }
        else if (GM.p8Score && GM.p8Score.score >= SM.winScore)
        {
            return GM.p8Score.playerNum;
        }
        else
        {
            return -1;
        }
    }
}
