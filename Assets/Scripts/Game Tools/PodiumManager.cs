using Rewired;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PodiumManager : MonoBehaviour
{

    private Player player;
    private SceneLoader sceneLoader;


    private void Start()
    {
        player = ReInput.players.GetPlayer(1);
        sceneLoader = GetComponent<SceneLoader>();
    }

    private void Update()
    {
        if (player.GetButtonDown("Start"))
        {
            sceneLoader.LoadSceneByIndex(1);
        }
    }
}
