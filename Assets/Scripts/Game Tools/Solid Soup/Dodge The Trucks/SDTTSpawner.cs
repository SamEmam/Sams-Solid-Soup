using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SDTTSpawner : MonoBehaviour
{
    public GameObject[] spawns;
    public float spawnStartSpeed;
    public float speedIncrement;
    public float counter;

    private Vector3 spawnPos;

    public int xOffset;
    public int yOffset;
    public int zOffset;

    private void Start()
    {
        counter = spawnStartSpeed;
    }

    private void Update()
    {
        if (counter <= 0)
        {
            SetSpawnPos();
            Instantiate(SelectSpawn(), spawnPos, transform.rotation);
            if (spawnStartSpeed > 1.2f)
            {
                spawnStartSpeed -= speedIncrement;
            }
            counter = spawnStartSpeed;
        }

        counter -= Time.deltaTime;
        

    }

    GameObject SelectSpawn()
    {
        return spawns[Random.Range(0, spawns.Length - 1)];
    }

    void SetSpawnPos()
    {
        spawnPos = Vector3.zero;
        spawnPos.x = Random.Range(-xOffset, xOffset);
        spawnPos.y = Random.Range(-yOffset, yOffset);
        spawnPos.z = Random.Range(-zOffset, zOffset);
        spawnPos += transform.position;
    } 

}
