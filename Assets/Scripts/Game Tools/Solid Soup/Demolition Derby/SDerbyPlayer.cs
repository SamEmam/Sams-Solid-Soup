using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SDerbyPlayer : MonoBehaviour
{
    private int health = 1000;
    [HideInInspector]
    public int points = 0;
    [HideInInspector]
    public int playerNum;
    [HideInInspector]
    public bool canTakeDMG = true;
    private SRacePlayerCheckpoint CP;
    private SDerbyMaster derbyMaster;
    [SerializeField]
    private GameObject debris;
    [SerializeField]
    private GameObject explosion;
    private Rigidbody debrisRB;
    private Rigidbody playerRB;

    private void Start()
    {
        playerNum = GetComponent<RPlayerScore>().playerNum;
        CP = GetComponent<SRacePlayerCheckpoint>();
        derbyMaster = FindObjectOfType<SDerbyMaster>();
        derbyMaster.players[playerNum] = this;
        debrisRB = debris.GetComponent<Rigidbody>();
        playerRB = GetComponent<Rigidbody>();
        debris.SetActive(false);
        debris.transform.SetParent(null);
    }

    void Die()
    {
        debris.transform.position = transform.position;
        debris.transform.rotation = transform.rotation;
        debris.SetActive(true);
        Instantiate(explosion, transform.position, transform.rotation);
        debrisRB.velocity = playerRB.velocity;
        debrisRB.angularVelocity = playerRB.angularVelocity;

        CP.Respawn();
        health = 1000;
    }

    public void TakeDamage(int dmg, int dmgGiverPlayerNum)
    {
        Debug.Log("DMG: " + dmg);
        if (!canTakeDMG)
        {
            return;
        }

        int rewardPoints = dmg;
        health -= dmg;

        if (health <= 0)
        {
            Die();
            rewardPoints += 1000;
            derbyMaster.AwardPlayerScore(dmgGiverPlayerNum, 1);
        }

        derbyMaster.GivePoints(rewardPoints, dmgGiverPlayerNum);
        
    }

    
}
