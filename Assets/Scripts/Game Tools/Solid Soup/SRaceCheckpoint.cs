using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SRaceCheckpoint : MonoBehaviour
{
    public int checkpointNum;

    private void Awake()
    {
        GetComponent<BoxCollider>().isTrigger = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            SRacePlayerCheckpoint cp = other.GetComponent<SRacePlayerCheckpoint>();

            if (!cp)
            {
                return;
            }

            if (cp.checkpointCount == checkpointNum - 1)
            {
                cp.checkpointCount++;
                cp.respawnPoint = transform;
            }
            else if (cp.checkpointCount == checkpointNum)
            {
                cp.checkpointCount = checkpointNum;
                cp.respawnPoint = transform;
            }
        }
    }
}
