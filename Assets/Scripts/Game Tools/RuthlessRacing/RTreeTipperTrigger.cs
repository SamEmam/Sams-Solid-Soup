using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RTreeTipperTrigger : MonoBehaviour
{
    private Rigidbody rb;
    private Vector3 startPos;
    private Vector3 startRot;
    private float resetTime = 7f;
    private float pauseTime = 5f;
    private float resetCounter;
    private float pauseCounter;
    private bool hasFallen = false;
    private bool isPaused = false;

    private void Start()
    {
        resetCounter = resetTime;
        startPos = transform.position;
        startRot = transform.rotation.eulerAngles;
        rb = GetComponent<Rigidbody>();
        rb.isKinematic = true;
        rb.useGravity = false;
    }

    private void Update()
    {
        if (pauseCounter >= 0)
        {
            pauseCounter -= Time.deltaTime;
        }
        else
        {
            isPaused = false;
        }

        if (!hasFallen)
        {
            return;
        }

        if (resetCounter <= 0)
        {
            hasFallen = false;
            transform.position = startPos;
            transform.rotation = Quaternion.Euler(startRot);
            rb.isKinematic = true;
            rb.useGravity = false;
            resetCounter = resetTime;
            isPaused = true;
            pauseCounter = pauseTime;
        }
        else
        {
            resetCounter -= Time.deltaTime;
        }
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" || other.tag == "PlayerChassis")
        {
            hasFallen = true;
            rb.isKinematic = false;
            rb.useGravity = true;
        }

        if (other.tag == "Tree" && !isPaused)
        {
            hasFallen = true;
            rb.isKinematic = false;
            rb.useGravity = true;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        var tag = collision.transform.tag;
        if (tag == "Player" || tag == "PlayerChassis")
        {
            hasFallen = true;
            rb.isKinematic = false;
            rb.useGravity = true;
        }

        if (tag == "Tree" && !isPaused)
        {
            hasFallen = true;
            rb.isKinematic = false;
            rb.useGravity = true;
        }
    }
}
