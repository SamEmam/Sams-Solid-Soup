using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SDerbyPlayerNumber : MonoBehaviour
{
    [HideInInspector]
    public int playerNum;

    private void Start()
    {
        playerNum = GetComponent<RPlayerScore>().playerNum;
    }
}
