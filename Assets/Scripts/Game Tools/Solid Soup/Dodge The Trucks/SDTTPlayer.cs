using Rewired;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SDTTPlayer : MonoBehaviour
{
    [Header("Attributes")]
    public float speed = 50f;
    public float mapWidth = 30f;
    public bool isRewarded = false;


    [Header("Setup")]
    public int playerNum;
    public Player player;
    public SDTTGameMaster GM;
    public SkinnedMeshRenderer mesh;
    public Material[] materials;
    private Rigidbody rb;

    private void OnEnable()
    {
        GM.playersLeft++;
        SetupPlayerColor(playerNum);
        rb = GetComponent<Rigidbody>();
        player = ReInput.players.GetPlayer(playerNum);
    }
    

    private void FixedUpdate()
    {
        float x = player.GetAxis("Turn") * Time.fixedDeltaTime * speed;

        Vector3 newPosition = rb.position + Vector3.left * x;

        newPosition.x = Mathf.Clamp(newPosition.x, -mapWidth, mapWidth);
        rb.MovePosition(newPosition);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Vehicle")
        {
            if (isRewarded)
            {
                return;
            }

            isRewarded = true;
            RewardPlayer(playerNum);
            rb.constraints = RigidbodyConstraints.None;
            rb.useGravity = true;
        }
    }

    public void RewardPlayer(int player)
    {
        switch (player)
        {
            case 1:
                GamePrefs.Player1Score += GM.rewardScore;
                break;
            case 2:
                GamePrefs.Player2Score += GM.rewardScore;
                break;
            case 3:
                GamePrefs.Player3Score += GM.rewardScore;
                break;
            case 4:
                GamePrefs.Player4Score += GM.rewardScore;
                break;
            case 5:
                GamePrefs.Player5Score += GM.rewardScore;
                break;
            case 6:
                GamePrefs.Player6Score += GM.rewardScore;
                break;
            case 7:
                GamePrefs.Player7Score += GM.rewardScore;
                break;
            case 8:
                GamePrefs.Player8Score += GM.rewardScore;
                break;
        }

        GM.rewardScore++;
        GM.playersLeft--;
    }

    void SetupPlayerColor(int player)
    {
        switch (player)
        {
            case 1:
                mesh.material = materials[(int)GamePrefs.P1Color];
                break;
            case 2:
                mesh.material = materials[(int)GamePrefs.P2Color];
                break;
            case 3:
                mesh.material = materials[(int)GamePrefs.P3Color];
                break;
            case 4:
                mesh.material = materials[(int)GamePrefs.P4Color];
                break;
            case 5:
                mesh.material = materials[(int)GamePrefs.P5Color];
                break;
            case 6:
                mesh.material = materials[(int)GamePrefs.P6Color];
                break;
            case 7:
                mesh.material = materials[(int)GamePrefs.P7Color];
                break;
            case 8:
                mesh.material = materials[(int)GamePrefs.P8Color];
                break;

        }
    }


}
