using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SSBPlayer : MonoBehaviour
{
    public int kills;
    private BoidController BC;
    private int playerNum;
    private SSBControllerMaster CM;
    
    private void Start()
    {
        BC = GetComponent<BoidController>();
        playerNum = BC.playerNum;
        CM = FindObjectOfType<SSBControllerMaster>();
    }

    public void Spawn()
    {
        BC.Spawn();
        AddScore();
    }

    public void OnDeath(int player)
    {
        SubtractScore();

        if (player == playerNum)
        {
            int rngPlayer;
            do
            {
                rngPlayer = Random.Range(0, CM.players.Length);
                Debug.Log("RNG player Reroll: " + rngPlayer);
            } while (rngPlayer + 1 == playerNum || !CM.players[rngPlayer].gameObject.activeInHierarchy);
            Debug.Log("RNG player: " + rngPlayer);
            CM.players[rngPlayer].Spawn();
        }
        else
        {
            CM.players[player - 1].Spawn();
        }
    }

    void AddScore()
    {
        switch (playerNum)
        {
            case 1:
                GamePrefs.Player1Score += 1;
                break;
            case 2:
                GamePrefs.Player2Score += 1;
                break;
            case 3:
                GamePrefs.Player3Score += 1;
                break;
            case 4:
                GamePrefs.Player4Score += 1;
                break;
            case 5:
                GamePrefs.Player5Score += 1;
                break;
            case 6:
                GamePrefs.Player6Score += 1;
                break;
            case 7:
                GamePrefs.Player7Score += 1;
                break;
            case 8:
                GamePrefs.Player8Score += 1;
                break;
        }
    }

    void SubtractScore()
    {
        switch (playerNum)
        {
            case 1:
                if (GamePrefs.Player1Score > 0)
                {
                    GamePrefs.Player1Score -= 1;
                }
                break;
            case 2:
                if (GamePrefs.Player2Score > 0)
                {
                    GamePrefs.Player2Score -= 1;
                }
                break;
            case 3:
                if (GamePrefs.Player3Score > 0)
                {
                    GamePrefs.Player3Score -= 1;
                }
                break;
            case 4:
                if (GamePrefs.Player4Score > 0)
                {
                    GamePrefs.Player4Score -= 1;
                }
                break;
            case 5:
                if (GamePrefs.Player5Score > 0)
                {
                    GamePrefs.Player5Score -= 1;
                }
                break;
            case 6:
                if (GamePrefs.Player6Score > 0)
                {
                    GamePrefs.Player6Score -= 1;
                }
                break;
            case 7:
                if (GamePrefs.Player7Score > 0)
                {
                    GamePrefs.Player7Score -= 1;
                }
                break;
            case 8:
                if (GamePrefs.Player8Score > 0)
                {
                    GamePrefs.Player8Score -= 1;
                }
                break;
        }
    }
}
