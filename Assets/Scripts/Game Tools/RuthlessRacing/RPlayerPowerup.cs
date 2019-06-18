using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XboxCtrlrInput;

public class RPlayerPowerup : MonoBehaviour
{
    [SerializeField]
    private GameObject[] Powerups;
    [SerializeField]
    private float[] seconds;
    [SerializeField]
    private bool[] useSeconds;
    [SerializeField]
    private XboxController controller;

    private bool powerupTriggered = false;

    private void Update()
    {
        if (XCI.GetButtonDown(XboxButton.Y, controller))
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
        if (useSeconds[powerupNum])
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
