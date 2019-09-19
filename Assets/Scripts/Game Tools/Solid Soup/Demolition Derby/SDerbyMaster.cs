﻿using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SDerbyMaster : MonoBehaviour
{
    public SDerbyPlayer[] players;
    private float timeBeforeEnd = 3f;
    private float gameCounter;
    private bool hasEnded = false;
    private SceneLoader sceneLoader;
    public TextMeshProUGUI gameTimer;

    private void Start()
    {
        sceneLoader = GetComponent<SceneLoader>();
        gameCounter = timeBeforeEnd * 60;
    }

    public void GivePoints(int points, int player)
    {
        players[player].points += points;
    }

    private void Update()
    {
        if (hasEnded)
        {
            return;
        }
        gameCounter -= Time.deltaTime;

        if (gameCounter <= 0)
        {
            // End Game
            hasEnded = true;
            gameTimer.text = "Game Over!";
            StartCoroutine(EndScene());
            return;

        }
        else
        {
            var sec = gameCounter % 60;
            var min = gameCounter / 60;

            if (sec < 10)
            {

                gameTimer.text = (int)min + ":0" + (int)sec;
            }
            else
            {
                gameTimer.text = (int)min + ":" + (int)sec;
            }
        }
    }

    void BubbleSort()
    {
        SDerbyPlayer tempPlayer;
        for (int i = 0; i < players.Length; i++)
        {
            for (int j = 0; j < players.Length - 1; j++)
            {

                if (players[j].points > players[j + 1].points)
                {

                    tempPlayer = players[j];
                    players[j] = players[j + 1];
                    players[j + 1] = tempPlayer;

                }
            }
        }

        for (int i = players.Length - 1; i > 0; i++)
        {
            AwardPlayerScore(players[i].playerNum, i);
        }
    }

    public void AwardPlayerScore(int player, int score)
    {
        switch (player)
        {
            case 1:
                GamePrefs.Player1Score += score;
                break;
            case 2:
                GamePrefs.Player2Score += score;
                break;
            case 3:
                GamePrefs.Player3Score += score;
                break;
            case 4:
                GamePrefs.Player4Score += score;
                break;
            case 5:
                GamePrefs.Player5Score += score;
                break;
            case 6:
                GamePrefs.Player6Score += score;
                break;
            case 7:
                GamePrefs.Player7Score += score;
                break;
            case 8:
                GamePrefs.Player8Score += score;
                break;
        }
    }

    IEnumerator EndScene()
    {
        BubbleSort();

        foreach (var player in players)
        {
            if (player)
            {
                player.canTakeDMG = false;
            }
        }
        yield return new WaitForSeconds(5);
        sceneLoader.LoadSceneByIndex(4);
    }
}