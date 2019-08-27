using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SERTrafficRandomizer : MonoBehaviour
{
    public GameObject[] vehicles;

    private void Start()
    {
        foreach (var car in vehicles)
        {
            car.SetActive(false);
        }

        int rng = Random.Range(0, vehicles.Length - 1);

        vehicles[rng].SetActive(true);
    }
}
