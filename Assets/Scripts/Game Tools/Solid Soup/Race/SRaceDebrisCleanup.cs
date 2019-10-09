using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SRaceDebrisCleanup : MonoBehaviour
{
    private float destroyTime = 20f;

    private void Start()
    {
        Destroy(gameObject, destroyTime);
    }
}
