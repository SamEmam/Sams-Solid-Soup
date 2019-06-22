using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RAudioListenerController : MonoBehaviour
{
    public Transform p1, p2, p3, p4, p5, p6, p7, p8;
    private float speed = 2f;

    // Update is called once per frame
    void Update()
    {
        Vector3 tempPos = Vector3.zero;
        float count = 0f;
        if (p1 && p1.gameObject.activeSelf)
        {
            tempPos += p1.position;
            count++;
        }
        if (p2 && p2.gameObject.activeSelf)
        {
            tempPos += p2.position;
            count++;
        }
        if (p3 && p3.gameObject.activeSelf)
        {
            tempPos += p3.position;
            count++;
        }
        if (p4 && p4.gameObject.activeSelf)
        {
            tempPos += p4.position;
            count++;
        }
        if (p5 && p5.gameObject.activeSelf)
        {
            tempPos += p5.position;
            count++;
        }
        if (p6 && p6.gameObject.activeSelf)
        {
            tempPos += p6.position;
            count++;
        }
        if (p7 && p7.gameObject.activeSelf)
        {
            tempPos += p7.position;
            count++;
        }
        if (p8 && p8.gameObject.activeSelf)
        {
            tempPos += p8.position;
            count++;
        }
        if (tempPos != Vector3.zero)
        {
            tempPos /= count;
        }
        transform.position = Vector3.Lerp(transform.position, tempPos, speed * Time.deltaTime);
    }
}
