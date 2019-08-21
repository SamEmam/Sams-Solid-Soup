using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SERPlayer : MonoBehaviour
{
    [Header("Attributes")]
    public bool isRewarded = false;

    [Header("Setup")]
    public int playerNum;
    public SERDestroyerMaster GM;

    private void OnEnable()
    {
        playerNum = GetComponent<RPlayerScore>().playerNum;
        GM.players.Add(this);
        GM.playersLeft++;
    }

    public void RewardPlayer(int player)
    {
        if (isRewarded)
        {
            return;
        }
        isRewarded = true;
        switch (player)
        {
            case 1:
                GamePrefs.Player1Score += GM.rewardScore;
                break;
            case 2:
                GamePrefs.Player2Score += GM.rewardScore;
                break;
            case 3:
                GamePrefs.Player3Score += GM.rewardScore;
                break;
            case 4:
                GamePrefs.Player4Score += GM.rewardScore;
                break;
            case 5:
                GamePrefs.Player5Score += GM.rewardScore;
                break;
            case 6:
                GamePrefs.Player6Score += GM.rewardScore;
                break;
            case 7:
                GamePrefs.Player7Score += GM.rewardScore;
                break;
            case 8:
                GamePrefs.Player8Score += GM.rewardScore;
                break;
        }

        GM.rewardScore++;
        GM.playersLeft--;
    }
}
