using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SRaceFinishLine : MonoBehaviour
{
    public int rewardScore;
    public int playersLeft;
    public int raceLaps;
    public int raceCheckpoints;

    private void Awake()
    {
        GetComponent<BoxCollider>().isTrigger = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            RPlayerScore ps = other.GetComponent<RPlayerScore>();
            SRacePlayerCheckpoint cp = other.GetComponent<SRacePlayerCheckpoint>();

            if (!ps)
            {
                return;
            }

            if (cp.checkpointCount >= raceCheckpoints)
            {
                if (cp.laps < raceLaps - 1)
                {
                    cp.laps++;
                    cp.checkpointCount = 0;
                    return;
                }

                ps.score += rewardScore;
                rewardScore--;

                // Instantiate player ragdoll
                Destroy(other.gameObject);

                playersLeft--;
            }
        }
    }
}
