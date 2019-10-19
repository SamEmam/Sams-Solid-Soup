using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SRaceArtificialGravityCatchup : MonoBehaviour
{
    private SRaceArtificialGravity gravity;
    private SRacePlayerPosition playerPos;

    private void Start()
    {
        gravity = GetComponent<SRaceArtificialGravity>();
        playerPos = GetComponent<SRacePlayerPosition>();
    }

    private void Update()
    {
        if (playerPos.position == 1)
        {
            gravity.maxGravity = 2f;
        }
        else
        {
            gravity.maxGravity = 1.6f;
        }
    }
}
