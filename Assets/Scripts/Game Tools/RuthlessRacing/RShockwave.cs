using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Rewired;

public class RShockwave : MonoBehaviour
{
    [Header("Attributes")]
    public float impactForce = 5f;
    public float radius = 15f;
    public float upwardsThrust = 2f;

    [Header("Powerup Settings")]
    public int playerNum;
    public int powerupNum = 4;

    [Header("Setup")]
    public ParticleSystem explosion;
    public Rigidbody rb;
    public RPlayerPowerup playerPowerup;
    private Player player;


    private void Start()
    {
        player = ReInput.players.GetPlayer(playerNum);
    }

    private void Update()
    {
        if (player.GetButtonDown("Shoot"))
        {
            Shockwave();
        }
    }

    void Shockwave()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, radius);
        foreach (Collider hit in colliders)
        {
            Rigidbody hitRB = hit.GetComponent<Rigidbody>();
            if (hitRB != null && hitRB != rb /* && !hit.GetComponent<RNotAffected>()*/)
            {
                hitRB.AddExplosionForce(impactForce, transform.position, radius, upwardsThrust, ForceMode.VelocityChange);
            }
        }
        Instantiate(explosion, transform.position, transform.rotation);
        playerPowerup.DisablePowerup(powerupNum);
    }
}
