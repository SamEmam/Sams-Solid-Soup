using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SScoreScene : MonoBehaviour
{
    public float scoreScreenCounter = 12f;

    public SceneLoader sceneLoader;

    public TextMeshProUGUI countdown;
    public TextMeshProUGUI gamesPlayedText;
    public TextMeshProUGUI upcomingGame, loadingUpcomingGame;

    private string upcomingGameString;

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

        upcomingGameString = NameFromIndex(GamePrefs.SoupList[GamePrefs.GamesIndex - 1]);
        loadingUpcomingGame.text = upcomingGameString;
        upcomingGame.text = "Upcoming: " + upcomingGameString;
    }

    private void Update()
    {
        
        if (isLoadingScene)
        {
            return;
        }

        if (GamePrefs.GameTime <= 0)
        {
            // End Game
            isLoadingScene = true;
            sceneLoader.LoadSceneByIndex(5);
        }

        if (scoreScreenCounter <= 0)
        {
            
            isLoadingScene = true;
            sceneLoader.LoadSceneByIndex(GamePrefs.SoupList[GamePrefs.GamesIndex - 1]);
        }

        scoreScreenCounter -= Time.deltaTime;
        countdown.text = "Next game in: " + (int)scoreScreenCounter;
    }

    private string NameFromIndex(int BuildIndex)
    {
        string path = SceneUtility.GetScenePathByBuildIndex(BuildIndex);
        int slash = path.LastIndexOf('/');
        string name = path.Substring(slash + 1);
        int dot = name.LastIndexOf('.');
        return name.Substring(0, dot);
    }
}
