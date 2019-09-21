using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SDerbyPlayer : MonoBehaviour
{
    private int health = 1000;
    [HideInInspector]
    public int points = 0;
    [HideInInspector]
    public int kills = 0;
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

    public ParticleSystem smoke, fire;
    
    private ParticleSystem.EmissionModule smokeEmission, fireEmission;

    private bool isBracing;
    private float braceCounter;
    private float braceTime = 0.05f;


    private void Awake()
    {
        smokeEmission = smoke.emission;
        fireEmission = fire.emission;
    }

    private void Start()
    {
        playerNum = GetComponent<RPlayerScore>().playerNum;
        CP = GetComponent<SRacePlayerCheckpoint>();
        derbyMaster = FindObjectOfType<SDerbyMaster>();
        derbyMaster.players.Add(this);
        debrisRB = debris.GetComponent<Rigidbody>();
        playerRB = GetComponent<Rigidbody>();
        debris.SetActive(false);
        debris.transform.SetParent(null);



        smokeEmission.rateOverTime = 0;
        fireEmission.rateOverTime = 0;
    }

    private void Update()
    {
        var reversedHealth = 1000 - health;

        smokeEmission.rateOverTime = reversedHealth / 10;

        if (reversedHealth > 750)
        {
            fireEmission.rateOverTime = reversedHealth / 20;
        }

        if (braceCounter <= Time.time && isBracing)
        {
            isBracing = false;
        }
    }

    void Die()
    {
        debris.transform.position = transform.position;
        debris.transform.rotation = transform.rotation;
        debris.SetActive(true);

        Instantiate(explosion, transform.position, transform.rotation);

        debrisRB.velocity = playerRB.velocity;
        debrisRB.angularVelocity = playerRB.angularVelocity;
        debrisRB.AddForce(Vector3.up, ForceMode.VelocityChange);

        CP.Respawn();

        health = 1000;
        smokeEmission.rateOverTime = 0;
        fireEmission.rateOverTime = 0;
    }

    public void TakeDamage(int dmg, int dmgGiverPlayerNum)
    {
        if (!canTakeDMG || isBracing)
        {
            return;
        }

        isBracing = true;
        braceCounter = Time.time + braceTime;
        

        int rewardPoints = dmg;
        health -= dmg;

        if (health <= 0)
        {
            Die();
            rewardPoints += 1000;
            if (dmgGiverPlayerNum != playerNum)
            {
                derbyMaster.AwardPlayerScore(dmgGiverPlayerNum, 1);
                derbyMaster.GiveKill(dmgGiverPlayerNum);
            }
        }
        if (dmgGiverPlayerNum != playerNum)
        {
            derbyMaster.GivePoints(rewardPoints, dmgGiverPlayerNum);
        }
        
        
    }

    
}
