using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RMissile : MonoBehaviour
{
    [Header("Attributes")]
    public float delayBeforeActive = 2.5f;
    private float lifespan = 5f;
    private float impactForce = 1.5f;

    private float thrust = 25f;
    private float radius = 10f;
    private float upwardsThrust = 1.5f;
    private float rotationSpeed = 500f;
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
    private Vector3 startPos;
    private Vector3 startRot;

    // Start is called before the first frame update
    void Start()
    {
        emit = thrustParticle.emission;
        emit.enabled = false;
        thrustParticle.Clear();
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

        if (lifespan <= 0)
        {
            Explode();
        }
        else
        {
            lifespan -= Time.deltaTime;
        }

        // Rotate towards direction of travel
        //transform.rotation = Quaternion.LookRotation(rb.velocity);
    }

    IEnumerator StartDelay()
    {
        yield return new WaitForSeconds(delayBeforeActive);
        FindNearestTarget();
        emit.enabled = true;
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
        //rb.AddForce(transform.forward * thrust, ForceMode.Acceleration);
        transform.Translate(transform.forward * Time.deltaTime * thrust);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (!isActive)
        {
            return;
        }

        Explode();
        
    }

    void Explode()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, radius);
        foreach (Collider hit in colliders)
        {
            Rigidbody hitRB = hit.GetComponent<Rigidbody>();
            if (hitRB != null /*&& !hit.GetComponent<RNotAffected>()*/)
            {
                hitRB.AddExplosionForce(impactForce, transform.position, radius, upwardsThrust, ForceMode.VelocityChange);
            }
        }

        Instantiate(explosion, transform.position, transform.rotation);
        Destroy(gameObject);
    }
}
