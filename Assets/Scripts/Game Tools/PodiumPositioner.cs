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
    public MeshRenderer[] podiumMeshes;

    [Header("Podiums")]
    public Transform[] podiums;
    private float maxPoints;

    public void TransformPodiums()
    {
        ////float lowestPoints = PS.points[PS.points.Count - 1];

        //for (int i = 0; i < PS.points.Count; i++)
        //{
        //    if (i == 0)
        //    {
        //        maxPoints = PS.points[i];
        //        //continue;
        //    }

        //    float currentPoints = PS.points[i];
        //    float percentage = PS.points[i] / maxPoints;

        //    //percentage *= percentage * percentage * percentage * percentage;

        //    podiums[i].localScale = new Vector3(podiums[i].localScale.x, (6f * percentage), podiums[i].localScale.z);

        //    Debug.Log(PS.players[i] + ": y pos = " + PS.points[i] / maxPoints);

        //    Debug.Log(PS.players[i] + ": points = " + currentPoints);

        //    if (podiums[i].localScale.y < 0.1f)
        //    {
        //        podiums[i].localScale = new Vector3(podiums[i].localScale.x, 0.1f, podiums[i].localScale.z);
        //    }

        //    podiums[i].position = new Vector3(podiums[i].position.x, podiums[i].localScale.y / 2f, podiums[i].position.z);
        //    pointPositions[i].position = new Vector3(pointPositions[i].position.x, podiums[i].localScale.y + 2f, pointPositions[i].position.z);
        //    playerPositions[i].position = new Vector3(playerPositions[i].position.x, podiums[i].localScale.y, playerPositions[i].position.z);
        //}
        RelocatePlayers();
    }

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

            podiumMeshes[i].gameObject.SetActive(true);
            podiumMeshes[i].material = GetPlayerColor(PS.players[i]);
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
