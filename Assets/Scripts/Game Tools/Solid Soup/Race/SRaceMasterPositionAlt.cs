using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SRaceMasterPositionAlt : MonoBehaviour
{
    [SerializeField]
    private RVehicleTypeSelector[] typeSelectors;
    [SerializeField]
    private SRacePlayerPosition[] players;
    private List<SRacePlayerPosition> playerPositionList = new List<SRacePlayerPosition>();

    private void Start()
    {
        for (int i = 0; i < typeSelectors.Length; i++)
        {
            if (typeSelectors[i].gameObject.activeInHierarchy)
            {
                players[i] = typeSelectors[i].GetVehicle().GetComponent<SRacePlayerPosition>();
            }
        }
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
            if (!playerPositionList[i])
            {
                continue;
            }
            playerPositionList[i].CalculatePoints();
            for (int j = 0; j < playerPositionList.Count - 1; j++)
            {
                if (!playerPositionList[j])
                {
                    continue;
                }
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
