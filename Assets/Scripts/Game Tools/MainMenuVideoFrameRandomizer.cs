using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class MainMenuVideoFrameRandomizer : MonoBehaviour
{
    public VideoPlayer player;

    private void Start()
    {
        var frameCount = player.frameCount;

        player.frame = (int)Random.Range(0, frameCount - 1);
    }
}
