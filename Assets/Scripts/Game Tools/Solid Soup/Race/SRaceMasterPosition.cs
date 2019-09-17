using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SRaceMasterPosition : MonoBehaviour
{
    public SRacePlayerPosition[] players;
    private List<SRacePlayerPosition> playerPositionList = new List<SRacePlayerPosition>();

    private void Start()
    {
        StartCoroutine(DelayedStart());
    }

    IEnumerator DelayedStart()
    {
        yield return new WaitForSeconds(0.5f);

        foreach (var player in players)
        {
            if (player.gameObject.activeInHierarchy)
            {
                playerPositionList.Add(player);
            }
        }
    }

    private void Update()
    {
        BubbleSort();
    }

    void BubbleSort()
    {
        SRacePlayerPosition tempPlayer;
        for (int i = 0; i < playerPositionList.Count; i++)
        {
            playerPositionList[i].CalculatePoints();
            Debug.Log("player: " + playerPositionList[i]);
            for (int j = 0; j < playerPositionList.Count - 1; j++)
            {
                playerPositionList[j].CalculatePoints();

                if (playerPositionList[j].points > playerPositionList[j + 1].points)
                {

                    tempPlayer = playerPositionList[j];
                    playerPositionList[j] = playerPositionList[j + 1];
                    playerPositionList[j + 1] = tempPlayer;
                    
                }
            }
        }

        SetPosition();
    }

    void SetPosition()
    {
        for (int i = 0; i < playerPositionList.Count; i++)
        {
            playerPositionList[i].position = i + 1;
        }
    }
}
