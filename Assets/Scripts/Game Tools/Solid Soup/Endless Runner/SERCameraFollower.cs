using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SERCameraFollower : MonoBehaviour
{
    public Camera mainCam;

    private void Update()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y, mainCam.transform.position.z);
    }
}
