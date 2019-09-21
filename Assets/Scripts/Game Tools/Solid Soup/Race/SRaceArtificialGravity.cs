using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SRaceArtificialGravity : MonoBehaviour
{
    private float gravity;
    private Rigidbody rb;
    

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
        if (gravity > 1.6f)
        {
            gravity = 1.6f;
        }
        rb.AddForce(transform.up * -gravity, ForceMode.VelocityChange);
    }
}
