using Rewired;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SRacePlayerCheckpoint : MonoBehaviour
{
    public int playerNum;
    public int checkpointCount;
    public int laps;
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
            Respawn(respawnPoint);
        }
    }

    void Respawn(Transform resPoint)
    {
        gameObject.transform.position = resPoint.position;
        gameObject.transform.rotation = resPoint.rotation;
        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
    }

}
