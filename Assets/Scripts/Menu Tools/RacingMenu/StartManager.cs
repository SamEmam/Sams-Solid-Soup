using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Rewired;

public class StartManager : MonoBehaviour
{
    [SerializeField]
    private SceneLoader sceneLoader;

    private Player player;

    private void Start()
    {
        player = ReInput.players.GetPlayer(1);
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (player.GetButtonDown("Select"))
        {
            switch ((int)GamePrefs.RaceMapEnum)
            {
                case 0:
                    sceneLoader.LoadSceneByIndex(6);
                    break;
                case 1:
                    sceneLoader.LoadSceneByIndex(7);
                    break;
                case 2:
                    sceneLoader.LoadSceneByIndex(8);
                    break;
                case 3:
                    sceneLoader.LoadSceneByIndex(9);
                    break;
            }
        }
    }

    private void Update()
    {
        if (player.GetButtonDown("Back"))
        {
            sceneLoader.LoadSceneByIndex(1);
        }
    }
}
