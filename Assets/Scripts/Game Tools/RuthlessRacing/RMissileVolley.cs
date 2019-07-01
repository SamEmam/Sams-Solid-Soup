using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Rewired;

public class RMissileVolley : MonoBehaviour
{
    [Header("Properties")]
    public float fireDelay = 0.1f;
    public float spreadFactor = 0.5f;
    public int playerNum;
    public int powerupNum = 0;

    private bool canShoot = true;

    [Header("Setup")]
    public GameObject[] missileGOs;
    public RPlayerPowerup playerPowerup;

    private Player player;
    

    private void OnEnable()
    {
        canShoot = true;
    }

    private void Update()
    {
        if (!canShoot)
        {
            return;
        }

        if (player.GetButtonDown("Shoot"))
        {
            canShoot = false;
            StartCoroutine(Shoot());
        }
    }

    IEnumerator Shoot()
    {
        Quaternion shootDir;
        WaitForSeconds wait = new WaitForSeconds(fireDelay);
        foreach (var missile in missileGOs)
        {
            Rigidbody rb = missile.GetComponent<Rigidbody>();

            shootDir = missile.transform.rotation;
            shootDir.x += Random.Range(-spreadFactor, spreadFactor);
            shootDir.y += Random.Range(-spreadFactor, spreadFactor);
            missile.transform.rotation = shootDir;

            missile.transform.SetParent(null);

            yield return wait;
        }
    }

}
