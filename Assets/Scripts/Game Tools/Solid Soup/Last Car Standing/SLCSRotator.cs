using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SLCSRotator : MonoBehaviour
{
    private float rotSpeed = -5f;

    private void Update()
    {
        transform.Rotate(Vector3.up * rotSpeed * Time.deltaTime);
    }
}
