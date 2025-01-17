﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SRaceTrailColor : MonoBehaviour
{
    private ParticleSystem trail;
    private int playerNum;

    // Start is called before the first frame update
    void Start()
    {
        playerNum = transform.parent.GetComponent<RPlayerScore>().playerNum;
        trail = GetComponent<ParticleSystem>();
        Setup();
    }

    void Setup()
    {
        switch (playerNum)
        {
            case 1:
                SetTrailColor((int)GamePrefs.P1Color);
                break;
            case 2:
                SetTrailColor((int)GamePrefs.P2Color);
                break;
            case 3:
                SetTrailColor((int)GamePrefs.P3Color);
                break;
            case 4:
                SetTrailColor((int)GamePrefs.P4Color);
                break;
            case 5:
                SetTrailColor((int)GamePrefs.P5Color);
                break;
            case 6:
                SetTrailColor((int)GamePrefs.P6Color);
                break;
            case 7:
                SetTrailColor((int)GamePrefs.P7Color);
                break;
            case 8:
                SetTrailColor((int)GamePrefs.P8Color);
                break;
        }
    }

    void SetTrailColor(int color)
    {
        var main = trail.main;

        switch (color)
        {
            case 0:
                main.startColor = new Color(63f / 255f, 68f / 255f, 68f / 255f, 1f);
                break;
            case 1:
                main.startColor = new Color(203f / 255f, 203f / 255f, 203f / 255f, 1f);
                break;
            case 2:
                main.startColor = new Color(198f / 255f, 68f / 255f, 65f / 255f, 1f);
                break;
            case 3:
                main.startColor = new Color(210f / 255f, 124f / 255f, 56f / 255f, 1f);
                break;
            case 4:
                main.startColor = new Color(211f / 255f, 177f / 255f, 41f / 255f, 1f);
                break;
            case 5:
                main.startColor = new Color(150f / 255f, 195f / 255f, 57f / 255f, 1f);
                break;
            case 6:
                main.startColor = new Color(34f / 255f, 143f / 255f, 105f / 255f, 1f);
                break;
            case 7:
                main.startColor = new Color(77f / 255f, 173f / 255f, 188f / 255f, 1f);
                break;
            case 8:
                main.startColor = new Color(80f / 255f, 117f / 255f, 173f / 255f, 1f);
                break;
            case 9:
                main.startColor = new Color(138f / 255f, 40f / 255f, 173f / 255f, 1f);
                break;

        }
    }
}
