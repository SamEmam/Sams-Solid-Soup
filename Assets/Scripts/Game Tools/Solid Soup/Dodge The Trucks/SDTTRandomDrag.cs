using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SDTTRandomDrag : MonoBehaviour
{
    private float minDrag = 0.5f, maxDrag = 1f;

    private void OnEnable()
    {
        Rigidbody rb = GetComponent<Rigidbody>();
        rb.drag = Random.Range(minDrag, maxDrag);
    }
}
