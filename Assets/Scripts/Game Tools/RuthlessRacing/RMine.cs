using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RMine : MonoBehaviour
{
    [Header("Attributes")]
    public float impactForce;
    public float radius = 50f;
    public float upwardsThrust = 5f;

    private float delay = 2f;
    public bool isShot = false;

    [Header("Setup")]
    public ParticleSystem explosion;

    private void Update()
    {
        if (!isShot)
        {
            return;
        }

        if (delay > 0)
        {
            delay -= Time.deltaTime;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (delay > 0)
        {
            return;
        }
        if (collision.gameObject.tag == "Player")
        {
            Collider[] colliders = Physics.OverlapSphere(transform.position, radius);
            foreach (Collider hit in colliders)
            {
                Rigidbody hitRB = hit.GetComponent<Rigidbody>();
                if (hitRB != null /* && !hit.GetComponent<WNotAffected>()*/)
                {
                    hitRB.AddExplosionForce(impactForce, transform.position, radius, upwardsThrust, ForceMode.VelocityChange);
                }
            }
            Instantiate(explosion, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }
}
