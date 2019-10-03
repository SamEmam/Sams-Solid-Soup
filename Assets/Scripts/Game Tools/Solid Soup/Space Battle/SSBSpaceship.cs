using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SSBSpaceship : MonoBehaviour
{
    [HideInInspector]
    public SSBPlayer SBP;

    public void KillSpaceship(int playerNum)
    {
        Debug.Log("On kill playerNum: " + playerNum);
        Debug.Log("On kill SSBPlayer: " + SBP);

        SBP.OnDeath(playerNum);
        Destroy(gameObject, 0.1f);
    }
}
