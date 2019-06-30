using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class RDestroyer : MonoBehaviour
{
    public RGameMaster GM;
    public RScoreManager SM;
    public RResetManager RM;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (GM.playersLeft > 1)
            {
                GM.playersLeft--;
                RPlayerScore ps = other.GetComponent<RPlayerScore>();
                SM.UpdateScore(ps);
                RM.UnAlivePlayer(ps);
            }
        }
    }







}
