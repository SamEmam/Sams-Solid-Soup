using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SSGoal : MonoBehaviour
{
    public GoalEnum goal;
    public SceneLoader sceneLoader;
    public GameObject Explosion;
    public Transform ball;
    private int rewardScore;
    private bool hasBeenAwarded = false;
    private float shortGameTime = 45f;

    private void Start()
    {
        rewardScore = 0;
        if (GamePrefs.Player1)
        {
            rewardScore++;
        }
        if (GamePrefs.Player2)
        {
            rewardScore++;
        }
        if (GamePrefs.Player3)
        {
            rewardScore++;
        }
        if (GamePrefs.Player4)
        {
            rewardScore++;
        }
        if (GamePrefs.Player5)
        {
            rewardScore++;
        }
        if (GamePrefs.Player6)
        {
            rewardScore++;
        }
        if (GamePrefs.Player7)
        {
            rewardScore++;
        }
        if (GamePrefs.Player8)
        {
            rewardScore++;
        }
    }

    private void Update()
    {
        shortGameTime -= Time.deltaTime;
    }

    private void OnTriggerEnter(Collider other)
    {

        if (hasBeenAwarded)
        {
            return;
        }
        if (other.tag == "Objective")
        {
            hasBeenAwarded = true;
            Instantiate(Explosion, transform.position + (Vector3.down * 4), transform.rotation);
            Rigidbody ballRB = other.GetComponent<Rigidbody>();
            AwardPoints(goal);
            if (shortGameTime <= 0)
            {
                ballRB.drag = 1;
                StartCoroutine(EndGame());
            }
            else
            {
                RespawnAll();
                ball.position = new Vector3(0, 3, 0);
                ballRB.velocity = Vector3.zero;
                ballRB.angularVelocity = Vector3.zero;
                hasBeenAwarded = false;
            }
        }
    }

    void AwardPoints(GoalEnum team)
    {
        if (team == GoalEnum.team1)
        {
            if (GamePrefs.Player2)
            {
                GamePrefs.Player2Score += rewardScore / 2;
            }
            if (GamePrefs.Player4)
            {
                GamePrefs.Player4Score += rewardScore / 2;
            }
            if (GamePrefs.Player6)
            {
                GamePrefs.Player6Score += rewardScore / 2;
            }
            if (GamePrefs.Player8)
            {
                GamePrefs.Player8Score += rewardScore / 2;
            }
        }
        else
        {
            if (GamePrefs.Player1)
            {
                GamePrefs.Player1Score += rewardScore / 2;
            }
            if (GamePrefs.Player3)
            {
                GamePrefs.Player3Score += rewardScore / 2;
            }
            if (GamePrefs.Player5)
            {
                GamePrefs.Player5Score += rewardScore / 2;
            }
            if (GamePrefs.Player7)
            {
                GamePrefs.Player7Score += rewardScore / 2;
            }
        }
    }

    IEnumerator EndGame()
    {
        yield return new WaitForSeconds(5f);
        sceneLoader.LoadSceneByIndex(4);
    }

    void RespawnAll()
    {
        SRacePlayerCheckpoint[] CPs = FindObjectsOfType<SRacePlayerCheckpoint>();

        foreach (var cp in CPs)
        {
            cp.Respawn();
        }
    }
}

public enum GoalEnum
{
    team1,
    team2
}
