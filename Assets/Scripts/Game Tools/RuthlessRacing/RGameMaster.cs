using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class RGameMaster : MonoBehaviour
{
    [Header("Preferences")]

    [Header("Setup")]
    public RScoreManager SM;
    public RResetManager RM;
    public REndGameManager EGM;
    public int playersLeft;
    public int roundsPlayed;

    private float cooldownBeforeStart = 0.2f;

    [Header("Vehicle Setup")]
    public int totalPlayers;
    public RVehicleTypeSelector p1Type, p2Type, p3Type, p4Type, p5Type, p6Type, p7Type, p8Type;
    public GameObject p1, p2, p3, p4, p5, p6, p7, p8;
    public bool p1Alive = false, p2Alive = false, p3Alive = false, p4Alive = false, p5Alive = false, p6Alive = false, p7Alive = false, p8Alive = false, p9Alive = false;
    public RPlayerPowerup p1Power = new RPlayerPowerup(), p2Power = new RPlayerPowerup(), p3Power = new RPlayerPowerup(), p4Power = new RPlayerPowerup(), p5Power = new RPlayerPowerup(), p6Power = new RPlayerPowerup(), p7Power = new RPlayerPowerup(), p8Power = new RPlayerPowerup();
    public RPlayerScore p1Score = new RPlayerScore(), p2Score = new RPlayerScore(), p3Score = new RPlayerScore(), p4Score = new RPlayerScore(), p5Score = new RPlayerScore(), p6Score = new RPlayerScore(), p7Score = new RPlayerScore(), p8Score = new RPlayerScore();

    private void Start()
    {
        StartCoroutine(DelayedStart());
    }

    IEnumerator DelayedStart()
    {
        yield return new WaitForSeconds(0.1f);
        RM.ResetPlayers();
        SM.SetRewardValue();
    }

    private void Update()
    {
        if (EGM.gameHasEnded)
        {
            return;
        }
        if (cooldownBeforeStart > 0)
        {
            cooldownBeforeStart -= Time.deltaTime;
            return;
        }
        if (playersLeft <= 1)
        {
            EGM.EndGameCheck();
        }
    }

    public RPlayerScore GetPlayerScore(int playerNum)
    {
        switch (playerNum)
        {
            case 1:
                return p1Score;
            case 2:
                return p2Score;
            case 3:
                return p3Score;
            case 4:
                return p4Score;
            case 5:
                return p5Score;
            case 6:
                return p6Score;
            case 7:
                return p7Score;
            case 8:
                return p8Score;
            default:
                return new RPlayerScore();
        }
    }

}
