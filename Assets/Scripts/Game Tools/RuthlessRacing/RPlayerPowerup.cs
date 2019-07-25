using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Rewired;

public class RPlayerPowerup : MonoBehaviour
{
    [SerializeField]
    private GameObject[] Powerups;
    [SerializeField]
    private float[] seconds;

    private Player player;
    public int playerNum;

    private bool powerupTriggered = false;

    private void Start()
    {
        player = ReInput.players.GetPlayer(playerNum);
    }

    private void Update()
    {
        if (player.GetButtonDown("ResetPowerup"))
        {
            DisableAll();
        }
    }

    public bool HasPowerup()
    {
        return powerupTriggered;
    }

    public void EnablePowerup(int powerupNum)
    {
        Powerups[powerupNum].SetActive(true);
        powerupTriggered = true;
        if (seconds[powerupNum] > 0)
        {
            StartCoroutine(DisablePowerupAfterSeconds(powerupNum));
        }
    }

    IEnumerator DisablePowerupAfterSeconds(int powerupNum)
    {
        yield return new WaitForSeconds(seconds[powerupNum]);
        Powerups[powerupNum].SetActive(false);
        powerupTriggered = false;
    }

    public void DisablePowerup(int powerupNum)
    {
        Powerups[powerupNum].SetActive(false);
        powerupTriggered = false;
    }

    public void DisableAll()
    {
        for (int i = 0; i < Powerups.Length; i++)
        {
            DisablePowerup(i);
        }
    }
}
