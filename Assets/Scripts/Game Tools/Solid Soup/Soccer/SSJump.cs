using Rewired;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SSJump : MonoBehaviour
{
    private float cooldown = 2f;
    private float counter;
    private float jumpStrength = 10f;
    private float forwardStrength = 3f;
    private float torque = 3f;

    private Rigidbody rb;
    private int playerNum;
    public Player player;
    

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        playerNum = GetComponent<RPlayerScore>().playerNum;
        player = ReInput.players.GetPlayer(playerNum);
    }

    private void Update()
    {

        if (counter > 0f)
        {
            counter -= Time.deltaTime;
            Turn();
            return;
        }
        
        if (player.GetButtonDown("Shoot"))
        {
            Jump();
        }
    }

    void Jump()
    {
        if (player.GetAxis("Brake") < 0)
        {
            rb.AddForce(Vector3.up * jumpStrength + (transform.forward * -1) * forwardStrength, ForceMode.VelocityChange);
        }
        else
        {
            rb.AddForce(Vector3.up * jumpStrength + transform.forward * forwardStrength, ForceMode.VelocityChange);
        }
        counter = cooldown;
    }

    void Turn()
    {
        var turn = player.GetAxis("Turn");
        Debug.Log(turn);
        rb.AddTorque(transform.up * torque * turn, ForceMode.Acceleration);
    }

}
