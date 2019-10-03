using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BoidController : MonoBehaviour
{
    public float minVelocity = 5;
    public float maxVelocity = 20;
    public float randomness = 1;
    public int flockSize = 20;
    public int followStrength;
    public GameObject prefab;
    public GameObject chasee;

    public Vector3 flockCenter;
    public Vector3 flockVelocity;
    [HideInInspector]
    public List<GameObject> boids = new List<GameObject>();
    private Collider boxCol;

    public int playerNum;
    [SerializeField]
    private SSBPlayer SBP;

    void Start()
    {
        boxCol = GetComponent<Collider>();

        for (var i = 0; i < flockSize; i++)
        {
            Spawn();
        }
    }

    void Update()
    {
        Vector3 theCenter = Vector3.zero;
        Vector3 theVelocity = Vector3.zero;

        foreach (GameObject boid in boids)
        {
            theCenter = theCenter + boid.transform.localPosition;
            theVelocity = theVelocity + boid.GetComponent<Rigidbody>().velocity;
            boid.GetComponent<BoidFlocking>().followStrength = followStrength;
        }

        flockCenter = theCenter / (flockSize);
        flockVelocity = theVelocity / (flockSize);
    }

    public void Spawn()
    {
        Vector3 position = new Vector3(
                Random.value * boxCol.bounds.size.x,
                Random.value * boxCol.bounds.size.y,
                Random.value * boxCol.bounds.size.z
            ) - boxCol.bounds.extents;

        GameObject boid = Instantiate(prefab, transform.position, transform.rotation) as GameObject;
        boid = boid.GetComponent<SSBColorSelector>().LoadColor(playerNum);
        boid.GetComponent<SSBSpaceship>().SBP = SBP;
        boid.transform.parent = transform;
        boid.transform.localPosition = position;
        boid.GetComponent<BoidFlocking>().SetController(gameObject);
        //boid.GetComponent<BoidFlocking>().SetController(this);
        boids.Add(boid);
    }
}