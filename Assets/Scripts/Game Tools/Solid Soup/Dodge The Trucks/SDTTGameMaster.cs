using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SDTTGameMaster : MonoBehaviour
{
    public SceneLoader sceneLoader;
    public int rewardScore = 0, playersLeft = 0;
    private bool hasUpdatedScore = false;
    public SDTTPlayer[] players;

    private void Update()
    {
        if (playersLeft <= 1 && !hasUpdatedScore)
        {
            // End Game
            hasUpdatedScore = true;
            // Display points earned
            StartCoroutine(EndScene());
        }
    }

    IEnumerator EndScene()
    {
        foreach (var player in players)
        {
            if (!player.isRewarded && player.gameObject.activeInHierarchy)
            {
                player.isRewarded = true;
                player.RewardPlayer(player.playerNum);
            }
        }
        yield return new WaitForSeconds(5);
        sceneLoader.LoadSceneByIndex(4);
    }
}
