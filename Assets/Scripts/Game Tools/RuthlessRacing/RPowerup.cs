using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RPowerup : MonoBehaviour
{
    private float seconds = 10f;
    [SerializeField]
    private GameObject[] powerUps;

    private int rng;
    private bool canTriggerPowerUp = true;

    [SerializeField]
    [Range(-1,4)]
    private int overPowerRNG = -1;

    private void Start()
    {
        RandomizePowerUp();
    }

    void RandomizePowerUp()
    {
        foreach (var powerUp in powerUps)
        {
            powerUp.SetActive(false);
        }

        if (overPowerRNG == -1)
        {
            rng = Random.Range(0, powerUps.Length);
        }
        else
        {
            rng = overPowerRNG;
        }

        powerUps[rng].SetActive(true);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" && canTriggerPowerUp)
        {
            if (!other.GetComponent<RPlayerPowerup>().HasPowerup())
            {
                canTriggerPowerUp = false;
                other.GetComponent<RPlayerPowerup>().EnablePowerup(rng);
                StartCoroutine(DisablePowerUp());
            }
        }
    }

    IEnumerator DisablePowerUp()
    {
        powerUps[rng].SetActive(false);
        yield return new WaitForSeconds(seconds);
        RandomizePowerUp();
        canTriggerPowerUp = true;
    }
}