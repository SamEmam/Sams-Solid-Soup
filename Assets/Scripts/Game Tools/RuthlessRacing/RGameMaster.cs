using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RGameMaster : MonoBehaviour
{
    [Header("Preferences")]
    [SerializeField]
    private Transform spawnPoint;
    [SerializeField]
    private int winScore;
    private int winScoreHalf;
    private int winScoreDouble;
    [SerializeField]
    private bool masterDestroyer = false;

    [Header("Setup")]
    [SerializeField]
    private SceneLoader sceneLoader;
    [SerializeField]
    private RGameMaster otherGM;
    [SerializeField]
    private Text message;
    [SerializeField]
    private RAudioListenerController audioLC;
    [SerializeField]
    private RPointsBar p1Bar, p2Bar, p3Bar, p4Bar, p5Bar, p6Bar, p7Bar, p8Bar;

    [Header("Vehicle Setup")]
    [SerializeField]
    private int playersLeft;
    private int totalPlayers;
    [SerializeField]
    private GameObject p1, p2, p3, p4, p5, p6, p7, p8;
    private RPlayerPowerup p1Power, p2Power, p3Power, p4Power, p5Power, p6Power, p7Power, p8Power;
    private RPlayerScore p1Score, p2Score, p3Score, p4Score, p5Score, p6Score, p7Score, p8Score;

    private bool p1Alive, p2Alive, p3Alive, p4Alive, p5Alive, p6Alive, p7Alive, p8Alive;
    private bool hasUpdatedScore = false;
    private bool updateCooldown = true;

    private List<Vector3> spawnPositions;

    private int rewardValue;
    private int roundsPlayed;

    private void Awake()
    {
        winScoreHalf = winScore / 2;
        winScoreDouble = winScore * 2;
        if (!masterDestroyer)
        {
            return;
        }

        AwakePlayer(p1, p1Score, p1Power, p1Alive);
        AwakePlayer(p2, p2Score, p2Power, p2Alive);
        AwakePlayer(p3, p3Score, p3Power, p3Alive);
        AwakePlayer(p4, p4Score, p4Power, p4Alive);
        AwakePlayer(p5, p5Score, p5Power, p5Alive);
        AwakePlayer(p6, p6Score, p6Power, p6Alive);
        AwakePlayer(p7, p7Score, p7Power, p7Alive);
        AwakePlayer(p8, p8Score, p8Power, p8Alive);

        //if (GamePrefs.Player1 ) // CHANGE THIS to if player vehicle is enabled, and enable vehicle in different script
        //{
        //    // vehicle references are set in other scripts in OnEnable with a switch case to choose vehicle
        //    // AudioLC needs transforms of player vehicles
        //}

        ResetPlayers();
        SetRewardValue();

        StartCoroutine(Cooldown());
    }

    private void Update()
    {
        if (!masterDestroyer)
        {
            return;
        }
        if (hasUpdatedScore || updateCooldown)
        {
            return;
        }

        EndGameCheck();
        
    }

    void EndGameCheck()
    {
        if (playersLeft <= 1)
        {
            updateCooldown = true;
            roundsPlayed++;
            RewardLastPlayerAlive();
            if (CheckForWinner() > 0)
            {
                hasUpdatedScore = true;
                otherGM.hasUpdatedScore = true;
                RewardWinner(CheckForWinner());
                StartCoroutine(EndGame());
            }
            else
            {
                playersLeft = 0;
                otherGM.playersLeft = 0;
                Respawn();
                ResetPowerups();
                ResetPlayers();
                SetRewardValue();
                StartCoroutine(Cooldown());
            }
        }
    }

    void AwakePlayer(GameObject player, RPlayerScore score, RPlayerPowerup power, bool alive)
    {
        if (player.activeInHierarchy)
        {
            score = player.GetComponent<RPlayerScore>();
            power = player.GetComponent<RPlayerPowerup>();
            alive = true;
            totalPlayers++;
        }
    }

    IEnumerator Cooldown()
    {
        if (playersLeft < 3)
        {
            winScore = winScoreHalf;
        }

        if (playersLeft > 4)
        {
            winScore = winScoreDouble;
        }
        yield return new WaitForSeconds(2);

        updateCooldown = false;
    }

    IEnumerator EndGame()
    {
        yield return new WaitForSeconds(3);
        sceneLoader.LoadSceneByIndex(0); // CHANGE TO score scene
    }

    public RPlayerScore GetPlayerScore(int playerNum)
    {
        switch (playerNum)
        {
            case 1:
                return p1Score;
            case 2:
                return p2Score;
            case 3:
                return p3Score;
            case 4:
                return p4Score;
            case 5:
                return p5Score;
            case 6:
                return p6Score;
            case 7:
                return p7Score;
            case 8:
                return p8Score;
            default:
                return new RPlayerScore();
        }
    }

    void RewardWinner(int playerNum)
    {
        switch (playerNum)
        {
            case 1:
                GamePrefs.Player1Score++;
                message.text += "P1 WINS!";
                break;
            case 2:
                GamePrefs.Player1Score++;
                message.text += "P2 WINS!";
                break;
            case 3:
                GamePrefs.Player1Score++;
                message.text += "P3 WINS!";
                break;
            case 4:
                GamePrefs.Player1Score++;
                message.text += "P4 WINS!";
                break;
            case 5:
                GamePrefs.Player1Score++;
                message.text += "P5 WINS!";
                break;
            case 6:
                GamePrefs.Player1Score++;
                message.text += "P6 WINS!";
                break;
            case 7:
                GamePrefs.Player1Score++;
                message.text += "P7 WINS!";
                break;
            case 8:
                GamePrefs.Player1Score++;
                message.text += "P8 WINS!";
                break;

        }
    }

    int CheckForWinner()
    {
        if (p1Score && p1Score.score >= winScore)
        {
            return p1Score.playerNum;
        }
        else if (p2Score && p2Score.score >= winScore)
        {
            return p2Score.playerNum;
        }
        else if (p3Score && p3Score.score >= winScore)
        {
            return p3Score.playerNum;
        }
        else if (p4Score && p4Score.score >= winScore)
        {
            return p4Score.playerNum;
        }
        else if (p5Score && p5Score.score >= winScore)
        {
            return p5Score.playerNum;
        }
        else if (p6Score && p6Score.score >= winScore)
        {
            return p6Score.playerNum;
        }
        else if (p7Score && p7Score.score >= winScore)
        {
            return p7Score.playerNum;
        }
        else if (p8Score && p8Score.score >= winScore)
        {
            return p8Score.playerNum;
        }
        else
        {
            return 0;
        }
    }

    void RewardLastPlayerAlive()
    {
        if (p1Alive)
        {
            UpdateScore(p1Score);
        }
        else if (p2Alive)
        {
            UpdateScore(p2Score);
        }
        else if (p3Alive)
        {
            UpdateScore(p3Score);
        }
        else if (p4Alive)
        {
            UpdateScore(p4Score);
        }
        else if (p5Alive)
        {
            UpdateScore(p5Score);
        }
        else if (p6Alive)
        {
            UpdateScore(p6Score);
        }
        else if (p7Alive)
        {
            UpdateScore(p7Score);
        }
        else if (p8Alive)
        {
            UpdateScore(p8Score);
        }
    }

    void ResetPlayers()
    {
        if (GamePrefs.Player1)
        {
            p1.SetActive(true);
            playersLeft++;
            p1Alive = true;
        }
        if (GamePrefs.Player2)
        {
            p2.SetActive(true);
            playersLeft++;
            p2Alive = true;
        }
        if (GamePrefs.Player3)
        {
            p3.SetActive(true);
            playersLeft++;
            p3Alive = true;
        }
        if (GamePrefs.Player4)
        {
            p4.SetActive(true);
            playersLeft++;
            p4Alive = true;
        }
        if (GamePrefs.Player5)
        {
            p5.SetActive(true);
            playersLeft++;
            p5Alive = true;
        }
        if (GamePrefs.Player6)
        {
            p6.SetActive(true);
            playersLeft++;
            p6Alive = true;
        }
        if (GamePrefs.Player7)
        {
            p7.SetActive(true);
            playersLeft++;
            p7Alive = true;
        }
        if (GamePrefs.Player8)
        {
            p8.SetActive(true);
            playersLeft++;
            p8Alive = true;
        }
        otherGM.playersLeft = playersLeft;
    }

    void SetRewardValue()
    {
        switch (playersLeft)
        {
            case 1:
                rewardValue = 1;
                break;
            case 2:
                rewardValue = -1;
                break;
            case 3:
                rewardValue = -1;
                break;
            case 4:
                rewardValue = -2;
                break;
            case 5:
                rewardValue = -2;
                break;
            case 6:
                rewardValue = -3;
                break;
            case 7:
                rewardValue = -3;
                break;
            case 8:
                rewardValue = -3;
                break;
        }
        if (GamePrefs.GameTime <= 0)
        {
            rewardValue++;
        }
        otherGM.rewardValue = rewardValue;
    }

    void UpdateScore(RPlayerScore score)
    {
        if (rewardValue == 0)
        {
            rewardValue++;
        }
        score.score += rewardValue;
        if (score.score < 0)
        {
            score.score = 0;
        }
        rewardValue++;
        otherGM.rewardValue = rewardValue;
    }

    void ResetPowerups()
    {
        if (GamePrefs.Player1)
        {
            p1Power.DisableAll();
        }
        if (GamePrefs.Player2)
        {
            p2Power.DisableAll();
        }
        if (GamePrefs.Player3)
        {
            p3Power.DisableAll();
        }
        if (GamePrefs.Player4)
        {
            p4Power.DisableAll();
        }
        if (GamePrefs.Player5)
        {
            p5Power.DisableAll();
        }
        if (GamePrefs.Player6)
        {
            p6Power.DisableAll();
        }
        if (GamePrefs.Player7)
        {
            p7Power.DisableAll();
        }
        if (GamePrefs.Player8)
        {
            p8Power.DisableAll();
        }
    }

    void Respawn()
    {
        spawnPositions = new List<Vector3>();
        switch (totalPlayers)
        {
            case 1:
                spawnPositions.Add(spawnPoint.position + (spawnPoint.forward * -2) + (spawnPoint.right * -2));
                break;
            case 2:
                spawnPositions.Add(spawnPoint.position + (spawnPoint.forward * -2) + (spawnPoint.right * -2));
                spawnPositions.Add(spawnPoint.position + (spawnPoint.forward * -2) + (spawnPoint.right * 2));
                break;
            case 3:
                spawnPositions.Add(spawnPoint.position + (spawnPoint.forward * -2) + (spawnPoint.right * -2));
                spawnPositions.Add(spawnPoint.position + (spawnPoint.forward * -2) + (spawnPoint.right * 2));
                spawnPositions.Add(spawnPoint.position + (spawnPoint.forward * -10) + (spawnPoint.right * -2));
                break;
            case 4:
                spawnPositions.Add(spawnPoint.position + (spawnPoint.forward * -2) + (spawnPoint.right * -2));
                spawnPositions.Add(spawnPoint.position + (spawnPoint.forward * -2) + (spawnPoint.right * 2));
                spawnPositions.Add(spawnPoint.position + (spawnPoint.forward * -10) + (spawnPoint.right * -2));
                spawnPositions.Add(spawnPoint.position + (spawnPoint.forward * -10) + (spawnPoint.right * 2));
                break;
            case 5:
                spawnPositions.Add(spawnPoint.position + (spawnPoint.forward * -2) + (spawnPoint.right * -2));
                spawnPositions.Add(spawnPoint.position + (spawnPoint.forward * -2) + (spawnPoint.right * 2));
                spawnPositions.Add(spawnPoint.position + (spawnPoint.forward * -10) + (spawnPoint.right * -2));
                spawnPositions.Add(spawnPoint.position + (spawnPoint.forward * -10) + (spawnPoint.right * 2));
                spawnPositions.Add(spawnPoint.position + (spawnPoint.forward * -18) + (spawnPoint.right * -2));
                break;
            case 6:
                spawnPositions.Add(spawnPoint.position + (spawnPoint.forward * -2) + (spawnPoint.right * -2));
                spawnPositions.Add(spawnPoint.position + (spawnPoint.forward * -2) + (spawnPoint.right * 2));
                spawnPositions.Add(spawnPoint.position + (spawnPoint.forward * -10) + (spawnPoint.right * -2));
                spawnPositions.Add(spawnPoint.position + (spawnPoint.forward * -10) + (spawnPoint.right * 2));
                spawnPositions.Add(spawnPoint.position + (spawnPoint.forward * -18) + (spawnPoint.right * -2));
                spawnPositions.Add(spawnPoint.position + (spawnPoint.forward * -18) + (spawnPoint.right * 2));
                break;
            case 7:
                spawnPositions.Add(spawnPoint.position + (spawnPoint.forward * -2) + (spawnPoint.right * -2));
                spawnPositions.Add(spawnPoint.position + (spawnPoint.forward * -2) + (spawnPoint.right * 2));
                spawnPositions.Add(spawnPoint.position + (spawnPoint.forward * -10) + (spawnPoint.right * -2));
                spawnPositions.Add(spawnPoint.position + (spawnPoint.forward * -10) + (spawnPoint.right * 2));
                spawnPositions.Add(spawnPoint.position + (spawnPoint.forward * -18) + (spawnPoint.right * -2));
                spawnPositions.Add(spawnPoint.position + (spawnPoint.forward * -18) + (spawnPoint.right * 2));
                spawnPositions.Add(spawnPoint.position + (spawnPoint.forward * -26) + (spawnPoint.right * -2));
                break;
            case 8:
                spawnPositions.Add(spawnPoint.position + (spawnPoint.forward * -2) + (spawnPoint.right * -2));
                spawnPositions.Add(spawnPoint.position + (spawnPoint.forward * -2) + (spawnPoint.right * 2));
                spawnPositions.Add(spawnPoint.position + (spawnPoint.forward * -10) + (spawnPoint.right * -2));
                spawnPositions.Add(spawnPoint.position + (spawnPoint.forward * -10) + (spawnPoint.right * 2));
                spawnPositions.Add(spawnPoint.position + (spawnPoint.forward * -18) + (spawnPoint.right * -2));
                spawnPositions.Add(spawnPoint.position + (spawnPoint.forward * -18) + (spawnPoint.right * 2));
                spawnPositions.Add(spawnPoint.position + (spawnPoint.forward * -26) + (spawnPoint.right * -2));
                spawnPositions.Add(spawnPoint.position + (spawnPoint.forward * -26) + (spawnPoint.right * 2));
                break;
            default:
                spawnPositions.Add(spawnPoint.position + (spawnPoint.forward * -2) + (spawnPoint.right * -2));
                spawnPositions.Add(spawnPoint.position + (spawnPoint.forward * -2) + (spawnPoint.right * 2));
                spawnPositions.Add(spawnPoint.position + (spawnPoint.forward * -10) + (spawnPoint.right * -2));
                spawnPositions.Add(spawnPoint.position + (spawnPoint.forward * -10) + (spawnPoint.right * 2));
                spawnPositions.Add(spawnPoint.position + (spawnPoint.forward * -18) + (spawnPoint.right * -2));
                spawnPositions.Add(spawnPoint.position + (spawnPoint.forward * -18) + (spawnPoint.right * 2));
                spawnPositions.Add(spawnPoint.position + (spawnPoint.forward * -26) + (spawnPoint.right * -2));
                spawnPositions.Add(spawnPoint.position + (spawnPoint.forward * -26) + (spawnPoint.right * 2));
                break;
        }

        for (int i = 0; i < spawnPositions.Count; i++)
        {
            Vector3 temp = spawnPositions[i];
            int randomIndex = Random.Range(i, spawnPositions.Count);
            spawnPositions[i] = spawnPositions[randomIndex];
            spawnPositions[randomIndex] = temp;
        }

        if (GamePrefs.Player1)
        {
            p1.transform.position = spawnPositions[0];
            p1.transform.rotation = spawnPoint.rotation;
            var p1RB = p1.GetComponent<Rigidbody>();
            p1RB.velocity = Vector3.zero;
            p1RB.angularVelocity = Vector3.zero;
        }
        if (GamePrefs.Player2)
        {
            p2.transform.position = spawnPositions[1];
            p2.transform.rotation = spawnPoint.rotation;
            var p2RB = p2.GetComponent<Rigidbody>();
            p2RB.velocity = Vector3.zero;
            p2RB.angularVelocity = Vector3.zero;
        }
        if (GamePrefs.Player3)
        {
            p3.transform.position = spawnPositions[2];
            p3.transform.rotation = spawnPoint.rotation;
            var p3RB = p3.GetComponent<Rigidbody>();
            p3RB.velocity = Vector3.zero;
            p3RB.angularVelocity = Vector3.zero;
        }
        if (GamePrefs.Player4)
        {
            p4.transform.position = spawnPositions[3];
            p4.transform.rotation = spawnPoint.rotation;
            var p4RB = p4.GetComponent<Rigidbody>();
            p4RB.velocity = Vector3.zero;
            p4RB.angularVelocity = Vector3.zero;
        }
        if (GamePrefs.Player5)
        {
            p5.transform.position = spawnPositions[4];
            p5.transform.rotation = spawnPoint.rotation;
            var p5RB = p5.GetComponent<Rigidbody>();
            p5RB.velocity = Vector3.zero;
            p5RB.angularVelocity = Vector3.zero;
        }
        if (GamePrefs.Player6)
        {
            p6.transform.position = spawnPositions[5];
            p6.transform.rotation = spawnPoint.rotation;
            var p6RB = p6.GetComponent<Rigidbody>();
            p6RB.velocity = Vector3.zero;
            p6RB.angularVelocity = Vector3.zero;
        }
        if (GamePrefs.Player7)
        {
            p7.transform.position = spawnPositions[6];
            p7.transform.rotation = spawnPoint.rotation;
            var p7RB = p7.GetComponent<Rigidbody>();
            p7RB.velocity = Vector3.zero;
            p7RB.angularVelocity = Vector3.zero;
        }
        if (GamePrefs.Player8)
        {
            p8.transform.position = spawnPositions[7];
            p8.transform.rotation = spawnPoint.rotation;
            var p8RB = p8.GetComponent<Rigidbody>();
            p8RB.velocity = Vector3.zero;
            p8RB.angularVelocity = Vector3.zero;
        }
    }

    void UnAlivePlayer(RPlayerScore ps)
    {
        switch (ps.playerNum)
        {
            case 1:
                p1Alive = false;
                p1.SetActive(false);
                break;
            case 2:
                p2Alive = false;
                p2.SetActive(false);
                break;
            case 3:
                p3Alive = false;
                p3.SetActive(false);
                break;
            case 4:
                p4Alive = false;
                p4.SetActive(false);
                break;
            case 5:
                p5Alive = false;
                p5.SetActive(false);
                break;
            case 6:
                p6Alive = false;
                p6.SetActive(false);
                break;
            case 7:
                p7Alive = false;
                p7.SetActive(false);
                break;
            case 8:
                p8Alive = false;
                p8.SetActive(false);
                break;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (playersLeft > 1)
            {
                if (masterDestroyer)
                {
                    playersLeft--;
                    RPlayerScore ps = other.GetComponent<RPlayerScore>();
                    UpdateScore(ps);
                    UnAlivePlayer(ps);
                    otherGM.playersLeft = playersLeft;
                }
                else
                {
                    otherGM.playersLeft--;
                    RPlayerScore ps = other.GetComponent<RPlayerScore>();
                    otherGM.UpdateScore(ps);
                    otherGM.UnAlivePlayer(ps);
                    playersLeft = otherGM.playersLeft;
                }
            }
        }
    }







}
