using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SRaceMotorBikeCrash : MonoBehaviour
{
    private Rigidbody rb;
    private SRacePlayerCheckpoint CP;
    [SerializeField]
    private GameObject motorBike;
    [SerializeField]
    private Camera raceCam;
    [SerializeField]
    private Camera crashCam;
    [SerializeField]
    private GameObject crashCamRotator;
    [SerializeField]
    private GameObject crashDebris;
    private Vector3 offset;
    private bool isCrashing = false;
    private RVehicleTypeSelector typeSelector;

    private void Start()
    {
        rb = motorBike.GetComponent<Rigidbody>();
        CP = motorBike.GetComponent<SRacePlayerCheckpoint>();
        typeSelector = GetComponent<RVehicleTypeSelector>();
    }

    private void Update()
    {
        if (isCrashing)
        {
            return;
        }

        if (rb && rb.angularVelocity.magnitude > 3f)
        {
            isCrashing = true;
            Crash();
        }
    }

    void Crash()
    {
        motorBike.SetActive(false);

        crashCam.rect = raceCam.rect;
        crashCamRotator.transform.position = motorBike.transform.position;

        Vector3 targetRot = crashCamRotator.transform.rotation.eulerAngles;
        targetRot.y = motorBike.transform.rotation.eulerAngles.y;
        crashCamRotator.transform.rotation = Quaternion.Euler(targetRot);
        crashCamRotator.SetActive(true);

        GameObject spawnedCrash = Instantiate(crashDebris, motorBike.transform.position, motorBike.transform.rotation);
        spawnedCrash.GetComponent<RPlayerScore>().playerNum = typeSelector.GetPlayerNum();
        spawnedCrash.GetComponent<RVehicleColorSelector>().typeSelector = typeSelector;
        Destroy(spawnedCrash, 10f);
        StartCoroutine(RespawnMotorBike());

    }

    IEnumerator RespawnMotorBike()
    {
        yield return new WaitForSeconds(3f);
        crashCamRotator.SetActive(false);
        motorBike.SetActive(true);
        CP.Respawn();
        isCrashing = false;
    }
}
