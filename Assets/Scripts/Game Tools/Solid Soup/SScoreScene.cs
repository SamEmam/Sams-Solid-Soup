using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SScoreScene : MonoBehaviour
{
    public float scoreScreenCounter = 12f;

    public SceneLoader sceneLoader;

    public TextMeshProUGUI countdown;
    public TextMeshProUGUI gamesPlayedText;

    private bool isLoadingScene = false;

    private void Start()
    {
        gamesPlayedText.text = "Games played: " + GamePrefs.GamesPlayed;
        GamePrefs.GamesPlayed += 1;
        GamePrefs.GamesIndex += 1;

        if (GamePrefs.GamesIndex > GamePrefs.SoupList.Count)
        {
            // Reshuffle games
            for (int i = 0; i < GamePrefs.SoupList.Count - 1; i++)
            {
                var r = Random.Range(i, GamePrefs.SoupList.Count);
                var temp = GamePrefs.SoupList[i];
                GamePrefs.SoupList[i] = GamePrefs.SoupList[r];
                GamePrefs.SoupList[r] = temp;
            }
            GamePrefs.GamesIndex = 1;
            
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
            sceneLoader.LoadSceneByIndex(GamePrefs.SoupList[GamePrefs.GamesIndex - 1]);
        }

        scoreScreenCounter -= Time.deltaTime;
        countdown.text = "Next game in: " + (int)scoreScreenCounter;
    }
}
