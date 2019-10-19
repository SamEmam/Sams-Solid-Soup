using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SRaceRandomStartPosition : MonoBehaviour
{
    private List<Vector3> startPositions = new List<Vector3>();
    [SerializeField]
    private Transform[] players;

    private void Awake()
    {
        AddSpawnPos();
        ShuffleSpawnPos();
        SetPlayerPos();
    }

    void ShuffleSpawnPos()
    {
        for (int i = 0; i < startPositions.Count; i++)
        {
            Vector3 temp = startPositions[i];
            int randomIndex = Random.Range(i, startPositions.Count);
            startPositions[i] = startPositions[randomIndex];
            startPositions[randomIndex] = temp;
        }
    }

    void AddSpawnPos()
    {
        for (int i = 0; i < players.Length; i++)
        {
            if (CheckPlayerStatus(i + 1))
            {
                startPositions.Add(players[i].position);
            }
        }
    }

    bool CheckPlayerStatus(int playerNum)
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

    void SetPlayerPos()
    {
        for (int i = 0; i < startPositions.Count; i++)
        {
            players[i].position = startPositions[i];
        }
    }

}
