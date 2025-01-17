﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RRocket : MonoBehaviour
{
    [Header("Attributes")]
    public Transform target;
    public float speed = 1f;
    public float rotSpeed = 0.5f;
    public float lifespan = 10f;
    public float impactForce;
    public float radius = 50f;
    public float upwardsThrust = 5f;
    [HideInInspector]
    public int playerNum;

    [Header("Setup")]
    public ParticleSystem explosion1;
    public ParticleSystem explosion2;
    public GameObject thrust;
    public AudioClip[] clips;
    private AudioSource source;
    private GameObject audioPlayer;

    private void Start()
    {
        audioPlayer = new GameObject("Explosion Audio");
        audioPlayer.transform.SetParent(transform);
        source = audioPlayer.AddComponent<AudioSource>();
        source.clip = clips[Random.Range(0, clips.Length - 1)];
    }

    private void Update()
    {
        if (target)
        {
            MoveTowardsTarget();
            RotateTowardsTarget();
        }
        else
        {
            MoveForward();
        }

        if (lifespan < 0f)
        {
            Explode();
        }

        lifespan -= Time.deltaTime;
    }

    void MoveTowardsTarget()
    {
        float step = speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, target.position, step);
    }

    void RotateTowardsTarget()
    {
        Vector3 targetDir = target.position - transform.position;
        float step = rotSpeed * Time.deltaTime;

        Vector3 newDir = Vector3.RotateTowards(transform.forward, targetDir, step, 0.0f);

        transform.rotation = Quaternion.LookRotation(newDir);
    }

    void MoveForward()
    {
        float step = speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, transform.position + (transform.forward * 10), step);
    }

    void Explode()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, radius);
        foreach (Collider hit in colliders)
        {
            Rigidbody hitRB = hit.GetComponent<Rigidbody>();
            if (hitRB != null /* && !hit.GetComponent<WNotAffected>()*/)
            {
                hitRB.AddExplosionForce(impactForce, transform.position, radius, upwardsThrust, ForceMode.VelocityChange);
                source.Play();
                audioPlayer.transform.SetParent(null);
                Destroy(audioPlayer, 2f);
            }

            SDerbyPlayer hitDerby = hit.GetComponent<SDerbyPlayer>();
            if (hitDerby)
            {
                int dist = (int)Vector3.Distance(transform.position, hit.transform.position);
                hitDerby.TakeDamage(Mathf.Abs((int)((radius - dist) * 20)), playerNum);
            }
        }
        Instantiate(explosion1, transform.position, transform.rotation);
        Instantiate(explosion2, transform.position, transform.rotation);
        thrust.GetComponent<ParticleSystem>().Stop();
        thrust.transform.SetParent(null);
        Destroy(transform.gameObject);
    }

    private void OnCollisionEnter(Collision collision)
    {
        Explode();
    }
}
