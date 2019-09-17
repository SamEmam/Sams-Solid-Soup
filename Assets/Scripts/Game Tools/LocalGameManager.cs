using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Rewired;

public class LocalGameManager : MonoBehaviour
{
    private Player player;
    private SceneLoader sceneLoader;
    private SSoupSetup soupSetup;

    public AudioClip[] clips;
    private AudioSource source;

    // Start is called before the first frame update
    void Start()
    {
        player = ReInput.players.GetPlayer(1);
        sceneLoader = FindObjectOfType<SceneLoader>();
        soupSetup = FindObjectOfType<SSoupSetup>();

        source = gameObject.AddComponent<AudioSource>();
        source.clip = clips[Random.Range(0, clips.Length - 1)];
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (player.GetButtonDown("Up") || player.GetButtonDown("Down") || player.GetButtonDown("Left") || player.GetButtonDown("Right"))
        {
            source.Play();
        }

        if (player.GetButtonDown("Back"))
        {
            source.Play();
            sceneLoader.LoadSceneByIndex(0);
        }

        if (player.GetButtonDown("Start"))
        {
            source.Play();
            ResetPlayerScore();

            if (GamePrefs.GameMode == GameModeEnum.Racing)
            {
                sceneLoader.LoadSceneByIndex(2);
            }
            else if (GamePrefs.GameMode == GameModeEnum.Warfare)
            {
                sceneLoader.LoadSceneByIndex(2);
            }
            else if (GamePrefs.GameMode == GameModeEnum.Soup)
            {
                if (GamePrefs.WithSplit)
                {
                    soupSetup.SetSoupList(true);
                }
                else
                {
                    soupSetup.SetSoupList(false);
                }
                sceneLoader.LoadSceneByIndex(4);
            }
        }
    }

    void ResetPlayerScore()
    {
        GamePrefs.Player1Score = 0;
        GamePrefs.Player2Score = 0;
        GamePrefs.Player3Score = 0;
        GamePrefs.Player4Score = 0;
        GamePrefs.Player5Score = 0;
        GamePrefs.Player6Score = 0;
        GamePrefs.Player7Score = 0;
        GamePrefs.Player8Score = 0;
    }
}
