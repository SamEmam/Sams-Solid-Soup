using Rewired;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RMineLauncher : MonoBehaviour
{
    [Header("Attributes")]
    private float initialForce = 5f;
    public int playerNum;
    public int powerupNum = 1;

    private int mineCount = 3;
    private bool canShoot = true;

    [Header("Setup")]
    public Transform[] firepoints;
    public GameObject mine;
    public List<GameObject> mineGOs = new List<GameObject>();
    public RPlayerPowerup playerPowerup;

    private Player player;

    private void Start()
    {
        player = ReInput.players.GetPlayer(playerNum);
    }

    private void OnEnable()
    {
        canShoot = true;
        mineCount = 3;

        foreach (var firepoint in firepoints)
        {
            GameObject mineGO = Instantiate(mine, firepoint.position, firepoint.rotation, transform);
            mineGO.transform.localScale = firepoint.localScale;
            mineGOs.Add(mineGO);
        }
    }

    private void OnDisable()
    {
        canShoot = false;
        mineGOs = new List<GameObject>();
    }

    private void Update()
    {
        if (!canShoot)
        {
            return;
        }


        if (player.GetButtonDown("Shoot"))
        {
            Shoot();
        }

        
    }

    void Shoot()
    {
        GameObject shotMine = mineGOs[mineCount - 1];
        Rigidbody rb = shotMine.GetComponent<Rigidbody>();
        shotMine.transform.SetParent(null);
        rb.isKinematic = false;
        rb.useGravity = true;
        rb.AddForce(shotMine.transform.up * initialForce, ForceMode.VelocityChange);
        RMine rMine = shotMine.GetComponentInChildren<RMine>();
        rMine.isShot = true;
        rMine.playerNum = playerNum;
        StartCoroutine(EnableCollider(shotMine));
        mineCount--;

    }

    IEnumerator EnableCollider(GameObject shotMine)
    {
        BoxCollider collider = shotMine.GetComponent<BoxCollider>();

        yield return new WaitForSeconds(0.2f);

        collider.enabled = true;

        if (mineCount < 1)
        {
            playerPowerup.DisablePowerup(powerupNum);
        }
    }
}
