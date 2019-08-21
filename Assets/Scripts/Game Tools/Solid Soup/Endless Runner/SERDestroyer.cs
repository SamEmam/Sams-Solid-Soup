using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SERDestroyer : MonoBehaviour
{
    public bool canCleanup;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            SERPlayer player = other.GetComponent<SERPlayer>();

            if (player && !player.isRewarded)
            {
                player.RewardPlayer(player.playerNum);
            }
            Destroy(other.gameObject);
        }

        else if (canCleanup)
        {
            Destroy(other.gameObject);
        }
    }
}
