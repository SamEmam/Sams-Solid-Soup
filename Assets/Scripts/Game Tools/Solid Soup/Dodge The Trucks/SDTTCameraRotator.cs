using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SDTTCameraRotator : MonoBehaviour
{
    [SerializeField]
    private Transform cameraTransform;
    [SerializeField]
    private float timeToStart = .2f;
    private float timeAtStart;
    private float targetZRotation = 0;
    private float speed = .05f;

    // Start is called before the first frame update
    void Start()
    {
        timeAtStart = Time.time;
        timeToStart *= 60;
    }

    // Update is called once per frame
    void Update()
    {
        RotateCamera();
        if (Time.time >= timeAtStart + timeToStart)
        {
            SetNewRotation();
        }
    }

    void SetNewRotation()
    {
        targetZRotation = Random.Range(-180f, 180f);
        timeAtStart = Time.time;
        timeToStart = 15;
    }

    void RotateCamera()
    {
        cameraTransform.localRotation = Quaternion.Slerp(cameraTransform.localRotation, Quaternion.Euler(0, -180, targetZRotation), Time.deltaTime * speed);
    }


}
