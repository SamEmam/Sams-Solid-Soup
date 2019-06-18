using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RCameraYawController : MonoBehaviour
{
    [SerializeField]
    private CameraMultiTarget camera;

    private void LateUpdate()
    {
        camera.Yaw = transform.rotation.eulerAngles.y;
    }
}
