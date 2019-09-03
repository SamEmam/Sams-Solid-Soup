using Rewired;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SRacePlayerCheckpoint : MonoBehaviour
{
    public int playerNum;
    public int checkpointCount;
    public int laps;
    public ParticleSystem respawnParticles;
    public Transform respawnPoint;
    public Player player;
    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        player = ReInput.players.GetPlayer(playerNum);
    }

    private void Update()
    {
        if (player.GetButtonDown("Respawn"))
        {
            Respawn();
        }
    }

    public void Respawn()
    {
        if (respawnParticles)
        {
            Instantiate(respawnParticles, transform.position, Quaternion.identity);
        }
        gameObject.transform.position = respawnPoint.position;
        gameObject.transform.rotation = respawnPoint.rotation;
        if (respawnParticles)
        {
            Instantiate(respawnParticles, transform.position, Quaternion.identity);
        }
        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
    }

}
