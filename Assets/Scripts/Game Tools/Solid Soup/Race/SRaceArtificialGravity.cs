﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SRaceArtificialGravity : MonoBehaviour
{
    private float gravity;
    private Rigidbody rb;
    [HideInInspector]
    public float maxGravity = 1.6f;
    [HideInInspector]
    public float reverseGravity = 0f;
    

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.useGravity = false;
    }

    private void FixedUpdate()
    {
        gravity = rb.velocity.magnitude / 50;
        if (gravity < 0.1f)
        {
            gravity = 0.1f;
        }
        if (gravity > maxGravity)
        {
            gravity = maxGravity;
        }
        rb.AddForce(transform.up * -gravity, ForceMode.VelocityChange);
        rb.AddForce(transform.forward * -reverseGravity, ForceMode.Acceleration);
    }
}
