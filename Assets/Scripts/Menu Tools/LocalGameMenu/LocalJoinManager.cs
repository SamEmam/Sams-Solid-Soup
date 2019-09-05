using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Rewired;

public class LocalJoinManager : MonoBehaviour
{
    private Player player;
    [SerializeField]
    private int playerNum;
    [SerializeField]
    private GameObject playerObject;

    private bool hasJoined;

    private void Start()
    {
        player = ReInput.players.GetPlayer(playerNum);
        playerObject.SetActive(false);
        hasJoined = false;

        if (CheckPlayerStatus())
        {
            playerObject.SetActive(true);
            hasJoined = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (player.GetButtonDown("A") && !hasJoined)
        {
            JoinPlayer();
        }

        if (player.GetButtonDown("B") && hasJoined)
        {
            LeavePlayer();
        }
    }

    void LeavePlayer()
    {
        hasJoined = false;
        GamePrefs.TotalPlayerCount -= 1;
        playerObject.SetActive(false);
        switch (playerNum)
        {
            case 1:
                GamePrefs.Player1 = false;
                break;
            case 2:
                GamePrefs.Player2 = false;
                break;
            case 3:
                GamePrefs.Player3 = false;
                break;
            case 4:
                GamePrefs.Player4 = false;
                break;
            case 5:
                GamePrefs.Player5 = false;
                break;
            case 6:
                GamePrefs.Player6 = false;
                break;
            case 7:
                GamePrefs.Player7 = false;
                break;
            case 8:
                GamePrefs.Player8 = false;
                break;
        }
    }

    void JoinPlayer()
    {
        hasJoined = true;
        GamePrefs.TotalPlayerCount += 1;
        playerObject.SetActive(true);
        switch (playerNum)
        {
            case 1:
                GamePrefs.Player1 = true;
                break;
            case 2:
                GamePrefs.Player2 = true;
                break;
            case 3:
                GamePrefs.Player3 = true;
                break;
            case 4:
                GamePrefs.Player4 = true;
                break;
            case 5:
                GamePrefs.Player5 = true;
                break;
            case 6:
                GamePrefs.Player6 = true;
                break;
            case 7:
                GamePrefs.Player7 = true;
                break;
            case 8:
                GamePrefs.Player8 = true;
                break;
        }
    }

    bool CheckPlayerStatus()
    {
        switch (playerNum)
        {
            case 1:
                return GamePrefs.Player1;
            case 2:
                return GamePrefs.Player2;
            case 3:
                return GamePrefs.Player3;
            case 4:
                return GamePrefs.Player4;
            case 5:
                return GamePrefs.Player5;
            case 6:
                return GamePrefs.Player6;
            case 7:
                return GamePrefs.Player7;
            case 8:
                return GamePrefs.Player8;
            default:
                return false;
        }
    }
}
