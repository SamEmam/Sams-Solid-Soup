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

    private void Start()
    {
        randomizePowerUp();
    }

    void randomizePowerUp()
    {
        rng = Random.Range(0, powerUps.Length);

        foreach (var powerUp in powerUps)
        {
            powerUp.SetActive(false);
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
        randomizePowerUp();
        canTriggerPowerUp = true;
    }
}