using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SDTTPlayerEnabler : MonoBehaviour
{
    public GameObject child;
    public int playerNum;

    private void Awake()
    {
        EnablePlayer(playerNum);
    }

    void EnablePlayer(int player)
    {
        switch (player)
        {
            case 1:
                if (GamePrefs.Player1)
                {
                    child.GetComponent<SDTTPlayer>().playerNum = playerNum;
                    child.SetActive(true);
                }
                else
                {
                    gameObject.SetActive(false);
                }
                break;
            case 2:
                if (GamePrefs.Player2)
                {
                    child.GetComponent<SDTTPlayer>().playerNum = playerNum;
                    child.SetActive(true);
                }
                else
                {
                    gameObject.SetActive(false);
                }
                break;
            case 3:
                if (GamePrefs.Player3)
                {
                    child.GetComponent<SDTTPlayer>().playerNum = playerNum;
                    child.SetActive(true);
                }
                else
                {
                    gameObject.SetActive(false);
                }
                break;
            case 4:
                if (GamePrefs.Player4)
                {
                    child.GetComponent<SDTTPlayer>().playerNum = playerNum;
                    child.SetActive(true);
                }
                else
                {
                    gameObject.SetActive(false);
                }
                break;
            case 5:
                if (GamePrefs.Player5)
                {
                    child.GetComponent<SDTTPlayer>().playerNum = playerNum;
                    child.SetActive(true);
                }
                else
                {
                    gameObject.SetActive(false);
                }
                break;
            case 6:
                if (GamePrefs.Player6)
                {
                    child.GetComponent<SDTTPlayer>().playerNum = playerNum;
                    child.SetActive(true);
                }
                else
                {
                    gameObject.SetActive(false);
                }
                break;
            case 7:
                if (GamePrefs.Player7)
                {
                    child.GetComponent<SDTTPlayer>().playerNum = playerNum;
                    child.SetActive(true);
                }
                else
                {
                    gameObject.SetActive(false);
                }
                break;
            case 8:
                if (GamePrefs.Player8)
                {
                    child.GetComponent<SDTTPlayer>().playerNum = playerNum;
                    child.SetActive(true);
                }
                else
                {
                    gameObject.SetActive(false);
                }
                break;
        }
    }
}
