using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SRaceGameMaster : MonoBehaviour
{
    public int playersLeft;
    public SceneLoader sceneLoader;

    public int totalPlayers;

    [HideInInspector]
    public RVehicleTypeSelector p1Type, p2Type, p3Type, p4Type, p5Type, p6Type, p7Type, p8Type;
    [HideInInspector]
    public GameObject p1, p2, p3, p4, p5, p6, p7, p8;
    [HideInInspector]
    public RPlayerScore p1Score = new RPlayerScore(), p2Score = new RPlayerScore(), p3Score = new RPlayerScore(), p4Score = new RPlayerScore(), p5Score = new RPlayerScore(), p6Score = new RPlayerScore(), p7Score = new RPlayerScore(), p8Score = new RPlayerScore();

    public SRaceFinishLine finishLine;
    private bool hasUpdatedScore;
    

    private void Start()
    {

        finishLine.playersLeft = 0;

        if (GamePrefs.Player1)
        {
            finishLine.playersLeft++;
        }
        if (GamePrefs.Player2)
        {
            finishLine.playersLeft++;
        }
        if (GamePrefs.Player3)
        {
            finishLine.playersLeft++;
        }
        if (GamePrefs.Player4)
        {
            finishLine.playersLeft++;
        }
        if (GamePrefs.Player5)
        {
            finishLine.playersLeft++;
        }
        if (GamePrefs.Player6)
        {
            finishLine.playersLeft++;
        }
        if (GamePrefs.Player7)
        {
            finishLine.playersLeft++;
        }
        if (GamePrefs.Player8)
        {
            finishLine.playersLeft++;
        }

        finishLine.rewardScore = finishLine.playersLeft;
    }

    private void Update()
    {
        if (finishLine.playersLeft <= 0 && !hasUpdatedScore)
        {
            hasUpdatedScore = true;
            // Display points earned

            StartCoroutine(EndScene());
        
        }
    }

    IEnumerator EndScene()
    {
        yield return new WaitForSeconds(5);
        sceneLoader.LoadSceneByIndex(4);
    }

    

}
