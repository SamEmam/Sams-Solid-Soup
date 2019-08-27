using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SRHTrafficEngine : MonoBehaviour
{
    public Transform path;

    [Header("Steering")]
    public float maxSteerAngle = 45f;
    public float turnSpeed = 15f;
    public WheelCollider wheelFL;
    public WheelCollider wheelFR;
    public WheelCollider wheelRL;
    public WheelCollider wheelRR;

    [Header("Driving")]
    public float maxMotorTorque = 300f;
    public float maxBrakeTorque = 250f;
    public float currentSpeed;
    public float maxSpeed = 50f;
    public float randomMin, randomMax;

    [Header("")]
    public Vector3 centerOfMass;
    private Vector3 rigidbodySpeed;
    public float vehicleSpeed;
    private bool isBraking = false;
    private bool isReversing = false;


    [Header("Sensors")]
    public float sensorLength = 1f;
    public Vector3 frontSensorPosition = new Vector3(0f, 0f, 0f);
    public float frontSideSensorPosition = 0.15f;
    public float frontSensorAngle = 10;

    [Header("Nodes")]
    private List<Transform> nodes;
    public int currentNode = 0;
    public float maxNodeDistance = 2f;
    public bool avoiding = false;
    private float targetSteerAngle = 0;


    // Use this for initialization
    void Start()
    {
        maxSpeed = Random.Range(randomMin, randomMax);
        GetComponent<Rigidbody>().centerOfMass = centerOfMass;


        Transform[] pathTransforms = path.GetComponentsInChildren<Transform>();
        nodes = new List<Transform>();

        for (int i = 0; i < pathTransforms.Length; i++)
        {
            if (pathTransforms[i] != path.transform)
            {
                nodes.Add(pathTransforms[i]);
            }
        }
        //spawnTimeLeft = 0;
    }


    void Update()
    {
        if (!path)
        {
            Destroy(gameObject);
        }
        rigidbodySpeed = GetComponent<Rigidbody>().velocity;
        vehicleSpeed = rigidbodySpeed.magnitude;
        Sensors();
        ApplySteer();
        Drive();
        CheckWaypointDistance();
        Braking();
        LerpToSteerAngle();
    }

    private void Sensors()
    {
        RaycastHit hit;
        Vector3 sensorStartPos = transform.position;
        sensorStartPos += transform.forward * frontSensorPosition.z;
        float avoidMultiplier = 0;
        avoiding = false;
        isBraking = false;
        isReversing = false;
        

        //front right sensor
        sensorStartPos += transform.right * frontSideSensorPosition;
        if (Physics.Raycast(sensorStartPos, transform.forward, out hit, sensorLength))
        {
            if (hit.collider.CompareTag("Vehicle") || hit.collider.CompareTag("PlayerChassis") || hit.collider.CompareTag("Player"))
            {
                Debug.DrawLine(sensorStartPos, hit.point);
                avoiding = true;
                avoidMultiplier -= 0.5f;
            }
        }

        //front right angle sensor
        else if (Physics.Raycast(sensorStartPos, Quaternion.AngleAxis(frontSensorAngle, transform.up) * transform.forward, out hit, sensorLength))
        {
            if (hit.collider.CompareTag("Vehicle") || hit.collider.CompareTag("PlayerChassis") || hit.collider.CompareTag("Player"))
            {
                Debug.DrawLine(sensorStartPos, hit.point);
                avoiding = true;
                avoidMultiplier -= 0.25f;
            }
        }

        //front left sensor
        sensorStartPos -= transform.right * frontSideSensorPosition * 2;
        if (Physics.Raycast(sensorStartPos, transform.forward, out hit, sensorLength))
        {
            if (hit.collider.CompareTag("Vehicle") || hit.collider.CompareTag("PlayerChassis") || hit.collider.CompareTag("Player"))
            {
                Debug.DrawLine(sensorStartPos, hit.point);
                avoiding = true;
                avoidMultiplier += 0.5f;
            }
        }

        //front left angle sensor
        else if (Physics.Raycast(sensorStartPos, Quaternion.AngleAxis(-frontSensorAngle, transform.up) * transform.forward, out hit, sensorLength))
        {
            if (hit.collider.CompareTag("Vehicle") || hit.collider.CompareTag("PlayerChassis") || hit.collider.CompareTag("Player"))
            {
                Debug.DrawLine(sensorStartPos, hit.point);
                avoiding = true;
                avoidMultiplier += 0.25f;
            }
        }

        //front center sensor
        if (avoidMultiplier == 0)
        {
            if (Physics.Raycast(sensorStartPos, transform.forward, out hit, sensorLength))
            {
                if (hit.collider.CompareTag("Vehicle") || hit.collider.CompareTag("PlayerChassis") || hit.collider.CompareTag("Player"))
                {
                    Debug.DrawLine(sensorStartPos, hit.point);
                    isReversing = true;

                }
            }

        }

        if (avoiding)
        {
            targetSteerAngle = maxSteerAngle * avoidMultiplier;
        }
    }

    void ApplySteer()
    {
        if (avoiding)
        {
            return;
        }

        int offsetStrength = 20;

        Vector3 randomOffset = new Vector3(Random.Range(-offsetStrength, offsetStrength), 0, Random.Range(-offsetStrength, offsetStrength));
        if (!nodes[currentNode])
        {
            return;
        }
        Vector3 relativeVector = transform.InverseTransformPoint(nodes[currentNode].position + randomOffset);
        float newSteer = (relativeVector.x / relativeVector.magnitude) * maxSteerAngle;
        targetSteerAngle = newSteer;
    }

    void Drive()
    {

        currentSpeed = 2 * Mathf.PI * wheelFL.radius * wheelFL.rpm * 60 / 1000;
        if (isReversing)
        {
            wheelFL.motorTorque = -maxMotorTorque;
            wheelFR.motorTorque = -maxMotorTorque;
            wheelRL.motorTorque = -maxMotorTorque;
            wheelRR.motorTorque = -maxMotorTorque;
        }
        else if (vehicleSpeed < maxSpeed && !isBraking)
        {
            wheelFL.motorTorque = maxMotorTorque;
            wheelFR.motorTorque = maxMotorTorque;
            wheelRL.motorTorque = maxMotorTorque;
            wheelRR.motorTorque = maxMotorTorque;
        }
        else
        {
            wheelFL.motorTorque = 0;
            wheelFR.motorTorque = 0;
            wheelRL.motorTorque = 0;
            wheelRR.motorTorque = 0;
        }
    }

    void CheckWaypointDistance()
    {
        if (Vector3.Distance(transform.position, nodes[currentNode].position) < maxNodeDistance)
        {

            if (currentNode == nodes.Count - 1)
            {
                currentNode = 0;
            }
            else
            {
                currentNode++;
            }
        }
    }

    void Braking()
    {

        if (isBraking)
        {
            wheelRL.brakeTorque = maxBrakeTorque;
            wheelRR.brakeTorque = maxBrakeTorque;
            wheelFL.brakeTorque = maxBrakeTorque;
            wheelFR.brakeTorque = maxBrakeTorque;
        }
        else
        {
            wheelRL.brakeTorque = 0;
            wheelRR.brakeTorque = 0;
            wheelFL.brakeTorque = 0;
            wheelFR.brakeTorque = 0;
        }
    }

    int PreviousNode()
    {
        var previousNode = 0;

        if (currentNode == 0)
        {
            previousNode = nodes.Count - 1;
        }
        else
        {
            previousNode = currentNode - 1;
        }

        return previousNode;
    }

    int NextNode()
    {
        var nextNode = 0;

        if (currentNode == nodes.Count - 1)
        {
            nextNode = 0;
        }
        else
        {
            nextNode = currentNode + 1;
        }
        return nextNode;
    }

    void LerpToSteerAngle()
    {
        wheelFL.steerAngle = Mathf.Lerp(wheelFL.steerAngle, targetSteerAngle, Time.deltaTime * turnSpeed);
        wheelFR.steerAngle = Mathf.Lerp(wheelFR.steerAngle, targetSteerAngle, Time.deltaTime * turnSpeed);
    }
}
