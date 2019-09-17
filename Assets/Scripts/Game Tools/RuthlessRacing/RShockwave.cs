using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Rewired;

public class RShockwave : MonoBehaviour
{
    [Header("Attributes")]
    private float impactForce = 10f;
    private float radius = 15f;
    private float upwardsThrust = 5f;

    [Header("Powerup Settings")]
    public int playerNum;
    public int powerupNum = 4;

    [Header("Setup")]
    public ParticleSystem explosion;
    public Rigidbody rb;
    public RPlayerPowerup playerPowerup;
    private Player player;
    public AudioClip[] clips;
    private AudioSource source;
    private GameObject audioPlayer;


    private void Start()
    {
        player = ReInput.players.GetPlayer(playerNum);
        audioPlayer = new GameObject("Explosion Audio");
        audioPlayer.transform.SetParent(transform);
        source = audioPlayer.AddComponent<AudioSource>();
        source.clip = clips[Random.Range(0, clips.Length - 1)];
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
                source.Play();
                audioPlayer.transform.SetParent(null);
                Destroy(audioPlayer, 2f);
            }
        }
        Instantiate(explosion, transform.position, transform.rotation);
        playerPowerup.DisablePowerup(powerupNum);
    }
}
