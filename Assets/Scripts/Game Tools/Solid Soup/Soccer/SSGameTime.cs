using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SSGameTime : MonoBehaviour
{
    private float timeBeforeEnd = 3f;
    private float gameCounter;
    private bool hasEnded = false;
    private SceneLoader sceneLoader;
    public TextMeshProUGUI gameTimer;
    [SerializeField]
    private SSGoal goal1, goal2;

    private void Start()
    {
        sceneLoader = GetComponent<SceneLoader>();
        gameCounter = timeBeforeEnd * 60;
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

    IEnumerator EndScene()
    {
        goal1.hasBeenAwarded = true;
        goal2.hasBeenAwarded = true;
        yield return new WaitForSeconds(5);
        sceneLoader.LoadSceneByIndex(4);
    }
}
