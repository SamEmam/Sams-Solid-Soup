using UnityEngine;
using System.Collections;

public class BoidFlocking : MonoBehaviour
{
    private GameObject Controller;
    [HideInInspector]
    public BoidController boidController;
    private bool inited = false;
    private float minVelocity;
    private float maxVelocity;
    private float randomness;
    private GameObject chasee;
    private Rigidbody rb;
    [HideInInspector]
    public int followStrength = 2;
    private float rotSpeed = 3.5f;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        StartCoroutine("BoidSteering");
        boidController = Controller.GetComponent<BoidController>();
    }

    IEnumerator BoidSteering()
    {
        while (true)
        {
            if (inited)
            {
                rb.velocity = rb.velocity + Calc() * Time.deltaTime;

                // enforce minimum and maximum speeds for the boids
                float speed = rb.velocity.magnitude;
                if (speed > maxVelocity)
                {
                    rb.velocity = rb.velocity.normalized * maxVelocity;
                }
                else if (speed < minVelocity)
                {
                    rb.velocity = rb.velocity.normalized * minVelocity;
                }
            }

            float waitTime = Random.Range(0.3f, 0.5f);
            yield return new WaitForSeconds(waitTime);
        }
    }

    private void OnDisable()
    {
        boidController.boids.Remove(gameObject);
    }

    private void Update()
    {
        Quaternion targetRot = Quaternion.LookRotation(rb.velocity);

        transform.rotation = Quaternion.Slerp(transform.rotation, targetRot, rotSpeed * Time.deltaTime);
    }

    private Vector3 Calc()
    {
        Vector3 randomize = new Vector3((Random.value * 2) - 1, (Random.value * 2) - 1, (Random.value * 2) - 1);

        randomize.Normalize();
        BoidController boidController = Controller.GetComponent<BoidController>();
        Vector3 flockCenter = boidController.flockCenter;
        Vector3 flockVelocity = boidController.flockVelocity;
        Vector3 follow = chasee.transform.localPosition;

        flockCenter = flockCenter - transform.localPosition;
        flockVelocity = flockVelocity - rb.velocity;
        follow = follow - transform.localPosition;

        return (flockCenter + flockVelocity + follow * followStrength + randomize * randomness);
    }

    public void SetController(GameObject theController)
    {
        Controller = theController;
        BoidController boidController = Controller.GetComponent<BoidController>();
        minVelocity = boidController.minVelocity;
        maxVelocity = boidController.maxVelocity;
        randomness = boidController.randomness;
        chasee = boidController.chasee;
        inited = true;
    }

    //public void SetController(BoidController boidController)
    //{
    //    minVelocity = boidController.minVelocity;
    //    maxVelocity = boidController.maxVelocity;
    //    randomness = boidController.randomness;
    //    chasee = boidController.chasee;
    //    inited = true;
    //}
}