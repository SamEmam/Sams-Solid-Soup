using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RWaterForce : MonoBehaviour
{
    public Transform direction;
    private float force = 0.08f;

    private void OnTriggerStay(Collider other)
    {
        Rigidbody rb = other.GetComponent<Rigidbody>();

        if (rb && other.tag == "Player")
        {
            rb.AddForce(direction.rotation.eulerAngles * force, ForceMode.Acceleration);
        }
    }
}
