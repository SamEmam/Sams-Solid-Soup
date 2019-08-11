using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Rewired;

public class RRocketSniper : MonoBehaviour
{
    [Header("Attributes")]
    public int playerNum;
    public int powerupNum = 3;
    public float radius = 10f;
    public float threshold = 0.9f;
    public Transform target;
    public float lockOnTime = 2f;
    private List<Transform> selectables;
    private float spawnOffset = 1f;
    private float closest = 0f;

    [Header("Setup")]

    public RLaserPointerScript laserPoint;
    public Transform parent;
    public GameObject rocket;
    public RPlayerPowerup playerPowerup;
    private Ray ray;
    private Player player;
    private bool lockedOn = false;

    private void Start()
    {
        player = ReInput.players.GetPlayer(playerNum);
        ray = new Ray(transform.position, transform.forward);
    }

    private void Update()
    {
        DetectTarget();

        if (target)
        {
            Rotate();
            laserPoint.hasTarget = true;
            lockedOn = true;
            //StartCoroutine(LockOnTarget());
        }
        else
        {
            ResetRotation();
            laserPoint.hasTarget = false;
            lockedOn = false;
        }

        if (player.GetButtonDown("Shoot"))
        {
            Shoot();
        }
    }

    IEnumerator LockOnTarget()
    {
        var tempTime = lockOnTime;
        while (target)
        {
            tempTime -= Time.deltaTime;

            if (tempTime <= 0)
            {
                break;
            }
            yield return null;
        }
        laserPoint.hasTarget = true;
        lockedOn = true;
    }

    void Shoot()
    {
        RRocket rRocket = Instantiate(rocket, laserPoint.transform.position + (laserPoint.transform.forward * spawnOffset), laserPoint.transform.rotation).GetComponent<RRocket>();
        if (!lockedOn)
        {
            target = null;
        }
        rRocket.target = target;
        playerPowerup.DisablePowerup(powerupNum);
    }

    void DetectTarget()
    {
        target = null;
        selectables = new List<Transform>();
        closest = 0f;

        Collider[] hitColliders = Physics.OverlapSphere(transform.position, radius);
        foreach (var collider in hitColliders)
        {
            if (collider.transform.tag == "Player")
            {
                if (collider.transform != parent && AngleCheck(ray, collider.transform))
                {
                    selectables.Add(collider.transform);
                }
            }
        }

        float dist = float.MaxValue;

        foreach (var selected in selectables)
        {
            if (Vector3.Distance(selected.position, transform.position) < dist)
            {
                target = selected;
            }
        }
    }

    void Rotate()
    {
        Vector3 targetDir = target.position - transform.position;
        float step = 1f * Time.deltaTime;

        Vector3 newDir = Vector3.RotateTowards(transform.forward, targetDir, step, 0.0f);

        transform.rotation = Quaternion.LookRotation(newDir);
    }

    void ResetRotation()
    {
        //var targetDir = Quaternion.Euler(0, 0, 0);
        float step = 40f * Time.deltaTime;

        transform.rotation = Quaternion.RotateTowards(transform.rotation, parent.transform.rotation, step);
        
    }

    bool AngleCheck(Ray ray, Transform selected)
    {
        var vector1 = parent.transform.forward;
        var vector2 = selected.position - transform.position;

        var lookPercentage = Vector3.Dot(vector1.normalized, vector2.normalized);
        
        if (lookPercentage > threshold)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
