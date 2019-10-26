using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SSBGameTimer : MonoBehaviour
{
    private float timeBeforeEnd = 1f;
    private float gameCounter;
    private bool hasEnded = false;
    private SceneLoader sceneLoader;
    public TextMeshProUGUI gameTimer;

    private bool countdownSoundOn = false;

    public AudioClip clip;
    private AudioSource source;
    private GameObject audioPlayer;

    private void Start()
    {
        audioPlayer = new GameObject("Countdown Audio");
        audioPlayer.transform.SetParent(transform);
        source = audioPlayer.AddComponent<AudioSource>();
        if (clip)
        {
            source.clip = clip;
        }

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
            if (gameCounter <= 6f && !countdownSoundOn)
            {
                countdownSoundOn = true;
                StartCoroutine(CountdownSound());
            }

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

    IEnumerator CountdownSound()
    {
        if (clip && !hasEnded)
        {
            source.Play();
        }
        yield return new WaitForSeconds(1);
        StartCoroutine(CountdownSound());
    }

    IEnumerator EndScene()
    {
        yield return new WaitForSeconds(5);
        sceneLoader.LoadSceneByIndex(4);
    }
}
