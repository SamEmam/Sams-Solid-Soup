using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PodiumPositioner : MonoBehaviour
{
    public PodiumSorting PS;

    [Header("Players")]
    public Transform[] playerPositions;
    public Transform[] players;

    [Header("Points")]
    public Transform[] pointPositions;
    public Transform[] points;

    [Header("Materials")]
    public Material[] materials;
    public MeshRenderer[] podiums;
    

    public void RelocatePlayers()
    {
        Debug.Log("relocating");
        for (int i = 0; i < PS.players.Count; i++)
        {
            //Debug.Log(PS.players.Count);
            Debug.Log(PS.players[i]);
            players[PS.players[i] - 1].position = playerPositions[i].position;
            players[PS.players[i] - 1].rotation = playerPositions[i].rotation;

            points[PS.players[i] - 1].position = pointPositions[i].position;
            points[PS.players[i] - 1].rotation = pointPositions[i].rotation;

            podiums[i].gameObject.SetActive(true);
            podiums[i].material = GetPlayerColor(PS.players[i]);
        }
    }

    Material GetPlayerColor(int playerNum)
    {
        switch (playerNum)
        {
            case 1:
                return materials[(int)GamePrefs.P1Color];
            case 2:
                return materials[(int)GamePrefs.P2Color];
            case 3:
                return materials[(int)GamePrefs.P3Color];
            case 4:
                return materials[(int)GamePrefs.P4Color];
            case 5:
                return materials[(int)GamePrefs.P5Color];
            case 6:
                return materials[(int)GamePrefs.P6Color];
            case 7:
                return materials[(int)GamePrefs.P7Color];
            case 8:
                return materials[(int)GamePrefs.P8Color];
            default:
                return materials[(int)GamePrefs.P1Color];
        }
    }
}
