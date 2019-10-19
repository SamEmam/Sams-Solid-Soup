using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SRaceFinishLine : MonoBehaviour
{
    public int rewardScore;
    public int playersLeft;
    public int raceLaps;
    public int raceCheckpoints;
    public GameObject explosion;
    public GameObject explosionCP;

    public AudioClip cpClip, finishClip;
    private AudioSource source;
    private GameObject audioPlayer;

    private void Awake()
    {
        GetComponent<BoxCollider>().isTrigger = true;

        audioPlayer = new GameObject("CP Audio");
        audioPlayer.transform.SetParent(transform);
        source = audioPlayer.AddComponent<AudioSource>();
        source.clip = cpClip;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            RPlayerScore ps = other.GetComponent<RPlayerScore>();
            SRacePlayerCheckpoint cp = other.GetComponent<SRacePlayerCheckpoint>();

            if (!ps)
            {
                return;
            }

            if (cp.checkpointCount >= raceCheckpoints)
            {
                if (cp.laps < raceLaps - 1)
                {
                    cp.laps++;
                    cp.checkpointCount = 0;
                    cp.respawnPoint = transform;
                    Instantiate(explosionCP, transform.position + Vector3.down, transform.rotation);
                    if (cpClip)
                    {
                        source.clip = cpClip;
                        source.Play();
                    }
                    return;
                }

                //ps.score += rewardScore;
                RewardPlayer(ps.playerNum, rewardScore);
                rewardScore--;

                // Instantiate player ragdoll
                //if (other.GetComponent<SRaceDebrisSpawner>())
                //{
                //    other.GetComponent<SRaceDebrisSpawner>().SpawnDebris(other.transform, other.GetComponent<Rigidbody>(), other.GetComponent<RVehicleColorSelector>().typeSelector);
                //}

                Instantiate(explosion, transform.position + Vector3.down, transform.rotation);
                if (finishClip)
                {
                    source.clip = finishClip;
                    source.Play();
                }
                Destroy(other.gameObject);

                playersLeft--;
            }
        }
    }

    void RewardPlayer(int playerNum, int reward)
    {
        switch (playerNum)
        {
            case 1:
                GamePrefs.Player1Score += reward;
                break;
            case 2:
                GamePrefs.Player2Score += reward;
                break;
            case 3:
                GamePrefs.Player3Score += reward;
                break;
            case 4:
                GamePrefs.Player4Score += reward;
                break;
            case 5:
                GamePrefs.Player5Score += reward;
                break;
            case 6:
                GamePrefs.Player6Score += reward;
                break;
            case 7:
                GamePrefs.Player7Score += reward;
                break;
            case 8:
                GamePrefs.Player8Score += reward;
                break;
            default:
                break;
        }
    }
}
