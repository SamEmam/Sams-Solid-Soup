using Rewired;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RFlameThrower : MonoBehaviour
{
    [Header("Attributes")]
    public float speed = 2f;
    public int playerNum;
    public int powerupNum = 2;

    [Header("Setup")]
    public ParticleSystem flame1;
    public ParticleSystem flame2;
    public Rigidbody rb;

    private Player player;

    private void Start()
    {
        player = ReInput.players.GetPlayer(playerNum);
    }

    private void OnEnable()
    {
        Clear();
    }

    private void Update()
    {
        if (player.GetButton("Shoot"))
        {
            Play();
        }

        if (player.GetButtonUp("Shoot"))
        {
            Stop();
        }
    }

    void Play()
    {
        flame1.Play();
        flame2.Play();
        rb.AddForce(transform.forward * speed * - 1, ForceMode.Acceleration);
    }

    void Clear()
    {
        flame1.Stop();
        flame1.Clear();
        flame2.Stop();
        flame2.Clear();
    }

    void Stop()
    {
        flame1.Stop();
        flame2.Stop();
    }
}
