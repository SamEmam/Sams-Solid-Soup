using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Rewired;

public class RMissileVolley : MonoBehaviour
{
    [Header("Properties")]
    public float fireDelay = 0.1f;
    public float spreadFactor = 0.5f;
    public float initialForce = 20f;
    public int playerNum;
    public int powerupNum = 0;

    private bool canShoot = true;

    [Header("Setup")]
    public GameObject parent;
    public Transform[] firepoints;
    public GameObject missile;
    public List<GameObject> missileGOs = new List<GameObject>();
    public RPlayerPowerup playerPowerup;

    private Player player;

    private void Start()
    {
        player = ReInput.players.GetPlayer(playerNum);
    }

    private void OnEnable()
    {
        canShoot = true;

        foreach (var firepoint in firepoints)
        {
            GameObject missileGO = Instantiate(missile, firepoint.position, firepoint.rotation, transform);
            missileGO.transform.localScale = firepoint.localScale;
            missileGOs.Add(missileGO);
        }
    }

    private void OnDisable()
    {
        canShoot = false;
        missileGOs = new List<GameObject>();
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
            missile.GetComponent<RMissile>().parent = parent;

            shootDir = missile.transform.rotation;
            shootDir.x += Random.Range(-spreadFactor, spreadFactor);
            shootDir.y += Random.Range(-spreadFactor, spreadFactor);
            missile.transform.rotation = shootDir;

            missile.transform.SetParent(null);
            rb.isKinematic = false;
            rb.useGravity = true;
            rb.AddForce(missile.transform.forward * initialForce, ForceMode.VelocityChange);

            yield return wait;
        }

        yield return new WaitForSeconds(3f);
        playerPowerup.DisablePowerup(powerupNum);
    }

}
