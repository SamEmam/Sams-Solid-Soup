using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RPlayerScore : MonoBehaviour
{
    public int playerNum;

    public int score = 0;
    
    //private int laps = 0;
    //private GameObject finishParticles;
    //private string playerColorText;
    
    void SetScore()
    {
        switch (playerNum)
        {
            case 1:
                score = GamePrefs.Player1Score;
                break;
            case 2:
                score = GamePrefs.Player2Score;
                break;
            case 3:
                score = GamePrefs.Player3Score;
                break;
            case 4:
                score = GamePrefs.Player4Score;
                break;
            case 5:
                score = GamePrefs.Player5Score;
                break;
            case 6:
                score = GamePrefs.Player6Score;
                break;
            case 7:
                score = GamePrefs.Player7Score;
                break;
            case 8:
                score = GamePrefs.Player8Score;
                break;
            default:
                break;
        }
    }

    //public void PlayerColor()
    //{
    //    switch (playerNum)
    //    {
    //        case 1:
    //            playerColorText = "<color=#" + ColorUtility.ToHtmlStringRGB(Color.red) + ">PLAYER " + playerNum + "</color>";
    //            break;
    //        case 2:
    //            playerColorText = "<color=#" + ColorUtility.ToHtmlStringRGB(Color.blue) + ">PLAYER " + playerNum + "</color>";
    //            break;
    //        case 3:
    //            playerColorText = "<color=#" + ColorUtility.ToHtmlStringRGB(Color.green) + ">PLAYER " + playerNum + "</color>";
    //            break;
    //        case 4:
    //            playerColorText = "<color=#" + ColorUtility.ToHtmlStringRGB(Color.yellow) + ">PLAYER " + playerNum + "</color>";
    //            break;
    //        default:
    //            break;
    //    }
    //}

    public void AddScore()
    {
        switch (playerNum)
        {
            case 1:
                GamePrefs.Player1Score += score;
                break;
            case 2:
                GamePrefs.Player2Score += score;
                break;
            case 3:
                GamePrefs.Player3Score += score;
                break;
            case 4:
                GamePrefs.Player4Score += score;
                break;
            case 5:
                GamePrefs.Player5Score += score;
                break;
            case 6:
                GamePrefs.Player6Score += score;
                break;
            case 7:
                GamePrefs.Player7Score += score;
                break;
            case 8:
                GamePrefs.Player8Score += score;
                break;
            default:
                break;
        }
        score = 0;
    }
}
