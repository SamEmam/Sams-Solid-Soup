using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SERTreeTipper : MonoBehaviour
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
        rb = GetComponent<Rigidbody>();
        startPos = transform.position;
        startRot = transform.rotation.eulerAngles;
        rb.freezeRotation = true;
        rb.isKinematic = false;
        rb.useGravity = true;
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
            if (rb.velocity.magnitude >= 5)
            {
                EnableFall();
            }
            return;
        }

        if (resetCounter <= 0)
        {
            hasFallen = false;
            transform.position = startPos;
            transform.rotation = Quaternion.Euler(startRot);
            rb.freezeRotation = true;
            resetCounter = resetTime;
            isPaused = true;
            pauseCounter = pauseTime;
        }
        else
        {
            resetCounter -= Time.deltaTime;
        }

    }

    private void OnCollisionEnter(Collision collision)
    {
        var tag = collision.transform.tag;
        if (tag == "Player" || tag == "PlayerChassis")
        {
            EnableFall();
        }

        if (tag == "Tree" && !isPaused)
        {
            EnableFall();
        }
    }

    void EnableFall()
    {

        hasFallen = true;
        rb.freezeRotation = false;
    }
}
