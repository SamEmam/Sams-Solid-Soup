using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XboxCtrlrInput;

public class LocalJoinManager : MonoBehaviour
{
    [SerializeField]
    private XboxController controller;
    [SerializeField]
    private int playerNum;
    [SerializeField]
    private GameObject playerObject;

    private void Start()
    {
        playerObject.SetActive(false);
        if (CheckPlayerStatus())
        {
            playerObject.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (XCI.GetButtonDown(XboxButton.A,controller))
        {
            JoinPlayer();
        }

        if (XCI.GetButtonDown(XboxButton.B, controller))
        {
            LeavePlayer();
        }
    }

    void LeavePlayer()
    {
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
