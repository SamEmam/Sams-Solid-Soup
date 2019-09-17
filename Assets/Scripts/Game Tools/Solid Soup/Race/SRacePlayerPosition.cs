using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SRacePlayerPosition : MonoBehaviour
{
    [HideInInspector]
    public int points;
    [HideInInspector]
    public int position;
    [HideInInspector]
    public string positionString;


    private SRacePlayerCheckpoint playerCP;
    public SRaceCheckpoint[] checkpoints;
    private Transform nextCP;
    
    

    private void Start()
    {
        playerCP = GetComponent<SRacePlayerCheckpoint>();
    }

    private void Update()
    {
        if (playerCP.checkpointCount == checkpoints.Length)
        {
            nextCP = checkpoints[0].transform;
        }
        else
        {
            nextCP = checkpoints[playerCP.checkpointCount].transform;
        }
        CreatePositionString();
    }

    public void CalculatePoints()
    {
        points = 1000000;
        points -= (playerCP.laps * 10000);
        points -= (playerCP.checkpointCount * 1000);
        points += (int)Vector3.Distance(transform.position, nextCP.position);
    }

    void CreatePositionString()
    {
        switch (position)
        {
            case 1:
                positionString = "1st";
                break;
            case 2:
                positionString = "2nd";
                break;
            case 3:
                positionString = "3rd";
                break;
            case 4:
                positionString = "4th";
                break;
            case 5:
                positionString = "5th";
                break;
            case 6:
                positionString = "6th";
                break;
            case 7:
                positionString = "7th";
                break;
            case 8:
                positionString = "8th";
                break;
        }
    }
}
