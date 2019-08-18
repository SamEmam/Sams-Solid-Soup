using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SScoreScene : MonoBehaviour
{
    public float scoreScreenCounter = 12f;

    public SceneLoader sceneLoader;

    public TextMeshProUGUI countdown;
    public TextMeshProUGUI roundsPlayed;

    private bool isLoadingScene = false;

    private void Start()
    {
        roundsPlayed.text = "Games played: " + GamePrefs.GamesPlayed;
        GamePrefs.GamesPlayed++;

        if (GamePrefs.GamesPlayed > GamePrefs.SoupList.Count)
        {
            // End Game
            sceneLoader.LoadSceneByIndex(1);
        }
    }

    private void Update()
    {
        GamePrefs.GameTime -= Time.deltaTime;

        if (GamePrefs.GameTime <= 0)
        {
            // End Game
            sceneLoader.LoadSceneByIndex(1);
        }

        if (isLoadingScene)
        {
            return;
        }

        if (scoreScreenCounter <= 0)
        {
            
            isLoadingScene = true;
            sceneLoader.LoadSceneByIndex(GamePrefs.SoupList[GamePrefs.GamesPlayed - 1]);
        }

        scoreScreenCounter -= Time.deltaTime;
        countdown.text = "Next game in: " + (int)scoreScreenCounter;
    }
}
