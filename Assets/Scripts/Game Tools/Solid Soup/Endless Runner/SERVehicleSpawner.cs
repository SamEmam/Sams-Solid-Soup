using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SERVehicleSpawner : MonoBehaviour
{
    public GameObject[] Lanes;
    public GameObject[] Vehicles;
    private int spawnChance = 10;
    private float spawnInterval = 0.35f;
    private float counter;
    private GameObject vehicle;
    private GameObject lane;

    private void Start()
    {
        counter = spawnInterval;
    }

    private void Update()
    {
        if (counter >= 0)
        {
            counter -= Time.deltaTime;
            return;
        }
        else
        {
            counter = spawnInterval;
        }

        if (Random.Range(0,100) <= spawnChance)
        {
            Debug.Log("Spawning..");
            Spawn();
        }
    }

    void Spawn()
    {
        Vector3 spawnOffset = new Vector3(Random.Range(-20, 20), 1, Random.Range(-20, 20));
        RandomVehicle();
        RandomLane();
        GameObject spawnedVehicle = Instantiate(vehicle, transform.position + spawnOffset, transform.rotation);
        GameObject spawnedPath = Instantiate(lane, lane.transform.position + transform.position, transform.rotation);
        spawnedVehicle.GetComponent<SRHTrafficEngine>().path = spawnedPath.transform;
        spawnChance += 1;
    }

    void RandomVehicle()
    {
        int rng = Random.Range(0, Vehicles.Length - 1);
        vehicle = Vehicles[rng];
    }

    void RandomLane()
    {
        int rng = Random.Range(0, Lanes.Length - 1);
        lane = Lanes[rng];
    }
}
