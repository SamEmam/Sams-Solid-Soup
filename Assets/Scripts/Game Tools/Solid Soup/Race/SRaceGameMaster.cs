using System.Collections;
using System.Collections.Generic;
using TMPro;
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

    private bool countdownSoundOn = false;
    private float countdownTimer = 20f;
    public TextMeshProUGUI gameTimer;

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
        if (hasUpdatedScore)
        {
            return;
        }

        if (finishLine.playersLeft <= GamePrefs.TotalPlayerCount / 2 && !hasUpdatedScore)
        {
            if (countdownTimer <= 6f && !countdownSoundOn)
            {
                countdownSoundOn = true;
                StartCoroutine(CountdownSound());
            }
            countdownTimer -= Time.deltaTime;

            var sec = countdownTimer % 60;
            var min = countdownTimer / 60;

            if (sec < 10)
            {

                gameTimer.text = (int)min + ":0" + (int)sec;
            }
            else
            {
                gameTimer.text = (int)min + ":" + (int)sec;
            }
        }

        if (finishLine.playersLeft <= 0 || countdownTimer <= 0f)
        {
            hasUpdatedScore = true;

            gameTimer.text = "Game Over!";
            StartCoroutine(EndScene());
        
        }
    }

    IEnumerator CountdownSound()
    {
        if (clip && !hasUpdatedScore)
        {
            source.Play();
        }
        yield return new WaitForSeconds(1);
        StartCoroutine(CountdownSound());
    }

    IEnumerator EndScene()
    {
        yield return new WaitForSeconds(1);
        sceneLoader.LoadSceneByIndex(4);
    }

}
