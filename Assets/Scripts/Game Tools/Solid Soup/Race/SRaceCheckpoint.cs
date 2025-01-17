﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SRaceCheckpoint : MonoBehaviour
{
    public int checkpointNum;
    public GameObject explosion;

    public AudioClip clip;
    private AudioSource source;
    private GameObject audioPlayer;

    private void Awake()
    {
        GetComponent<BoxCollider>().isTrigger = true;

        audioPlayer = new GameObject("CP Audio");
        audioPlayer.transform.SetParent(transform);
        source = audioPlayer.AddComponent<AudioSource>();
        if (clip)
        {
            source.clip = clip;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            SRacePlayerCheckpoint cp = other.GetComponent<SRacePlayerCheckpoint>();

            if (!cp)
            {
                return;
            }

            if (cp.checkpointCount == checkpointNum - 1)
            {
                if (explosion)
                {
                    Instantiate(explosion, transform.position + Vector3.down, transform.rotation);
                    if (clip)
                    {
                        source.Play();
                    }
                }
                cp.checkpointCount++;
                cp.respawnPoint = transform;
            }
            else if (cp.checkpointCount == checkpointNum)
            {
                //if (explosion)
                //{
                //    Instantiate(explosion, transform.position + Vector3.down, transform.rotation);
                //}
                cp.checkpointCount = checkpointNum;
                cp.respawnPoint = transform;
            }
        }
    }
}
