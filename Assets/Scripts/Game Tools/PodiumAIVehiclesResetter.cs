using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Utility;

public class PodiumAIVehiclesResetter : MonoBehaviour
{
    private Transform target;
    private Rigidbody rb;
    private float counter = 3f;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        target = GetComponent<WaypointProgressTracker>().target;
    }

    private void Update()
    {
        if (counter <= 0)
        {
            ResetVehicle();
        }
        if (rb.velocity.magnitude < 0.2f)
        {
            counter -= Time.deltaTime;
        }
        else
        {
            counter = 3f;
        }
    }

    void ResetVehicle()
    {
        counter = 3f;
        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
        transform.position = target.position + (transform.right * -15);
        transform.rotation = target.rotation;
    }
}
