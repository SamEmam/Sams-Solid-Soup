using Rewired;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Vehicles.Car;

public class SRaceMotorBikeBalancer : MonoBehaviour
{
    private Rigidbody rb;
    private int playerNum;
    private Player player;
    private float leanFactor = 2f;
    private CarController controller;
    private float maxSteeringAngle = 20f;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        playerNum = GetComponent<RPlayerScore>().playerNum;
        player = ReInput.players.GetPlayer(playerNum);
        controller = GetComponent<CarController>();
    }

    private void Update()
    {
        float turn = -player.GetAxis("Turn");
        float speed = 3f;
        float steeringAngle = maxSteeringAngle - rb.velocity.magnitude / 2.5f;

        steeringAngle = Mathf.Clamp(steeringAngle, 4f, maxSteeringAngle);
        controller.m_MaximumSteerAngle = steeringAngle;



        Vector3 targetRotation = transform.rotation.eulerAngles;

        targetRotation.z = 0 + turn * leanFactor * rb.velocity.magnitude;

        targetRotation.z = Mathf.Clamp(targetRotation.z, -45, 45);

        Quaternion targetQuaternion = Quaternion.Euler(targetRotation);

        if (Mathf.Abs(turn) < 0.3f)
        {
            speed = 3f - targetRotation.z;
            speed = Mathf.Clamp(speed, 1f, 3f);
        }

        if (Mathf.Abs(turn) < 0.1f)
        {
            targetRotation.z = 0;
        }
        
        transform.rotation = Quaternion.Lerp(transform.rotation, targetQuaternion, Time.deltaTime * speed);
    }
}
