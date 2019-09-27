using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SDTTMovingBackground : MonoBehaviour
{
    private int moveSpeed = 20;
    private float currentSpeed = 0;
    public Transform spawnPos;

    private void FixedUpdate()
    {
        if (currentSpeed < moveSpeed)
        {
            currentSpeed += Time.fixedDeltaTime * 2;
        }
        else
        {
            currentSpeed = moveSpeed;
        }

        if (transform.localPosition.y >= 26)
        {
            transform.position = spawnPos.position;
        }

        transform.localPosition = new Vector3(transform.localPosition.x, transform.localPosition.y + (currentSpeed * Time.fixedDeltaTime), transform.localPosition.z);
        
    }
}
