using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SDTTMovingBackground : MonoBehaviour
{
    private int moveSpeed = 20;
    public Transform spawnPos;

    private void Update()
    {
        if (transform.localPosition.y >= 28)
        {
            transform.position = spawnPos.position;
        }

        transform.localPosition = new Vector3(transform.localPosition.x, transform.localPosition.y + (moveSpeed * Time.deltaTime), transform.localPosition.z);

        //transform.Translate(transform.up * moveSpeed * Time.deltaTime);
    }
}
