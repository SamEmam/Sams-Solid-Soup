using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SLCSShipController : MonoBehaviour
{
    private Animator anim;
    public int spawnTime;
    private float startTime;
    private float timeOfShot;

    public Animator cannonAnim;
    public ParticleSystem shootParticle;
    public GameObject cannonBall;
    public Transform firePoint;
    private bool hasSpawned = false;

    private int shootSpeed = 2500;
    private float shootTime = 5f;
    private float destroySpeed = 20f;

    private void Start()
    {
        anim = GetComponent<Animator>();
        startTime = Time.time;
    }

    private void Update()
    {
        

        if (!hasSpawned)
        {
            if (Time.time - startTime > spawnTime)
            {
                hasSpawned = true;
                Spawn();
                timeOfShot = Time.time;
            }
            return;
        }
        if (Time.time - timeOfShot > shootTime)
        {
            Shoot();
            timeOfShot = Time.time;
        }
    }

    void Spawn()
    {
        anim.Play("Spawn");
    }

    void Shoot()
    {
        UpdateShootSpeed();

        cannonAnim.Play("CannonShoot");
        GameObject ball = Instantiate(cannonBall, firePoint.position, firePoint.rotation);
        Instantiate(shootParticle, firePoint.position, firePoint.rotation);
        ball.GetComponent<Rigidbody>().AddForce(firePoint.forward * shootSpeed * Time.deltaTime, ForceMode.VelocityChange);

        Destroy(ball, destroySpeed);
    }

    void UpdateShootSpeed()
    {
        if (Time.time - startTime > 200)
        {
            shootTime = 1f;
            destroySpeed = 5f;
        }
        else if (Time.time - startTime > 150)
        {
            shootTime = 2f;
            destroySpeed = 10f;
        }
        else if (Time.time - startTime > 120)
        {
            shootTime = 3f;
            destroySpeed = 15f;
        }
        else if (Time.time - startTime > 100)
        {
            shootTime = 4f;
        }
    }
}
