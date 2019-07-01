using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RMissile : MonoBehaviour
{
    [Header("Attributes")]
    public float delayBeforeActive = 2.5f;
    public float impactForce = 10f;

    private float thrust = 10f;
    private float radius = 10f;
    private float upwardsThrust = 10f;
    private float rotationSpeed = 750f;
    private float closestDistance = float.MaxValue;
    private bool missileEnabled = false;
    private bool isActive = false;

    [Header("Setup")]
    public GameObject parent;
    public Rigidbody rb;
    public ParticleSystem thrustParticle;
    public ParticleSystem explosion;
    private ParticleSystem.EmissionModule emit;
    private Transform closestTarget;

    // Start is called before the first frame update
    void Start()
    {
        emit = thrustParticle.emission;
    }

    // Update is called once per frame
    void Update()
    {
        if (TriggerMissileCheck())
        {
            return;
        }

        if (!missileEnabled)
        {
            missileEnabled = true;
            StartCoroutine(StartDelay());
        }

        if (isActive)
        {
            RotateTowardsTarget();
            MoveForward();
        }

        // Rotate towards direction of travel
        //transform.rotation = Quaternion.LookRotation(rb.velocity);
    }

    IEnumerator StartDelay()
    {
        yield return new WaitForSeconds(delayBeforeActive);
        FindNearestTarget();
        isActive = true;
    }

    bool TriggerMissileCheck()
    {
        if (transform.parent == null)
        {
            return false;
        }
        
        return true;
    }

    void FindNearestTarget()
    {
        GameObject[] GOs = GameObject.FindGameObjectsWithTag("Player");
        foreach (GameObject GO in GOs)
        {
            float dist = Vector3.Distance(GO.transform.position, transform.position);
            if (dist < closestDistance && GO != parent)
            {
                closestDistance = dist;
                closestTarget = GO.transform;
            }
        }
    }

    private void RotateTowardsTarget()
    {
        var direction = (closestTarget.position - transform.position).normalized;
        var lookRotation = Quaternion.LookRotation(direction);
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * rotationSpeed);
    }

    private void MoveForward()
    {
        rb.AddForce(transform.forward * thrust, ForceMode.Acceleration);
    }

    private void OnCollisionEnter(Collision collision)
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, radius);
        foreach (Collider hit in colliders)
        {
            Rigidbody hitRB = hit.GetComponent<Rigidbody>();
            if (hitRB != null /*&& !hit.GetComponent<RNotAffected>()*/)
            {
                hitRB.AddExplosionForce(impactForce, transform.position, radius, upwardsThrust, ForceMode.Acceleration);
            }
        }

        Instantiate(explosion, transform.position, transform.rotation);
        Destroy(gameObject, 3f);
    }
}
