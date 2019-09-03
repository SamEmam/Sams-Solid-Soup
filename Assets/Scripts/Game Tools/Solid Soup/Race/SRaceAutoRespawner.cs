using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SRaceAutoRespawner : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        var cp = other.GetComponent<SRacePlayerCheckpoint>();
        if (cp)
        {
            cp.Respawn();
        }
    }
}
