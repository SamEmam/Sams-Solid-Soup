using Rewired;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SERDriverTiltManager : MonoBehaviour
{
    public int playerNum;
    public Player player;

    public Transform rightShoulder, leftShoulder;
    private float maxTilt = 15f;
    private Vector3 rightStartRot = new Vector3(0, 180, 270);
    private Vector3 leftStartRot = new Vector3(0, 180, 270);

    private void Start()
    {
        playerNum = GetComponent<RPlayerScore>().playerNum;
        player = ReInput.players.GetPlayer(playerNum);
    }

    private void Update()
    {
        rightShoulder.localEulerAngles = new Vector3(rightStartRot.x, rightStartRot.y, rightStartRot.z + (player.GetAxis("Turn") * maxTilt));
        leftShoulder.localEulerAngles = new Vector3(leftStartRot.x, leftStartRot.y, leftStartRot.z + (player.GetAxis("Turn") * maxTilt));
    }
}
