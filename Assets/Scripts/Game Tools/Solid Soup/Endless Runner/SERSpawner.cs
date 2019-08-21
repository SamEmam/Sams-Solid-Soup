using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SERSpawner : MonoBehaviour
{
    [Header("Attributes")]
    public float distanceBeforeSpawn;
    public int blockSize;
    private bool canSpawnBlock = false;


    [Header("Setup")]
    public GameObject[] objs;
    [SerializeField]
    private RVehicleTypeSelector p1, p2, p3, p4, p5, p6, p7, p8;
    private List<Transform> players = new List<Transform>();


    private void Start()
    {
        if (p1.GetVehicle())
        {
            players.Add(p1.GetVehicle().transform);
        }
        if (p2.GetVehicle())
        {
            players.Add(p2.GetVehicle().transform);
        }
        if (p3.GetVehicle())
        {
            players.Add(p3.GetVehicle().transform);
        }
        if (p4.GetVehicle())
        {
            players.Add(p4.GetVehicle().transform);
        }
        if (p5.GetVehicle())
        {
            players.Add(p5.GetVehicle().transform);
        }
        if (p6.GetVehicle())
        {
            players.Add(p6.GetVehicle().transform);
        }
        if (p7.GetVehicle())
        {
            players.Add(p7.GetVehicle().transform);
        }
        if (p8.GetVehicle())
        {
            players.Add(p8.GetVehicle().transform);
        }
    }

    private void Update()
    {
        SpawnBlockCheck();
        if (canSpawnBlock)
        {
            InstantiateBlock();
        }
    }

    void SpawnBlockCheck()
    {
        foreach (var vehicle in players)
        {
            if (vehicle && Vector3.Distance(vehicle.position, transform.position) <= distanceBeforeSpawn)
            {
                canSpawnBlock = true;
            }
        }
    }

    void InstantiateBlock()
    {
        canSpawnBlock = false;
        Instantiate(objs[Random.Range(0, objs.GetLength(0))], transform.position, Quaternion.identity);
        transform.position = new Vector3(0, 0, transform.position.z + blockSize);
    }
}
