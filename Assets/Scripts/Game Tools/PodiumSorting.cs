using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PodiumSorting : MonoBehaviour
{
    public List<int> players = new List<int>();
    public List<int> points = new List<int>();
    private PodiumPositioner PP;

    private void Awake()
    {
        PP = GetComponent<PodiumPositioner>();

        if (GamePrefs.Player1)
        {
            players.Add(1);
            points.Add(GamePrefs.Player1Score);
        }
        if (GamePrefs.Player2)
        {
            players.Add(2);
            points.Add(GamePrefs.Player2Score);
        }
        if (GamePrefs.Player3)
        {
            players.Add(3);
            points.Add(GamePrefs.Player3Score);
        }
        if (GamePrefs.Player4)
        {
            players.Add(4);
            points.Add(GamePrefs.Player4Score);
        }
        if (GamePrefs.Player5)
        {
            players.Add(5);
            points.Add(GamePrefs.Player5Score);
        }
        if (GamePrefs.Player6)
        {
            players.Add(6);
            points.Add(GamePrefs.Player6Score);
        }
        if (GamePrefs.Player7)
        {
            players.Add(7);
            points.Add(GamePrefs.Player7Score);
        }
        if (GamePrefs.Player8)
        {
            players.Add(8);
            points.Add(GamePrefs.Player8Score);
        }

        BubbleSort();
    }

    void BubbleSort()
    {
        int tempPoints;
        int tempPlayer;
        for (int i = 0; i < players.Count - 1; i++)
        {
            for (int j = 0; j < players.Count - 1; j++)
            {
                //if (points[j] == players.Count - 2)
                //{
                //    return;
                //}

                if (points[j] < points[j + 1])
                {
                    tempPoints = points[j];
                    points[j] = points[j + 1];
                    points[j + 1] = tempPoints;

                    tempPlayer = players[j];
                    players[j] = players[j + 1];
                    players[j + 1] = tempPlayer;
                    
                }
            }
        }

        PP.TransformPodiums();
        //PP.RelocatePlayers();
    }
}
