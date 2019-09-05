using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SPHPlayer : MonoBehaviour
{
    private int playerNum;

    private void Start()
    {
        playerNum = GetComponent<RPlayerScore>().playerNum;
    }

    public void AwardPoint(int point)
    {
        Debug.Log("Awarding point: " + transform.name + " " + playerNum);
        switch (playerNum)
        {
            case 1:
                GamePrefs.Player1Score += point;
                break;
            case 2:
                GamePrefs.Player2Score += point;
                break;
            case 3:
                GamePrefs.Player3Score += point;
                break;
            case 4:
                GamePrefs.Player4Score += point;
                break;
            case 5:
                GamePrefs.Player5Score += point;
                break;
            case 6:
                GamePrefs.Player6Score += point;
                break;
            case 7:
                GamePrefs.Player7Score += point;
                break;
            case 8:
                GamePrefs.Player8Score += point;
                break;
        }
    }
}
