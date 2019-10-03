using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SRaceDebrisSpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject debris;
    [SerializeField]
    private bool spawnOnDisable = false;
    private RVehicleTypeSelector typeSelector;
    private Rigidbody parentRB;

    private void Start()
    {
        typeSelector = GetComponentInParent<RVehicleTypeSelector>();
        parentRB = GetComponent<Rigidbody>();
    }

    private void OnDisable()
    {
        if (spawnOnDisable)
        {
            SpawnDebris();
        }
    }

    public void SpawnDebris()
    {
        GameObject spawn = Instantiate(debris, transform.position, transform.rotation);
        spawn.GetComponent<RVehicleColorSelector>().typeSelector = typeSelector;
        Rigidbody spawnRB = spawn.GetComponent<Rigidbody>();
        spawnRB.velocity = parentRB.velocity;
        spawnRB.angularVelocity = parentRB.angularVelocity;
    }
}
