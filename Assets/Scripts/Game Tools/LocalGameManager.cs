using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Rewired;

public class LocalGameManager : MonoBehaviour
{
    private Player player;
    private SceneLoader sceneLoader;

    // Start is called before the first frame update
    void Start()
    {
        player = ReInput.players.GetPlayer(1);
        sceneLoader = FindObjectOfType<SceneLoader>();
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (player.GetButtonDown("Back"))
        {
            sceneLoader.LoadSceneByIndex(0);
        }

        if (player.GetButtonDown("Start"))
        {
            if (GamePrefs.GameMode == GameModeEnum.Racing)
            {
                sceneLoader.LoadSceneByIndex(2);
            }
            else if (GamePrefs.GameMode == GameModeEnum.Warfare)
            {
                sceneLoader.LoadSceneByIndex(3);
            }
            else if (GamePrefs.GameMode == GameModeEnum.Soup)
            {
                sceneLoader.LoadSceneByIndex(4);
            }
        }
    }
}
